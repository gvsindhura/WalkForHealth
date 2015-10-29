using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DataLayer;
using WebApplication1.Class;
using System.Text;

namespace WebApplication1.Pages
{
    public partial class MemberCharts : System.Web.UI.Page
    {
        DataLayer.DataLayer dataLayer = new DataLayer.DataLayer();
        private Dictionary<string, int> GenderSummaryReport
        {
            set
            {
                this.ViewState["GenderChart"] = value;
            }
            get
            {
                return (Dictionary<string, int>)this.ViewState["GenderChart"];
            }
        }
        private Dictionary<State, int> StateSummaryReport
        {
            set
            {
                this.ViewState["StateSummaryReport"] = value;
            }
            get
            {
                return (Dictionary<State, int>)this.ViewState["StateSummaryReport"];
            }
        }

        private Dictionary<int, int> AgeSummaryReport
        {
            set
            {
                this.ViewState["AgeSummaryReport"] = value;
            }
            get
            {
                return (Dictionary<int, int>)this.ViewState["AgeSummaryReport"];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                #region Gender

                ddlStateByGender.DataSource = ddlStateByAge.DataSource = dataLayer.GetStates("name");
                ddlStateByGender.DataTextField = ddlStateByAge.DataTextField = "Name"; 
                ddlStateByGender.DataValueField = ddlStateByAge.DataValueField = "ID";
                ddlStateByGender.DataBind(); ddlStateByAge.DataBind();
                for (int i = ConfigurationFile.CalendarMinimumDate; i <= ConfigurationFile.CalendarMaximumDate; i++)
                {
                    ddlFromAgeByGender.Items.Add(i.ToString()); ddlToAgeByGender.Items.Add(i.ToString());
                    ddlFromAgeByState.Items.Add(i.ToString()); ddlToAgeByState.Items.Add(i.ToString());
                }
                ddlFromAgeByGender.Items.Insert(0, new ListItem("-Any-", "")); ddlToAgeByGender.Items.Insert(0, new ListItem("-Any-", ""));
                ddlFromAgeByState.Items.Insert(0, new ListItem("-Any-", "")); ddlToAgeByState.Items.Insert(0, new ListItem("-Any-", ""));
                ddlStateByGender.Items.Insert(0, new ListItem("-Any-", "")); ddlStateByAge.Items.Insert(0, new ListItem("-Any-", ""));

                
                
                #endregion
                rbtnChart_CheckedChanged(null, null);

            }
        }
        protected void btnSearchByGender_Click(object sender, EventArgs e)
        {
            this.GenderSummaryReport = dataLayer.MemberChart_Gender(ddlStateByGender.SelectedValue == "" ? null : (int?)int.Parse(ddlStateByGender.SelectedValue), ddlFromAgeByGender.SelectedValue == "" ? null : (int?)int.Parse(ddlFromAgeByGender.SelectedValue), ddlToAgeByGender.SelectedValue == "" ? null : (int?)int.Parse(ddlToAgeByGender.SelectedValue));

            UpdateChart();
        }

        protected void btnSearchByAge_Click(object sender, EventArgs e)
        {
            this.AgeSummaryReport = dataLayer.MemberChart_Age(ddlStateByAge.SelectedValue == "" ? null : (int?)int.Parse(ddlStateByAge.SelectedValue), ddlGenderByAge.SelectedValue == "" ? null : (bool?)(ddlGenderByAge.SelectedValue == "1"));

            UpdateChart();
        }

        protected void btnSearchByState_Click(object sender, EventArgs e)
        {
            this.StateSummaryReport = dataLayer.MemberChart_State(ddlGenderByState.SelectedValue == "" ? null : (bool?)(ddlGenderByState.SelectedValue == "1"), ddlFromAgeByState.SelectedValue == "" ? null : (int?)int.Parse(ddlFromAgeByState.SelectedValue), ddlToAgeByState.SelectedValue == "" ? null : (int?)int.Parse(ddlToAgeByState.SelectedValue));

            UpdateChart();
        }

