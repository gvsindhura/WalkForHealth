using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Class;

namespace WebApplication1.Pages.Controls
{
    public partial class Login : System.Web.UI.UserControl
    {
        DataLayer.DataLayer dataLayer = new DataLayer.DataLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hidLoginTrialCount.Value = "0";                
            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Member member = dataLayer.AuthenticateMember(txtUserName.Text, txtPassword.Text);
            if (member == null)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "Login_Fail", string.Format("addColoredMessage('{0}', '{1}', 'Red');", vdsSummary.ClientID, string.Format(GetLocalResourceObject("Login.LoginFail").ToString())), true);

                hidLoginTrialCount.Value = (int.Parse(hidLoginTrialCount.Value) + 1).ToString();

                //security check: max trials count
                if (hidLoginTrialCount.Value == "3")
                {
                    this.Page.ClientScript.RegisterStartupScript(typeof(string), "Login_TrialLimit", string.Format("addColoredMessage('{0}', '{1}', 'Red');", vdsSummary.ClientID, string.Format(GetLocalResourceObject("Login.LoginTrialLimit").ToString())), true);
                    return;
                }
            }
            else
            {
                //store in session
                SessionController.Set(Constants.SESSION_MEMBER, member);

                ////store cookie if requested
                //if (chkRememberMe.Checked)
                //{
                //    HttpCookie loginCookie = new HttpCookie(Constants.COOKIEKEY_MEMBERLOGIN, member.MembershipNumber);
                //    loginCookie.Expires = DateTime.Now.AddDays(7);

                //    Response.Cookies.Add(loginCookie);
                //}
                               
                //auto redirect to home
                Response.Redirect("EnterPedometerSteps.aspx", true);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx", true);
        }
    }
}