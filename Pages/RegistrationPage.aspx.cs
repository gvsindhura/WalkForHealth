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
    public partial class RegistrationPage : System.Web.UI.Page
    {
        DataLayer.DataLayer dataLayer = new DataLayer.DataLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //refresh calendar control
                cdrBirthDate.DataBind();

                //#region Load Dropdowns

                ddlNationality.DataValueField = ddlState.DataValueField = "ID";
                ddlNationality.DataTextField = ddlState.DataTextField = "Name";
                ddlNationality.DataSource = dataLayer.GetCountries("Name");
                ddlState.DataSource = dataLayer.GetStates("Name");
                ddlNationality.DataBind(); ddlState.DataBind();
                ddlNationality.Items.Insert(0, new ListItem("--select--"));
                ddlState.Items.Insert(0, new ListItem("--select--"));
                ddlNationality_SelectedIndexChanged(null, EventArgs.Empty);
                ddlState_SelectedIndexChanged(null, EventArgs.Empty);

            //    //load walkingstepcalculatortypes
            //    key = string.Format("{0}_{1}", Constants.CACHEKEY_WALKINGSTEPCALCULATORTYPES, currentLanguage);
            //    if (CacheController.Get(key) == null)
            //    {
            //        CacheController.Set(key, CoreServiceController.GetWalkingStepCalculatorTypes(currentLanguage));
            //    }
            //    ddlWalkingStepCalculatorTypes.DataValueField = "ID"; ddlWalkingStepCalculatorTypes.DataTextField = currentLanguage == Constants.LANGUAGE_ENGLISH ? "Name" : "NameInArabic";
            //    ddlWalkingStepCalculatorTypes.DataSource = (WalkingStepCalculatorTypes[])CacheController.Get(key);
            //    ddlWalkingStepCalculatorTypes.DataBind();
            //    ddlWalkingStepCalculatorTypes.Items.Insert(0, new ListItem(GetLocalResourceObject("DropdownListItemDefaultText").ToString(), ""));
            //    ddlWalkingStepCalculatorTypes_SelectedIndexChanged(null, EventArgs.Empty);




            //    //load languages dropdown
            //    key = string.Format("{0}_{1}", Constants.CACHEKEY_LANGUAGES, currentLanguage);
            //    if (CacheController.Get(key) == null)
            //    {
            //        CacheController.Set(key, CoreServiceController.GetLanguages(currentLanguage));
            //    }

            //    rblLanguage.DataValueField = "ID"; rblLanguage.DataTextField = currentLanguage == Constants.LANGUAGE_ENGLISH ? "Name" : "NameInArabic";
            //    rblLanguage.DataSource = (Language[])CacheController.Get(key);
            //    rblLanguage.DataBind();
            //    rblLanguage.SelectedIndex = 0;

            //    #endregion

            //    if (ConfigurationFile.OpenRegistration)
            //    {
            //        pnlNoRegistration.Visible = false;
            //        pnlRegistration.Visible = true;
            //    }
            //    else
            //    {
            //        pnlNoRegistration.Visible = true;
            //        pnlRegistration.Visible = false;
            //    }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!IsValid)
                return;
            if (chkDisclaimerYes.Checked != true)
            {
                ClientScript.RegisterStartupScript(typeof(string), "AgreeTerms", string.Format("alert('{0}');", "You have to agree to the terms & conditions"), true);
                return;
            }
                //set member properties and submit to server
            Member member = new Member();
            member.FirstName = txtFirstName.Text.Trim();
            member.LastName = txtLastName.Text.Trim();
            member.UserName = txtUserName.Text.Trim();
            member.Password = txtPassword.Text.Trim();
            member.Email = txtEmail.Text.Trim();
            member.Nationality = new Country();
            member.Nationality.ID = int.Parse(ddlNationality.SelectedValue);
            member.IsMaleGender = rblGender.SelectedValue == "1";
            member.BirthDate = cdrBirthDate.SelectedDate;
            member.MobilePhone = txtMobilePhone.Text.Trim();
            member.HomePhone = txtHomePhone.Text.Trim(); 
            member.Address = txtAddress.Text.Trim();
            member.ZipCode = txtZipCode.Text.Trim();
            member.State = int.Parse(ddlState.SelectedValue);
            member.NotifyByEmail = chkNotificationByEmail.Checked;
            member.NotifyBySMS = chkNotificationBySMS.Checked;

            try
            {
                string membershipNumber; bool isWaitlisted;
                int memberID = dataLayer.RegisterMember(member);
            }
            catch (FaultException<ApplicationFault> fault)
            {
                switch (fault.Detail.Code.ToString())
                {
                    case "1":
                        ClientScript.RegisterStartupScript(typeof(string), "RegisterMemberFail_1", string.Format("addColoredMessage('{0}', '{1}', 'Red');", vdsSummary.ClientID, string.Format(GetLocalResourceObject("Registration.UsernameExist").ToString())), true);
                        break;
                    case "2":
                        ClientScript.RegisterStartupScript(typeof(string), "RegisterMemberFail_2", string.Format("addColoredMessage('{0}', '{1}', 'Red');", vdsSummary.ClientID, string.Format(GetLocalResourceObject("Registration.EmailExist").ToString())), true);
                        break;             
                    default:
                        ClientScript.RegisterStartupScript(typeof(string), "RegisterMemberFail_NA", string.Format("addColoredMessage('{0}', '{1}', 'Red');", vdsSummary.ClientID, string.Format(GetLocalResourceObject("Registration.UnhandledError").ToString())), true);
                        break;
                }

                return;
            }

            ClientScript.RegisterStartupScript(typeof(string), "RegisterMemberSuccess", string.Format("alert('{0}'); window.location.href='default.aspx';", "Member Registered Successfully"), true);
        }

        protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlNationality.SelectedValue == "")
            //{
            //    imgNationalityFlag.Visible = false;
            //}
            //else
            //{
            //    imgNationalityFlag.ImageUrl = string.Format(@"~\Images\Flags\{0}.png", ddlNationality.SelectedValue);
            //    imgNationalityFlag.ToolTip = string.Format("{0}", ddlNationality.SelectedItem.Text);
            //}
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlNationality.SelectedValue == "")
            //{
            //    imgNationalityFlag.Visible = false;
            //}
            //else
            //{
            //    imgNationalityFlag.ImageUrl = string.Format(@"~\Images\Flags\{0}.png", ddlNationality.SelectedValue);
            //    imgNationalityFlag.ToolTip = string.Format("{0}", ddlNationality.SelectedItem.Text);
            //}
        }

        protected void ddlBloodSugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            //uplBloodSugar.Visible = ddlBloodSugar.SelectedValue == "1";
        }

        protected void ddlWalkingStepCalculatorTypes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }  
    }
}