using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace BookAvailability
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> BookAvailability(string book, string startingdate, string endingdate)
        {
            List<string> dates = new List<string>();
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''; Allow Zero Datetime=True ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"select startingdate,endingdate,quantity from reservations where title='{2}' and accepted='True' and ( (startingdate <= '{0}' and endingdate >= '{0}' and endingdate <= '{1}') or (startingdate >= '{0}' and endingdate <= '{1}') or (startingdate >= '{0}' and startingdate <= '{1}' and endingdate >= '{1}') ) order by submitdate";
            sql = string.Format(sql, startingdate, endingdate, book);
            MySqlCommand query = new MySqlCommand(sql, db);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read() == true)
            {
                dates.Add(reader["startingdate"].ToString());
                dates.Add(reader["endingdate"].ToString());
                dates.Add(reader["quantity"].ToString());
            }
            db.Close();
            return dates;
        }
    }
}
