using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace ReadUsers
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> ReadUsers()
        {
            List<string> users = new List<string>();
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"select * from users where user='true'";
            sql = string.Format(sql);
            MySqlCommand query = new MySqlCommand(sql, db);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read() == true)
            {

                users.Add(reader["username"].ToString());
                users.Add(reader["firstname"].ToString());
                users.Add(reader["lastname"].ToString());
                users.Add(reader["email"].ToString());
                users.Add(reader["age"].ToString());
                users.Add(reader["telephone"].ToString());
            }
            db.Close();
            return users;
        }
    }
}
