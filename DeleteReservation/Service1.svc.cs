using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace DeleteReservation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public void DeleteReservation(ReservationDetails3 reservation)
        {
            string conString = @"Server = localhost; Port = 3306; Database = bibliothiki; Uid = root; Pwd = ''; Allow Zero Datetime=True ";
            MySqlConnection db = new MySqlConnection(conString);
            db.Open();
            string sql = @"delete from reservations where title='{0}' and username='{1}' and firstname='{2}' and lastname='{3}' and startingdate='{4}' and endingdate='{5}' and submitdate='{6}' and accepted='{7}' and aborted='{8}'";
            sql = string.Format(sql, reservation.Title, reservation.UserName, reservation.Firstname, reservation.Lastname, reservation.Startingdate, reservation.Endingdate, reservation.Submitdate, reservation.Accepted, reservation.Aborted);
            MySqlCommand query = new MySqlCommand(sql, db);
            query.ExecuteNonQuery();
            db.Close();
        }
    }
}
