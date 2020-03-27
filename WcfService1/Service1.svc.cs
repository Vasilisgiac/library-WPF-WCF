using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;  

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void RegistrationUser(UserDetails userInfo)
        {
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = '' ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"insert into users(username,password,firstname,lastname,email,age,telephone,user,reservationManager)
                           values('{0}','{1}', '{2}', '{3}','{4}','{5}','{6}','{7}','{8}')";
            sql = string.Format(sql, userInfo.UserName, userInfo.Password, userInfo.Firstname, userInfo.Lastname, userInfo.Email, userInfo.Age, userInfo.Telephone, userInfo.User, userInfo.ReservationManager);
            MySqlCommand query = new MySqlCommand(sql, db);
            query.ExecuteNonQuery();
            db.Close();
        }  
    }
}
