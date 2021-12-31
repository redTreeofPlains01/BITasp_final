using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BITServicesWebAppv1._1
{
    public class SQLHelper
    {
        private string _conn;
        public SQLHelper()
        {
            _conn = ConfigurationManager.ConnectionStrings["BS"].ConnectionString;
            //interpretation: get the BS database and passs into configurationManager method{ConfigurationManager.ConnectionStrings["BS"]} ==> then get the string into c#connectionstring
        }

        public DataTable ExecuteSQL(string sql, SqlParameter[] sqlParameters = null, bool storedProcedure = false)
        {
            SqlConnection dbConnection = new SqlConnection(_conn);//makes connection to databse only -no table yet- not open yet "pipeline"
            DataTable dataTable = new DataTable();//make a empty conatainer(datatable)
            //*****SqlCommand in Sql Client language it is any query or stored procedure

            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);//IMP-up to here there was only connection to db-Now, dbCommand(the commander as name implies) is what makes use of connection(SqlConnection above) to 'execute the command using sql statement ' and find the table/s
            if (storedProcedure == true)//id query is type storeprocedure-then change the type here becos default is normal query
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (sqlParameters != null)//if parameters exist put it in a list and loop and add all parameters to the query
            {
                AddParameters(dbCommand, sqlParameters);//important line-here it it "adding the parameters" (e.g where state = 'nsw' and postocde= '002020') TO THE dbCommand// Note adding parameters uses list{SqlParaeters} to add any number of parameters and collect it using a loop in methods at bottom of page: for (int i = 0; i < sqlParameters.Length; i++)
                //{objCommand.Parameters.Add(sqlParameters[i]);
            }

            //==================Up to here is "setting up"  Command (to execute a query):dbCommand NOW execute using TRY/Catch
            try//note try is where its actually retrieving to the database layer info and where error can most occur not everything// NOTE!- everything up to there is "setting up" "dbCommand"-NOW you can execute(ExecuteReader)-that is execute query such as: delete table etc,create,add table etc...
            {
                dbConnection.Open(); //open connection-was connected but not open
                SqlDataReader drResults = dbCommand.ExecuteReader(CommandBehavior.CloseConnection);//carries on from {..SqlCommand dbCommand = new SqlCommand(sql, dbConnection)} which has "already" been connected to the sql(selct * from client); Now(this line) using the open connection e.g dbCommand.ExecuteReader "brings in" all clients say 5 clients(selct * from cust) from database using {sql} and {dbConnection}
                //what it brings back is type SQLDatareader which is a 5 client -set of 5 records -strings(?)
                dataTable.Load(drResults); //here those sets{drResults-which is still type SqldataReader} are loaded onto a dataTable(datatable memeory). The benefit is that datatable has rows and colums just like database table. So now it has become 5 rows not 5 sets
                return dataTable; //return to where needed.-e.g then "set to grid" or read something from it...what ever and wherever it is being called..Datable is the end result you want and now you can connect to wpf or asp.net grid or read it or manipulate it...
            }
            catch (SqlException ex) // more specialised exceptions to be caught first
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)//Remember in the framework Exception is the base class for all specialised exceptions so in multiple catch staements this generic exception must be the last one to catch 
            {
                throw new Exception(ex.Message);
            }
        }

        //Refactoring concept where all the physical database related functionalities are separated out to a different class.
        public int ExecuteNonQuery(string sql, SqlParameter[] sqlParameters = null,
            bool storedProcedure = false)
        {
            int returnValue = -1;
            SqlConnection dbConnection = new SqlConnection(_conn);
            //SqlCommand in Sql Client language it is any query or stored procedure
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            if (sqlParameters != null) //if parameters exist put it in a list and loop and add all parameters to the query
            {
                AddParameters(dbCommand, sqlParameters);
            }
            if (storedProcedure) //if query is type storeprocedure-then change the type here becos default is normal query
            {
                dbCommand.CommandType = CommandType.StoredProcedure; //important line
            }

            try
            {
                dbConnection.Open();
                returnValue = dbCommand.ExecuteNonQuery();
                return returnValue;

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        private void AddParameters(SqlCommand objCommand, SqlParameter[] sqlParameters)
        {
            for (int i = 0; i < sqlParameters.Length; i++)
            {
                objCommand.Parameters.Add(sqlParameters[i]);
            }
        }
    }
}
