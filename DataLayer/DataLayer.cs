using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ServiceModel;
using System.Data.SqlClient;
using WebApplication1.Class;

namespace WebApplication1.DataLayer
{
    public class DataLayer
    {
        public List<Country> GetCountries(string sortExp)
        {
            ExecutionUnit unit = new ExecutionUnit("GetCountries");
            unit.AddParameter("@SortExpression", SqlDbType.VarChar, ParameterDirection.Input, sortExp);

            List<Country> countries = new List<Country>();
            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                while (reader.Read())
                {
                    Country country = new Country();
                    country.ID = DatabaseAccessEngine.GetInt32(reader, "ID");
                    country.Name = DatabaseAccessEngine.GetString(reader, "Name");
                    country.Code = DatabaseAccessEngine.GetString(reader, "Code");
                    country.FlagFilePath = DatabaseAccessEngine.GetString(reader, "FlagFilePath");

                    countries.Add(country);
                }
            }

            return countries;
        }

        public List<State> GetStates(string sortExp)
        {
            ExecutionUnit unit = new ExecutionUnit("GetStates");
            unit.AddParameter("@SortExpression", SqlDbType.VarChar, ParameterDirection.Input, sortExp);

            List<State> states = new List<State>();
            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                while (reader.Read())
                {
                    State state = new State();
                    state.ID = DatabaseAccessEngine.GetInt32(reader, "ID");
                    state.Name = DatabaseAccessEngine.GetString(reader, "Name");
                    states.Add(state);
                }
            }

