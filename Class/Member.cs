using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{

    public class Member
    {

        public int ID
        {
            set;
            get;
        }

        public string Name
        {
            set;
            get;
        }


        public string FirstName
        {
            set;
            get;
        }


        public string LastName
        {
            set;
            get;
        }


        public string Title
        {
            set;
            get;
        }


        public string UserName
        {
            set;
            get;
        }


        public string Password
        {
            set;
            get;
        }


        public DateTime BirthDate
        {
            set;
            get;
        }


        public int Age
        {
            set;
            get;
        }


        public bool IsChild
        {
            set;
            get;
        }


        public bool IsMaleGender
        {
            set;
            get;
        }


        public Country Nationality
        {
            set;
            get;
        }


        public string PersonalID
        {
            set;
            get;
        }


        public string ActivityLevel
        {
            set;
            get;
        }


        public string ExerciseIntensityLevel
        {
            set;
            get;
        }


        public bool Status
        {
            set;
            get;
        }


        public bool IsWaitlisted
        {
            set;
            get;
        }


        public DateTime? WaitlistStatusDate
        {
            set;
            get;
        }


        //public Community Community
        //{
        //    set;
        //    get;
        //}


        //public WalkingStepBudge WalkingStepBudge
        //{
        //    set;
        //    get;
        //}


        //public WalkingStepLevel WalkingStepLevel
        //{
        //    set;
        //    get;
        //}


        public int WalkingStepBudgeCount
        {
            set;
            get;
        }


        public int WalkingStepBudgeAverageSteps
        {
            set;
            get;
        }


        public string CRMUpdateStatus
        {
            set;
            get;
        }


        //public MemberPedometerIssue LastMemberPedometerIssue
        //{
        //    set;
        //    get;
        //}


        public MemberActualFitnessValue LastMemberActualFitnessValue
        {
            set;
            get;
        }


        //public MemberActualFitnessValue LastMemberHealthCheck
        //{
        //    set;
        //    get;
        //}


        //public Schedule Schedule
        //{
        //    set;
        //    get;
        //}


        public MemberPedometerReading MemberPedometerReadingSummary
        {
            set;
            get;
        }



        public string Address
        {
            set;
            get;
        }


        public Int32 State
        {
            set;
            get;
        }


        public string ZipCode
        {
            set;
            get;
        }


        public string HomePhone
        {
            set;
            get;
        }


        public string MobilePhone
        {
            set;
            get;
        }


        public string AlternativePhone
        {
            set;
            get;
        }


        public string Email
        {
            set;
            get;
        }


        public bool NotifyBySMS
        {
            set;
            get;
        }


        public bool NotifyByEmail
        {
            set;
            get;
        }


        public string PhotoFilePath
        {
            set;
            get;
        }


        public bool IsHealthCheckInterested { get; set; }




        public DateTime RegistrationDate
        {
            set;
            get;
        }


        public string MembershipNumber
        {
            set;
            get;
        }


        //public string PersonalID
        //{
        //    set;
        //    get;
        //}


        //public string Email
        //{
        //    set;
        //    get;
        //}


        //public bool? IsMaleGender
        //{
        //    set;
        //    get;
        //}


        public int? NationalityID
        {
            set;
            get;
        }


        public bool? NationalityFlag
        {
            set;
            get;
        }


        //public int? Age
        //{
        //    set;
        //    get;
        //}


        //public string MobilePhone
        //{
        //    set;
        //    get;
        //}


        //public bool? Status
        //{
        //    set;
        //    get;
        //}


        //public bool? CRMUpdateStatus
        //{
        //    set;
        //    get;
        //}


        public string CRMID
        {
            set;
            get;
        }


        public int? WaitlistedType
        {
            set;
            get;
        }


        public DateTime? WaitlistStatusChangeStartDate
        {
            set;
            get;
        }


        public DateTime? WaitlistStatusChangeEndDate
        {
            set;
            get;
        }


        public bool? PedometerIssued
        {
            set;
            get;
        }


        public bool? IsActive
        {
            set;
            get;
        }


        public int? CommunityID
        {
            set;
            get;
        }


        public int? ScheduleID
        {
            set;
            get;
        }


        public int? WalkingStepCalculatorTypeID
        {
            set;
            get;
        }
    }
}