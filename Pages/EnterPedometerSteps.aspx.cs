using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Class;
using System.ServiceModel;

namespace WebApplication1.Pages
{
    public partial class EnterPedometerSteps : System.Web.UI.Page
    {
        DataLayer.DataLayer dataLayer = new DataLayer.DataLayer();
        
       Member member = new Member();
         
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                member = (Member)SessionController.Get(Constants.SESSION_MEMBER);
                //refresh calendar control
                cdrReadingDate.DataBind();
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            Int64 steps = Convert.ToInt64(txtSteps.Text.Trim());
            Int64 aerobicSteps = Convert.ToInt64(txtAerobicSteps.Text.Trim());
            decimal aerobicDuration = Convert.ToDecimal(txtAerobicDuration.Text.Trim());
            //average step length is approximated automatically by multiplying body height by 0.414
            //100steps=0.04miles 100steps = 3.75 kcal for 32 inches foot steps 2345 16
            
            txtDistance.Text = Convert.ToDecimal(Math.Round(((0.04 * steps) / 100), 2)).ToString();           
            decimal calories = Convert.ToDecimal(Math.Round(((3.75*steps)/100),2));
            txtCalories.Text = calories.ToString();
            txtFatBurn.Text = Convert.ToDecimal(Math.Round(calories/18)).ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            MemberPedometerReading reading = new MemberPedometerReading();
            reading.Steps = Convert.ToInt64(txtSteps.Text.Trim());
            reading.AerobicSteps = Convert.ToInt64(txtAerobicSteps.Text.Trim());
            reading.AerobicDuration = Convert.ToDecimal(txtAerobicDuration.Text.Trim());
            reading.Distance = Convert.ToDecimal(txtDistance.Text.Trim());
            reading.Calories = Convert.ToDecimal(txtCalories.Text.Trim());
            reading.FatBurn = Convert.ToDecimal(txtFatBurn.Text.Trim());
            reading.ReadingDate = cdrReadingDate.SelectedDate;
            reading.ModelName = "HJ-120";
            reading.SerialNumber = "HJ1200123472";
            reading.Member = new Member();
            reading.Member.ID = member.ID;
            try
            {                
                Int32 totalSteps = (Int32)dataLayer.AddPedometerReading(reading);
            }
            catch (FaultException<ApplicationFault> fault)
            {
            }
            ClientScript.RegisterStartupScript(typeof(string), "AddPedometerDataSuccess", string.Format("alert('{0}'); window.location.href='default.aspx';", "Member Registered Successfully"), true);
        }
    }
}