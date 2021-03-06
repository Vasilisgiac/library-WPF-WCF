﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DeleteReservation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void DeleteReservation(ReservationDetails3 reservation);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class ReservationDetails3
    {
        string username = string.Empty;
        string title = string.Empty;
        string firstname = string.Empty;
        string lastname = string.Empty;
        string startingdate = string.Empty;
        string endingdate = string.Empty;
        string submitdate = string.Empty;
        bool accepted = false;
        bool aborted = false;


        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Title
        {
            get { return title; }
            set { title = value; }
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
        public string Startingdate
        {
            get { return startingdate; }
            set { startingdate = value; }
        }
        [DataMember]
        public string Endingdate
        {
            get { return endingdate; }
            set { endingdate = value; }
        }
        [DataMember]
        public string Submitdate
        {
            get { return submitdate; }
            set { submitdate = value; }
        }

        [DataMember]
        public bool Accepted
        {
            get { return accepted; }
            set { accepted = value; }
        }
        [DataMember]
        public bool Aborted
        {
            get { return aborted; }
            set { aborted = value; }
        }
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    
}
