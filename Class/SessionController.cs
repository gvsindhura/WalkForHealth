using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication1.Class
{
     public sealed class SessionController
        {
            /// <summary>
            /// read the session value using the passed key
            /// </summary>
            /// <param name="key">identifier to be used to read values from session</param>
            /// <returns>object in session matching the passed key</returns>
            public static object Get(string key)
            {
                HttpSessionState state = HttpContext.Current.Session;
                return state[key];
            }

            /// <summary>
            /// set session value identified by the passed key
            /// </summary>
            /// <param name="key">identifier to be used to set values in session</param>
            /// <param name="value">>object in session mapped to the passed key</param>
            public static void Set(string key, object value)
            {
                HttpContext.Current.Session[key] = value;
            }

            /// <summary>
            /// remove session item using the passed key
            /// </summary>
            /// <param name="key">identifier of session item</param>
            public static void Invalidate(string key)
            {
                HttpSessionState state = HttpContext.Current.Session;

                state.Remove(key);
            }
        }
    }