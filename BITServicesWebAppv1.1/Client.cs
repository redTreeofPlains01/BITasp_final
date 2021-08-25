using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using BITServicesWebAppv1._1;

namespace BITServicesWebAppv1._1
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Suburb { get; set; }
        public string PostCode { get; set; }
        public string State { get; set; }



        public string Password { get; set; }
        private SQLHelper _db;

        public Client()
        {
            _db = new SQLHelper();
        }
        public int InsertClient()//no parameters are require when you call this
                                   //method, meaning this method is quite cohesive
        {
            //we will complete this method first
            int returnValue = -1;
            string sqlStr = "insert into CLIENT(firstname, lastname,  dob, phone " +
                "email, address, suburb, postcode, state,) " +
                "values(@FName, @LName, @Dob, @Phone, @Email" +
                " @Address, @Suburb, @PostCode, @State)";
            SqlParameter[] objParams;
            objParams = new SqlParameter[10];
            objParams[0] = new SqlParameter("@FName", DbType.String);
            objParams[0].Value = FirstName;
            objParams[1] = new SqlParameter("@LName", DbType.String);
            objParams[1].Value = LastName;
            objParams[9] = new SqlParameter("@Dob", DbType.DateTime);
            objParams[9].Value = DOB;
            objParams[4] = new SqlParameter("@Phone", DbType.String);
            objParams[4].Value = Phone;
            objParams[3] = new SqlParameter("@Email", DbType.String);
            objParams[3].Value = Email;
            objParams[5] = new SqlParameter("@Address", DbType.String);
            objParams[5].Value = Address;
            objParams[6] = new SqlParameter("@Suburb", DbType.String);
            objParams[6].Value = Suburb;
            objParams[7] = new SqlParameter("@PostCode", DbType.String);
            objParams[7].Value = PostCode;
            objParams[8] = new SqlParameter("@State", DbType.String);
            objParams[8].Value = State;

            returnValue = _db.ExecuteNonQuery(sqlStr, objParams);
            return returnValue;

        }
    }
}