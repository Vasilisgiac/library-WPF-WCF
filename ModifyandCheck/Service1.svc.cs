using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace ModifyandCheck
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void Modifyandcheck(ReservationDetails2 reservation1, ReservationDetails2 reservation2)
        {
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''; Allow Zero Datetime=True ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"update reservations set startingdate='{0}', endingdate='{1}', accepted='{2}', aborted='{3}' where title='{4}' and username='{5}' and firstname='{6}' and lastname='{7}' and startingdate='{8}'and endingdate='{9}' and submitdate='{10}' and accepted='{11}'and aborted='{12}'";
            sql = string.Format(sql, reservation1.Startingdate, reservation1.Endingdate, reservation1.Accepted, reservation1.Aborted, reservation2.Title, reservation2.UserName, reservation2.Firstname, reservation2.Lastname, reservation2.Startingdate, reservation2.Endingdate, reservation2.Submitdate, reservation2.Accepted, reservation2.Aborted);
            MySqlCommand query = new MySqlCommand(sql, db);
            query.ExecuteNonQuery();
            db.Close();
        }
    }
}
