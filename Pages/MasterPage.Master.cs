using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Threading;
using WebApplication1.Class;
using WebApplication1.DataLayer;

namespace WebApplication1.Pages
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
               
                ////check if user logged in already
                //Member member = (Member)SessionController.Get(Constants.SESSIONKEY_MEMBER);
                //if (member == null)
                //{
                //    pnlMember.Visible = false;
                //}
                //else
                //{
                //    pnlMember.Visible = true;
                //    lblMemberName.Text = string.Format("{0} {1}", GetLocalResourceObject("Member.Welcome"), member.Name);

                //    btnLogout.OnClientClick = string.Format("return confirm('{0}');", GetLocalResourceObject("Member.LogoutClientSideMessage"));
                //}

                ////set facebook header
                //metaFacebookAppID.Content = ConfigurationFile.FacebookApplicationID;
                //metaFacebookImage.Content = string.Format("{0}/Images/skeleton_fb.jpg", ConfigurationFile.ApplicationRootUrl);
                //metaFacebookSiteName.Content = metaFacebookTitle.Content = ConfigurationFile.ApplicationName;
                //metaFacebookUrl.Content = ConfigurationFile.ApplicationRootUrl;

                
            }            
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            //remove login cookie
            HttpCookie loginCookie = Request.Cookies[Constants.COOKIE_LOGIN];

            if (loginCookie != null)
            {
                loginCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(loginCookie);
            }

            ////clear up session
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();

            Response.Redirect("~/Login.aspx", true);
        }
    }
}
