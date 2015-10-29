using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class MemberActualFitnessValue
    {
        
        public int ID
        {
            set;
            get;
        }

        
        public Member Member
        {
            set;
            get;
        }

        
        public DateTime LogDate
        {
            set;
            get;
        }

        
        //public OperatingPoint OperatingPoint
        //{
        //    set;
        //    get;
        //}

        
        public decimal Height
        {
            set;
            get;
        }

        
        public decimal Weight
        {
            set;
            get;
        }

        
        public decimal BMI
        {
            set;
            get;
        }

        
        public decimal BodyFat
        {
            set;
            get;
        }

        
        public decimal? BloodPressureSystolic
        {
            set;
            get;
        }

        
        public decimal? BloodPressureDiastolic
        {
            set;
            get;
        }

        
        public decimal? BloodSugar
        {
            set;
            get;
        }

        
        //public User User
        //{
        //    set;
        //    get;
        //}
    }
}