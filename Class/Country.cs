using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Country
    {
        private int id;
        private string name;
        private string nameInArabic;
        private string code;
        private string flagFilePath;

        
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

        
        public string FlagFilePath
        {
            set
            {
                this.flagFilePath = value;
            }
            get
            {
                return this.flagFilePath;
            }
        }
    }
}