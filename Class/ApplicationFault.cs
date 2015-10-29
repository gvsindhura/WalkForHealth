using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{    
    public class ApplicationFault
    {
        public ApplicationFault()
            : this(0)
        { }

        public ApplicationFault(int code)
        {
            this.code = code;
        }

        private int code;
        
        public int Code
        {
            set
            {
                this.code = value;
            }
            get
            {
                return this.code;
            }
        }
    }
}