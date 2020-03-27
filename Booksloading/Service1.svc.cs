using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;  

namespace Booksloading
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<string> BookLoading()
        {
            List<string> user = new List<string>();
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = '' ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"select title from books";
            sql = string.Format(sql);
            MySqlCommand query = new MySqlCommand(sql, db);
            MySqlDataReader reader = query.ExecuteReader();

            while (reader.Read() == true)
            {
                user.Add(reader["title"].ToString());
            }
            db.Close();
            return user;
        }  
    }
}
