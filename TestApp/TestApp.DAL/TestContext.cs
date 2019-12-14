using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DAL
{
    public class TestContext : IDisposable
    {
        #region Variables 

        public SqlConnection sqlConnection = null;
        SqlCommand sqlCommand = null;
        public string cConnectionstring = ConfigurationManager.ConnectionStrings["AdventureWorks"].ToString();
        #endregion


        public DataSet ExecuteProcedure(string commandName, List<SqlParameter> paramCollection)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlConnection = new SqlConnection(cConnectionstring);
                sqlCommand = new SqlCommand(commandName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter sqlParam in paramCollection)
                {
                    sqlCommand.Parameters.Add(sqlParam);
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(ds);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return ds;
        }

        public DataSet ExecuteQuery(string commandName)
        {
            DataSet ds = new DataSet();
            try
            {
                sqlConnection = new SqlConnection(cConnectionstring);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(commandName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCommand;
                da.Fill(ds);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return ds;
        }

        public int ExecuteNonQuery(string commandName, List<SqlParameter> paramCollection)
        {
            int rowAffected = 0;
            try
            {
                sqlConnection = new SqlConnection(cConnectionstring);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(commandName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (SqlParameter sqlParam in paramCollection)
                {
                    sqlCommand.Parameters.Add(sqlParam);
                }
                rowAffected = sqlCommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return rowAffected;
        }

        public SqlDataReader ExecuteReader(string commandName)
        {
            SqlDataReader dr;
            try
            {
                sqlConnection = new SqlConnection(cConnectionstring);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(commandName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                dr = sqlCommand.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return dr;
        }

        public void Dispose()
        {

        }
    }
}
