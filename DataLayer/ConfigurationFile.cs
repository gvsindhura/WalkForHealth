using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace WebApplication1.DataLayer
{
    public class ConfigurationFile
    {
        #region Database Connection String

        public static string DBConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        #endregion

        public static int CalendarMinimumDate
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["CalendarMinimumDate"]);
                }
                catch
                {
                    return 0;
                }
            }
        }

        public static int CalendarMaximumDate
        {
            get
            {
                try
                {
                    return int.Parse(ConfigurationManager.AppSettings["CalendarMaximumDate"]);
                }
                catch
                {
                    return 100;
                }
            }
        }
    }
}