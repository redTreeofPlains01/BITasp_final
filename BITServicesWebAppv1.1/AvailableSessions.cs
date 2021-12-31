using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BITServicesWebAppv1._1
{
    public class AvailableSessions
    {
        public  AvailableSessions()
            {

            }

        public static DataTable GetAllAvailableSessions(DateTime date, string desiredstarttime, 
            string desiredendtime, string skillname)
        {
            //string sqlAvailSession = "AllAvailableContrSessions(@desireddate,@desiredstartime," +
            //   "@desiredendTime,@skillname)";

            //SQLHelper objHelper = new SQLHelper("BS");
            SQLHelper objHelper = new SQLHelper();
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@desireddate", DbType.DateTime);
            objParams[0].Value = date;
            objParams[1] = new SqlParameter("@desiredstarttime", DbType.Time);
            objParams[1].Value = desiredstarttime;
            objParams[2] = new SqlParameter("@desiredendtime", DbType.Time);
            objParams[2].Value = desiredendtime;
            objParams[3] = new SqlParameter("@skillname", DbType.String);
            objParams[3].Value = skillname;

            return objHelper.ExecuteSQL("AllAvailableContrSessions", objParams, true);


            //string sqlStr = "SELECT t.timeslotid, t.starttime, a.availabilityid, c.contractorid, " +
            //   "a.availableDate, c.firstname, c.lastname "

            //           + "FROM TimeSlot t, Availability a, Contractor c, PreferredSuburbs ps "

            //          + "WHERE t.timeslotid = a.timeslotid AND c.contractorid = a.contractorid "

            //          + "AND ps.contractorid = c.contractorid AND a.availableDate = '"

            //        + date.ToString("yyyy-MM-dd") + "' AND t.starttime = '"

            //       + time + "' AND ps.suburb = '" + suburb + "' and a.status = 'Available'";

        }
    }
}