using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class MemberPedometerReading
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

        
        public string ModelName
        {
            set;
            get;
        }

        
        public string SerialNumber
        {
            set;
            get;
        }

        
        public DateTime ReadingDate
        {
            set;
            get;
        }

        
        public Int64 Steps
        {
            set;
            get;
        }

        
        public Int64 AerobicSteps
        {
            set;
            get;
        }

        
        public decimal AerobicDuration
        {
            set;
            get;
        }

        
        public decimal Distance
        {
            set;
            get;
        }

        
        public decimal FatBurn
        {
            set;
            get;
        }

        
        public decimal Calories
        {
            set;
            get;
        }

        public Int64 TotalSteps
        {
            set;
            get;
        }
    }
}