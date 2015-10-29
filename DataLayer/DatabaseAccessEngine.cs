using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.DataLayer
{
    public class DatabaseAccessEngine
    {
        #region Provider (SQLServer) Specific

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationFile.DBConnectionString);
        }

        private static SqlDataAdapter GetDataAdapter(IDbCommand command)
        {
            return new SqlDataAdapter((SqlCommand)command);
        }

        #endregion

        #region Transaction Handling

        /// <summary>
        /// start new transaction from the associated connection
        /// </summary>
        /// <returns>transaction object to be used either to commit or rollback</returns>
        public static SqlTransaction BeginTransaction()
        {
            SqlConnection connection = GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();
            return transaction;
        }

        /// <summary>
        /// commit the passed transaction
        /// </summary>
        /// <param name="transaction">transaction to be committed</param>
        public static void CommitTransaction(SqlTransaction transaction)
        {
            SqlConnection connection = transaction.Connection;

            try
            {
                transaction.Commit();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// rollback the passed transaction
        /// </summary>
        /// <param name="transaction">transaction to be rollbacked</param>
        public static void RollbackTransaction(SqlTransaction transaction)
        {
            SqlConnection connection = transaction.Connection;

            try
            {
                transaction.Rollback();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        #endregion

        #region Execute Stored Procedure

        /// <summary>
        /// execute the passed execution unit using associated command
        /// </summary>
        /// <param name="unit">execution unit mapped to stored procedure and parameters</param>
        public static void ExecuteNonQuery(ExecutionUnit unit)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = unit.StoredProcedureName;
            SqlParameter[] parameters = unit.Parameters;

            if (parameters != null)
            {
                for (int j = 0; j < parameters.Length; j++)
                {
                    command.Parameters.Add(parameters[j]);
                }
            }

            connection.Open();
            try
            {
                //set time out for the command, if not supplied in the connection then use 2 minutes
                //command.CommandTimeout = connection.ConnectionTimeout <= 0 ? 120 : connection.ConnectionTimeout;
                command.CommandTimeout = 120;

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Parameters.Clear();
                command.Dispose(); command = null;

                connection.Close();
                connection.Dispose(); connection = null;
            }
        }

        /// <summary>
        /// Execute execution unit with transaction
        /// </summary>
        /// <param name="unit">execution unit mapped to stored procedure and passing parameters</param>
        /// <param name="transaction">transaction to be used with execution, passing null means to execute the passed unit without transaction</param>
        public static void ExecuteNonQuery(ExecutionUnit unit, SqlTransaction transaction)
        {
            SqlCommand command = null;
            try
            {
                SqlConnection connection = transaction.Connection;
                command = connection.CreateCommand();
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = unit.StoredProcedureName;
                SqlParameter[] parameters = unit.Parameters;

                if (parameters != null)
                {
                    for (int j = 0; j < parameters.Length; j++)
                    {
                        command.Parameters.Add(parameters[j]);
                    }
                }

                //set time out for the command, if not supplied in the connection then use 2 minutes
                //command.CommandTimeout = connection.ConnectionTimeout <= 0 ? 120 : connection.ConnectionTimeout;
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Parameters.Clear();
                command.Dispose(); command = null;
            }
        }

        /// <summary>
        /// Execute execution unit and return the result set as data set
        /// </summary>
        /// <param name="unit">execution unit mapped to stored procedure that returns cursors attached to select statement</param>
        /// <returns>data set with tables that each mapped to a cursor select statement result</returns>
        public static DataSet ExecuteDataSet(ExecutionUnit unit)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = unit.StoredProcedureName;
            SqlParameter[] parameters = unit.Parameters;

            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }

            SqlDataAdapter adapter = GetDataAdapter(command);
            DataSet dataSet = new DataSet();

            connection.Open();
            try
            {
                //set time out for the command, if not supplied in the connection then use 2 minutes
                //command.CommandTimeout = connection.ConnectionTimeout <= 0 ? 120 : connection.ConnectionTimeout;
                command.CommandTimeout = 120;

                adapter.Fill(dataSet);
                return dataSet;
            }
            finally
            {
                command.Parameters.Clear();
                command.Dispose(); command = null;

                connection.Close();
                connection.Dispose(); connection = null;
            }
        }

        /// <summary>
        /// Execute execution unit and return the result set as reader, note that this reader has to be closed from the caller to close the associated connection (i.e. use try-finally)
        /// </summary>
        /// <param name="unit">execution unit mapped to stored procedure that returns cursors attached to select statement</param>
        /// <returns>data reader that reads values from the mapped cursor; using multiple cursors require to use reader.NextResult()</returns>
        public static IDataReader ExecuteDataReader(ExecutionUnit unit)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = unit.StoredProcedureName;
            SqlParameter[] parameters = unit.Parameters;

            for (int i = 0; i < parameters.Length; i++)
            {
                command.Parameters.Add(parameters[i]);
            }

            connection.Open();

            try
            {
                //set time out for the command, if not supplied in the connection then use 2 minutes
                //command.CommandTimeout = connection.ConnectionTimeout <= 0 ? 120 : connection.ConnectionTimeout;
                command.CommandTimeout = 120;

                IDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);

                command.Dispose(); command = null;

                return reader;
            }
            catch (Exception ex)
            {
                connection.Close(); connection = null;
                throw ex;
            }
        }

        #endregion

        #region Parse Reader Values

        /// <summary>
        /// Check if the passed column is null in the passed reader result set for the current row
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to check nullability of its value</param>
        /// <returns>true if null otherwise false</returns>
        public static bool IsNull(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read string value of a column in current row of a reader
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>string value of passed column</returns>
        public static string GetString(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : reader.GetString(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable integer value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>nullable integer value of passed column</returns>
        public static int? GetNullableInt32(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (int?)reader.GetInt32(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read integer value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>integer value of passed column</returns>
        public static int GetInt32(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? -1 : reader.GetInt32(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read long integer value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>long integer value of passed column</returns>
        public static long GetInt64(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? -1 : reader.GetInt64(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable long integer value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>nullable long integer value of passed column</returns>
        public static long? GetNullableInt64(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (long?)reader.GetInt64(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read boolean value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its value</param>
        /// <returns>boolean value of passed column</returns>
        public static bool GetBoolean(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? false : reader.GetBoolean(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable boolean value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read its values</param>
        /// <returns>boolean value of passed column</returns>
        public static bool? GetNullableBoolean(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (bool?)reader.GetBoolean(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read double value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it value</param>
        /// <returns>double value of passed column</returns>
        public static double GetDouble(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? -1.0 : reader.GetDouble(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable long integer value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it values</param>
        /// <returns>nullable long integer value of passed column</returns>
        public static double? GetNullableDouble(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (double?)reader.GetDouble(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read decimal value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it value</param>
        /// <returns>decimal value of passed column</returns>
        public static decimal GetDecimal(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? -1 : reader.GetDecimal(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable decimal value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it value</param>
        /// <returns>nullable decimal value of passed column</returns>
        public static decimal? GetNullableDecimal(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (decimal?)reader.GetDecimal(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read datetime value of a column in current row of a reader (to be used with columns that not allow null)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it value</param>
        /// <returns>datetime value of passed column</returns>
        public static DateTime GetDateTime(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        /// <summary>
        /// read nullable datetime value of a column in current row of a reader (to be used with allow null columns)
        /// </summary>
        /// <param name="reader">reader object on a current row</param>
        /// <param name="columnName">column to read it value</param>
        /// <returns>nullable datetime value of passed column</returns>
        public static DateTime? GetNullableDateTime(IDataReader reader, string columnName)
        {
            return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : (DateTime?)reader.GetDateTime(reader.GetOrdinal(columnName));
        }

        #endregion
    }
}