            return states;
        }

        public Member AuthenticateMember(string userName, string password)
        {
            ExecutionUnit unit = new ExecutionUnit("AuthenticateMember");

            unit.AddParameter("@UserName", SqlDbType.VarChar, ParameterDirection.Input, userName);
            unit.AddParameter("@Password", SqlDbType.VarChar, ParameterDirection.Input, password);

            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                Member member = null;
                while (reader.Read())
                {
                    member = new Member();
                    member.ID = DatabaseAccessEngine.GetInt32(reader, "ID");
                    member.Status = DatabaseAccessEngine.GetBoolean(reader, "Status");
                    member.Password = DatabaseAccessEngine.GetString(reader, "Password");
                    member.UserName = DatabaseAccessEngine.GetString(reader, "Username");
                    member.FirstName = DatabaseAccessEngine.GetString(reader, "FirstName");
                    member.LastName = DatabaseAccessEngine.GetString(reader, "LastName");
                    member.BirthDate = DatabaseAccessEngine.GetDateTime(reader, "BirthDate");
                    member.Age = DatabaseAccessEngine.GetInt32(reader, "Age");
                    member.IsChild = member.Age <= Constants.ADULT_AGE;
                    member.PhotoFilePath = DatabaseAccessEngine.GetString(reader, "PhotoFilePath");
                    member.Email = DatabaseAccessEngine.GetString(reader, "Email");
                    member.IsMaleGender = DatabaseAccessEngine.GetBoolean(reader, "Gender");
                    member.NotifyBySMS = DatabaseAccessEngine.GetBoolean(reader, "NotifyBySMS");
                    member.NotifyByEmail = DatabaseAccessEngine.GetBoolean(reader, "NotifyByEmail");
                    member.MobilePhone = DatabaseAccessEngine.GetString(reader, "MobilePhone");
                    member.HomePhone = DatabaseAccessEngine.GetString(reader, "HomePhone");
                    member.State = DatabaseAccessEngine.GetInt32(reader, "State");
                    member.ZipCode = DatabaseAccessEngine.GetString(reader, "ZipCode");
                    member.Address = DatabaseAccessEngine.GetString(reader, "Address");
                    member.ActivityLevel = DatabaseAccessEngine.GetString(reader, "ActivityLevel");
                    member.ExerciseIntensityLevel = DatabaseAccessEngine.GetString(reader, "ExerciseIntensityLevel");
                    member.RegistrationDate = DatabaseAccessEngine.GetDateTime(reader, "RegistrationDate");

                    member.Nationality = new Country();
                    member.Nationality.ID = DatabaseAccessEngine.GetInt32(reader, "NationalityCountryID");
                    member.Nationality.Name = DatabaseAccessEngine.GetString(reader, "NationalityCountryName");
                    member.Nationality.FlagFilePath = DatabaseAccessEngine.GetString(reader, "NationalityCountryFlagFilePath");
                    
                    break;
                }
                if (member == null)
                    return null;

                return member;
            }
        }

        public Int64 AddPedometerReading(MemberPedometerReading reading)
        {            
            //prepare execution unit parameters and invoke stored procedure
            ExecutionUnit unit = new ExecutionUnit("AddPedometerReading");
            unit.AddParameter("@MemberID", SqlDbType.Int, ParameterDirection.Input, reading.Member.ID);
            unit.AddParameter("@ModelName", SqlDbType.VarChar, ParameterDirection.Input, reading.ModelName);
            unit.AddParameter("@SerialNumber", SqlDbType.NVarChar, ParameterDirection.Input, reading.SerialNumber);
            unit.AddParameter("@ReadingDate", SqlDbType.DateTime, ParameterDirection.Input, reading.ReadingDate);
            unit.AddParameter("@Steps", SqlDbType.BigInt, ParameterDirection.Input, reading.Steps);
            unit.AddParameter("@AerobicSteps", SqlDbType.BigInt, ParameterDirection.Input, reading.AerobicSteps);
            unit.AddParameter("@AerobicDuration", SqlDbType.Decimal, ParameterDirection.Input, reading.AerobicDuration);
            unit.AddParameter("@Distance", SqlDbType.Decimal, ParameterDirection.Input, reading.Distance);
            unit.AddParameter("@FatBurn", SqlDbType.Decimal, ParameterDirection.Input, reading.FatBurn);
            unit.AddParameter("@Calories", SqlDbType.Decimal, ParameterDirection.Input, reading.Calories);
          //  unit.AddParameter("@Status", SqlDbType.Bit, ParameterDirection.Input, 1);
            IDbDataParameter totalStepsParam = unit.AddParameter("@TotalSteps", SqlDbType.BigInt, ParameterDirection.Output, null);
                        
            DatabaseAccessEngine.ExecuteNonQuery(unit);

            reading.TotalSteps = Convert.ToInt32(totalStepsParam.Value);
                       
            //return total steps
            return reading.TotalSteps;
        }

        public int RegisterMember(Member member)
        {
            ////calculate fitness value parameters
            //decimal bmi, bodyFat;
            //Helper.CalculateFitnessParameters(fitnessValue.Weight, fitnessValue.Height, (int)((TimeSpan)DateTime.Now.Subtract(member.BirthDate)).TotalDays / 365, member.IsMaleGender, out bmi, out bodyFat);
            //fitnessValue.BMI = bmi; fitnessValue.BodyFat = bodyFat;

            //prepare execution unit parameters and invoke stored procedure
            ExecutionUnit unit = new ExecutionUnit("RegisterMember");
            unit.AddParameter("@UserName", SqlDbType.VarChar, ParameterDirection.Input, member.UserName);
            unit.AddParameter("@Password", SqlDbType.VarChar, ParameterDirection.Input, member.Password);
            unit.AddParameter("@FirstName", SqlDbType.NVarChar, ParameterDirection.Input, member.FirstName);
            unit.AddParameter("@LastName", SqlDbType.NVarChar, ParameterDirection.Input, member.LastName);
            unit.AddParameter("@BirthDate", SqlDbType.DateTime, ParameterDirection.Input, member.BirthDate);
            unit.AddParameter("@Email", SqlDbType.VarChar, ParameterDirection.Input, member.Email);
            unit.AddParameter("@Nationality", SqlDbType.Int, ParameterDirection.Input, member.Nationality.ID);
            unit.AddParameter("@Gender", SqlDbType.Bit, ParameterDirection.Input, member.IsMaleGender ? 1 : 0);
            unit.AddParameter("@Status", SqlDbType.Bit, ParameterDirection.Input, 1);

            unit.AddParameter("@NotifyBySMS", SqlDbType.Bit, ParameterDirection.Input, member.NotifyBySMS ? 1 : 0);
            unit.AddParameter("@NotifyByEmail", SqlDbType.Bit, ParameterDirection.Input, member.NotifyByEmail ? 1 : 0);

            unit.AddParameter("@MobilePhone", SqlDbType.VarChar, ParameterDirection.Input, member.MobilePhone);
            unit.AddParameter("@HomePhone", SqlDbType.VarChar, ParameterDirection.Input, member.HomePhone);

            unit.AddParameter("@State", SqlDbType.VarChar, ParameterDirection.Input, member.State);
            unit.AddParameter("@ZipCode", SqlDbType.VarChar, ParameterDirection.Input, member.ZipCode);
            unit.AddParameter("@Address", SqlDbType.VarChar, ParameterDirection.Input, member.Address);
            unit.AddParameter("@RegistrationDate", SqlDbType.DateTime, ParameterDirection.Input, DateTime.Now);

            IDbDataParameter memberIDParam = unit.AddParameter("@MemberID", SqlDbType.Int, ParameterDirection.Output, null);
            IDbDataParameter errorCodeParam = unit.AddParameter("@ErrorCode", SqlDbType.Int, ParameterDirection.Output, null);

            DatabaseAccessEngine.ExecuteNonQuery(unit);

            //check if any unique check failed
            int errorCode = Convert.ToInt32(errorCodeParam.Value);
            if (errorCode != 0)
            {
                ApplicationFault fault = new ApplicationFault(errorCode);
                throw new FaultException<ApplicationFault>(fault, "Duplicate Member");
            }

            member.ID = Convert.ToInt32(memberIDParam.Value);

            //return generated member id
            return member.ID;
        }

        //reports
        public Dictionary<string, int> MemberChart_Gender(int? state, int? fromAge, int? toAge)
        {
            ExecutionUnit unit = new ExecutionUnit("MemberChart_Gender");
            unit.AddParameter("@State", SqlDbType.Int, ParameterDirection.Input, state);
            unit.AddParameter("@FromAge", SqlDbType.Int, ParameterDirection.Input, fromAge);
            unit.AddParameter("@ToAge", SqlDbType.Int, ParameterDirection.Input, toAge);

            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                Dictionary<string, int> summarybyGender = new Dictionary<string, int>();
                while (reader.Read())
                {
                    summarybyGender.Add(DatabaseAccessEngine.GetString(reader, "Gender"), DatabaseAccessEngine.GetInt32(reader, "MemberCount"));
                }
                return summarybyGender;
            }
        }

        public Dictionary<State, int> MemberChart_State(bool? gender, int? fromAge, int? toAge)
        {
            ExecutionUnit unit = new ExecutionUnit("MemberChart_State");
            unit.AddParameter("@Gender", SqlDbType.Bit, ParameterDirection.Input, gender.HasValue ? (object)(gender.Value ? 1 : 0) : null);
            unit.AddParameter("@FromAge", SqlDbType.Int, ParameterDirection.Input, fromAge);
            unit.AddParameter("@ToAge", SqlDbType.Int, ParameterDirection.Input, toAge);

            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                Dictionary<State, int> summarybyState = new Dictionary<State, int>();
                while (reader.Read())
                {
                    State country = new State();
                    country.ID = DatabaseAccessEngine.GetInt32(reader, "ID");
                    country.Name = DatabaseAccessEngine.GetString(reader, "Name");

                    summarybyState.Add(country, DatabaseAccessEngine.GetInt32(reader, "MemberCount"));
                }

                return summarybyState;
            }
        }

        public Dictionary<int, int> MemberChart_Age(int? state, bool? gender)
        {
            ExecutionUnit unit = new ExecutionUnit("MemberChart_Age");
            unit.AddParameter("@State", SqlDbType.Int, ParameterDirection.Input, state);
            unit.AddParameter("@Gender", SqlDbType.Bit, ParameterDirection.Input, gender.HasValue ? (object)(gender.Value ? 1 : 0) : null);

            using (IDataReader reader = DatabaseAccessEngine.ExecuteDataReader(unit))
            {
                Dictionary<int, int> summarybyAge = new Dictionary<int, int>();
                while (reader.Read())
                {
                    summarybyAge.Add(DatabaseAccessEngine.GetInt32(reader, "Age"), DatabaseAccessEngine.GetInt32(reader, "MemberCount"));
                }
                return summarybyAge;
            }
        }
    }
}