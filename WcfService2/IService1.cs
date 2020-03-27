using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<string> LoginUser3(UserDetails3 userInfo);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserDetails3
    {
        string username = string.Empty;
        string password = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        string email = string.Empty;
        int age = 0;
        Int64 telephone = 0;
        bool user = false;
        bool reservationManager = false;

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        [DataMember]
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        [DataMember]
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        [DataMember]
        public Int64 Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        [DataMember]
        public bool User
        {
            get { return user; }
            set { user = value; }
        }
        [DataMember]
        public bool ReservationManager
        {
            get { return reservationManager; }
            set { reservationManager = value; }
        }
    }
}
