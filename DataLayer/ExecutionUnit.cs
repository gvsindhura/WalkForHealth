using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.DataLayer
{
    public class ExecutionUnit
    {
        /// <summary>
        /// must to have stored procedure in unit constructor
        /// </summary>
        /// <param name="storedProcedureName">name of stored procedure</param>
        public ExecutionUnit(string storedProcedureName)
        {
            this.storedProcedureName = storedProcedureName;
            this.storedProcedureParameterList = new List<SqlParameter>();
            this.storedProcedureParameterNameList = new List<string>();
        }

        #region Properties

        private string storedProcedureName;
        public string StoredProcedureName
        {
            set
            {
                storedProcedureName = value;
            }
            get
            {
                return storedProcedureName;
            }
        }

        private List<SqlParameter> storedProcedureParameterList;
        private List<string> storedProcedureParameterNameList;

        internal SqlParameter[] Parameters
        {
            get
            {
                return storedProcedureParameterList.ToArray();
            }
        }

        #endregion

        #region Indexer

        public IDataParameter this[int index]
        {
            get
            {
                return storedProcedureParameterList[index];
            }
        }

        public IDataParameter this[string parameterName]
        {
            get
            {
                return storedProcedureParameterList[storedProcedureParameterNameList.IndexOf(parameterName)];
            }
        }

        #endregion

        #region Parameters Handling (Sql Specific)

        /// <summary>
        /// add stored procedure parameter to the execution unit list of parameters
        /// </summary>
        /// <param name="name">parameter name match the one on database stored procedure; note the order should not match between here and the sp</param>
        /// <param name="type">Sql data type of the parameter</param>
        /// <param name="direction">In, Out or In/Out direction</param>
        /// <param name="value">initial value for in-direction params; to be used to read the out-direction params</param>
        /// <returns>the created parameter</returns>
        public SqlParameter AddParameter(string name, SqlDbType type, ParameterDirection direction, object value)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            parameter.Value = value == null ? DBNull.Value : value;


            storedProcedureParameterList.Add(parameter);
            storedProcedureParameterNameList.Add(parameter.ParameterName);

            return parameter;
        }

        /// <summary>
        /// add stored procedure parameter to the execution unit list of parameters (special handling of typed array param; refer to custom array)
        /// </summary>
        /// <param name="name">parameter name match the one on database stored procedure; note the order should not match between here and the sp</param>
        /// <param name="type">Sql data type of the parameter</param>
        /// <param name="direction">In, Out or In/Out direction</param>
        /// <param name="value">initial value for in-direction params; to be used to read the out-direction params</param>
        /// <param name="arrayTypeName">database type name mapped to this parameter (e.g. Integer_Array)</param>
        /// <returns>the created parameter</returns>
        public SqlParameter AddParameter(string name, SqlDbType type, ParameterDirection direction, object value, string arrayTypeName)
        {
            SqlParameter parameter = new SqlParameter(name, type);
            parameter.Direction = direction;
            parameter.UdtTypeName = arrayTypeName;
            parameter.Value = value == null ? DBNull.Value : value;

            storedProcedureParameterList.Add(parameter);
            storedProcedureParameterNameList.Add(parameter.ParameterName);

            return parameter;
        }

        #endregion
    }
}