using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Threading;

namespace UserReservations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> UserReservationsManage(string username)
        {
            List<string> reservations = new List<string>();
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''; Allow Zero Datetime=True ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"select * from reservations where username = '{0}' order by submitdate";
            sql = string.Format(sql, username);
            MySqlCommand query = new MySqlCommand(sql, db);
            MySqlDataReader reader = query.ExecuteReader();
            
            while (reader.Read() == true)
            {
                reservations.Add(reader["title"].ToString());
                reservations.Add(reader["startingdate"].ToString());
                reservations.Add(reader["endingdate"].ToString());
                reservations.Add(reader["submitdate"].ToString());
                reservations.Add(reader["quantity"].ToString());
                reservations.Add(reader["accepted"].ToString());
                reservations.Add(reader["aborted"].ToString());
            }
            db.Close();
            return reservations;
        }
    }
}