        private void UpdateChart()
        {
            int genderCount = 0; int StateCount = 0; int ageCount = 0;

            #region Gender

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<Metadata><AllValues>");
            stringBuilder.Append("<Row Gender='' MemberCount='0'/>");
            foreach (string gender in this.GenderSummaryReport.Keys)
            {
                stringBuilder.Append(string.Format("<Row Gender='{0}' MemberCount= '{1}' />", gender, this.GenderSummaryReport[gender]));
                genderCount = genderCount + this.GenderSummaryReport[gender];
            }
            stringBuilder.Append("<Row Gender='' MemberCount='0' />");
            stringBuilder.Append("</AllValues></Metadata>");

            xmlDSGenderSummaryReport.Data = stringBuilder.ToString();

            lctGender.Visible = true;
            lctGender.DataSource = xmlDSGenderSummaryReport;
            lcgGender.DataSource = xmlDSGenderSummaryReport;
            lblGender.Text = string.Format("<b>Count of Members By Gender</b> - <i>{0} members</i>", string.Format("{0:#,0}", genderCount));

            #endregion

            #region State

            stringBuilder = new StringBuilder();
            stringBuilder.Append("<Metadata><AllValues>");
            stringBuilder.Append("<Row State='' MemberCount='0'/>");

            foreach (State state in this.StateSummaryReport.Keys)
            {
                stringBuilder.Append(string.Format("<Row State='{0}' MemberCount= '{1}' />", state.Name, this.StateSummaryReport[state]));
                StateCount = StateCount + this.StateSummaryReport[state];
            }
            stringBuilder.Append("<Row State='' MemberCount='0' />");
            stringBuilder.Append("</AllValues></Metadata>");

            xmlDSStateSummaryReport.Data = stringBuilder.ToString();

            lctState.Visible = true;
            lctState.DataSource = xmlDSStateSummaryReport;
            lcgState.DataSource = xmlDSStateSummaryReport;
            lblState.Text = string.Format("<b>Count of Members By State</b> - <i>{0} members</i>", string.Format("{0:#,0}", StateCount));

            #endregion

            #region Age

            stringBuilder = new StringBuilder();
            stringBuilder.Append("<Metadata><AllValues>");
            stringBuilder.Append("<Row Age='' MemberCount='0'/>");

            foreach (int age in this.AgeSummaryReport.Keys)
            {
                stringBuilder.Append(string.Format("<Row Age='{0}' MemberCount= '{1}' />", age, this.AgeSummaryReport[age]));
                ageCount = ageCount + this.AgeSummaryReport[age];
            }
            stringBuilder.Append("<Row Age='' MemberCount='0'/>");
            stringBuilder.Append("</AllValues></Metadata>");

            xmlDSAgeSummaryReport.Data = stringBuilder.ToString();

            lctAge.Visible = true;
            lctAge.DataSource = xmlDSAgeSummaryReport;
            lcgAge.DataSource = xmlDSAgeSummaryReport;
            lblAge.Text = string.Format("<b>Count of Members By Age</b> - <i>{0} members</i>", string.Format("{0:#,0}", ageCount));
            #endregion
        }

        protected void rbtnChart_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnChartGender.Checked == true)
            {
                pnlChartGender.Visible = true;
                pnlChartState.Visible = false;
                pnlChartAge.Visible = false;
            }
            else if (rbtnChartAge.Checked == true)
            {
                pnlChartGender.Visible = false;
                pnlChartState.Visible = false;
                pnlChartAge.Visible = true;
            }
            else
            {
                pnlChartGender.Visible = false;
                pnlChartState.Visible = true;
                pnlChartAge.Visible = false;
            }
            ddlFromAgeByGender.SelectedIndex = ddlToAgeByGender.SelectedIndex = ddlFromAgeByState.SelectedIndex = ddlToAgeByState.SelectedIndex = 0;
            ddlStateByGender.SelectedIndex = ddlStateByAge.SelectedIndex = ddlGenderByAge.SelectedIndex = ddlGenderByState.SelectedIndex = 0;

            this.GenderSummaryReport = dataLayer.MemberChart_Gender(null, null, null);
            this.StateSummaryReport = dataLayer.MemberChart_State(null, null, null);
            this.AgeSummaryReport = dataLayer.MemberChart_Age(null, null);

            UpdateChart();
        }        
    }
}