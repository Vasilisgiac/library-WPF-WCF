using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace NamesforReservation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> ReadNames(string username)
        {
            List<string> names = new List<string>();
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"select firstname,lastname from users where username='{0}'";
            sql = string.Format(sql, username);
            MySqlCommand query = new MySqlCommand(sql, db);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read() == true)
            {
                names.Add(reader["firstname"].ToString());
                names.Add(reader["lastname"].ToString());
            }
            db.Close();
            return names;
        }
    }
}
