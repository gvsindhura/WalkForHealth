using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WebApplication1.Class
{
    [Serializable]
    public class State
    {
        private int id;
        private string name;
        private string code;

        
        public int ID
        {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }

        
        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }
        
        
        public string Code
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