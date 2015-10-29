using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DataLayer;

namespace WebApplication1.Pages.Controls
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        #region Properties

        public DateTime SelectedDate
        {
            get
            {
                return new DateTime(int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue), int.Parse(ddlDay.SelectedValue));
            }
            set
            {
                ddlYear.SelectedValue = value.Year.ToString();
                ddlYear_SelectedIndexChanged(null, EventArgs.Empty);

                ddlMonth.SelectedValue = value.Month.ToString();
                ddlMonth_SelectedIndexChanged(null, EventArgs.Empty);

                ddlDay.SelectedValue = value.Day.ToString();
            }
        }

        public bool Enabled
        {
            get
            {
                return ddlDay.Enabled;
            }
            set
            {
                ddlDay.Enabled = ddlMonth.Enabled = ddlYear.Enabled = value;
            }
        }

        public bool UseCalendarMinimumDate
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(ViewState["UseCalendarMinimumDate"]);
                }
                catch
                {
                    return true;
                }
            }
            set
            {
                ViewState["UseCalendarMinimumDate"] = value;
            }
        }

        public int CalendarMinimumDateOffset
        {
            get
            {
                try
                {
                    return Convert.ToInt32(ViewState["CalendarMinimumDateOffset"]);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                ViewState["CalendarMinimumDateOffset"] = value;
            }
        }


        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public override void DataBind()
        {
            base.DataBind();

            int minimumYear = DateTime.Now.Year - ConfigurationFile.CalendarMaximumDate;
            int maximumYear = DateTime.Now.Year - (this.UseCalendarMinimumDate ? ConfigurationFile.CalendarMinimumDate : 0);
            for (int i = maximumYear + this.CalendarMinimumDateOffset; i >= minimumYear; i--)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ddlYear.SelectedIndex = 0;
            ddlMonth.SelectedIndex = 0;
            ddlMonth_SelectedIndexChanged(null, EventArgs.Empty);
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            //read current selected day
            string daySelection = ddlDay.SelectedValue;
            ddlDay.Items.Clear();

            //reload days of month
            DateTime startDate = new DateTime(int.Parse(ddlYear.SelectedValue), int.Parse(ddlMonth.SelectedValue), 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);

            int totalDays = (int)(endDate.Subtract(startDate)).TotalDays + 1;
            for (int i = 1; i <= totalDays; i++)
            {
                ddlDay.Items.Add(new ListItem(string.Format("{0}{1}", i < 10 ? "0" : "", i), i.ToString()));
            }

            //preserve selection if possible
            //if (ddlDay.Items.FindByValue(daySelection) != null)
            //    ddlDay.SelectedValue = daySelection;
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ddlMonth_SelectedIndexChanged(null, EventArgs.Empty);
        }
    }
}