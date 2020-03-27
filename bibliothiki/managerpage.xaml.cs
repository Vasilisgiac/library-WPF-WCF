using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using bibliothiki.AllReservationsManageReference;
using bibliothiki.BookAvailabilityReference;
using bibliothiki.ReadUsersReference;
using bibliothiki.ModifyAndCheckReference;
using System.Net.Mail;
using System.Net;


namespace bibliothiki
{
    /// <summary>
    /// Interaction logic for managerpage.xaml
    /// </summary>
    public partial class managerpage : Window
    {

        AllReservationsManageReference.Service1Client obj = new AllReservationsManageReference.Service1Client();
        BookAvailabilityReference.Service1Client obj2 = new BookAvailabilityReference.Service1Client();
        ReadUsersReference.Service1Client obj3 = new ReadUsersReference.Service1Client();
        ModifyAndCheckReference.Service1Client obj4 = new ModifyAndCheckReference.Service1Client();
        CopiesReference.Service1Client obj5 = new CopiesReference.Service1Client();
        EmailReference.Service1Client obj6 = new EmailReference.Service1Client();
        public class MyItem
        {
            public string Title { get; set; }
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string StartingDate { get; set; }
            public string ReturningDate { get; set; }
            public string SubmitDate { get; set; }
            public int Quantity { get; set; }
            public bool Accepted { get; set; }
            public bool Aborted { get; set; }
        }
        public class MyItem2
        {
          
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
            public Int64 Telephone { get; set; }
        }

        public managerpage()
        {
            InitializeComponent();
            
            txt2.Text = App.Current.Properties[0].ToString();
            List<string> usrrev = obj.AllReservationsManage().ToList();
            for (int i = 0; i < usrrev.Capacity; i = i + 10)
            {
                this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), Username = usrrev[i + 1].ToString(), FirstName = usrrev[i + 2].ToString(), LastName = usrrev[i + 3].ToString(), StartingDate = usrrev[i + 4].ToString(), ReturningDate = usrrev[i + 5].ToString(), SubmitDate = usrrev[i + 6].ToString(), Quantity = Convert.ToInt32(usrrev[i + 7].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 8].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 9].ToString()) });

            }
           
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainWindow winm = new MainWindow();
              winm.Show();
              this.Close();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ManagerRegistration mr = new ManagerRegistration();
            mr.Show();
            this.Close();

        }

       

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            listview2.Visibility = System.Windows.Visibility.Hidden;
            editbtn.Visibility = System.Windows.Visibility.Visible;
            label1.Visibility = System.Windows.Visibility.Hidden;
            listview1.Visibility = System.Windows.Visibility.Visible;
            list1.Items.Clear();
            if(grid1.Visibility == System.Windows.Visibility.Visible){
                grid1.Visibility = System.Windows.Visibility.Hidden;
            }
            if (listview1.Items.Count == 0)
            {
                List<string> usrrev = obj.AllReservationsManage().ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 10)
                {
                    this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), Username = usrrev[i + 1].ToString(), FirstName = usrrev[i + 2].ToString(), LastName = usrrev[i + 3].ToString(), StartingDate = usrrev[i + 4].ToString(), ReturningDate = usrrev[i + 5].ToString(), SubmitDate = usrrev[i + 6].ToString(), Quantity = Convert.ToInt32(usrrev[i + 7].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 8].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 9].ToString()) });

                }


            }
            else
            {
                listview1.Items.Clear();
                List<string> usrrev = obj.AllReservationsManage().ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 10)
                {
                    this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), Username = usrrev[i + 1].ToString(), FirstName = usrrev[i + 2].ToString(), LastName = usrrev[i + 3].ToString(), StartingDate = usrrev[i + 4].ToString(), ReturningDate = usrrev[i + 5].ToString(), SubmitDate = usrrev[i + 6].ToString(), Quantity = Convert.ToInt32(usrrev[i + 7].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 8].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 9].ToString()) });

                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
           
            if (listview1.SelectedItems.Count == 0)
            {
                //dte > DateTime.Now
                label1.Visibility = System.Windows.Visibility.Visible;

            }
            else
            {
                editbtn.Visibility = System.Windows.Visibility.Hidden;
                listview1.Visibility = System.Windows.Visibility.Hidden;
                grid1.Visibility = System.Windows.Visibility.Visible;
                label1.Visibility = System.Windows.Visibility.Hidden;

                MyItem rev = (MyItem)listview1.SelectedItems[0];

                App.Current.Properties[1] = rev.StartingDate.Trim();
                App.Current.Properties[2] = rev.ReturningDate.Trim();

                string[] splitString = rev.StartingDate.Split('/');
                string[] splitString2 = rev.ReturningDate.Split('/');
                rev.StartingDate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                rev.ReturningDate = splitString2[2] + "-" + splitString2[1] + "-" + splitString2[0];
                List<string> lista = obj2.BookAvailability(rev.Title,rev.StartingDate,rev.ReturningDate).ToList();
              

                for (int i = 0; i < lista.Capacity; i = i + 3)
                {


                    this.list1.Items.Add(new MyItem { StartingDate = lista[i].ToString(), ReturningDate = lista[i + 1].ToString(), Quantity = Convert.ToInt32( lista[i + 2].ToString()) });

                }
                txt1.Text = rev.Title;
                txt3.Text = rev.Username;
                txt4.Text = rev.FirstName;
                txt5.Text = rev.LastName;
                
                DateTime starting = new DateTime(Convert.ToInt32(splitString[2]), Convert.ToInt32(splitString[1]), Convert.ToInt32(splitString[0]));
                date1.SelectedDate = starting;

                
                DateTime ending = new DateTime(Convert.ToInt32(splitString2[2]), Convert.ToInt32(splitString2[1]), Convert.ToInt32(splitString2[0]));
                date2.SelectedDate = ending;
                txt6.Text = rev.SubmitDate;
                txt7.Text = rev.Quantity.ToString();
                copies.Text = obj5.Copies(rev.Title);
               
                    /*ReservationDetails3 del = new ReservationDetails3();
                    del.Title = rev.Title;
                    del.UserName = App.Current.Properties[0].ToString();
                    del.Firstname = usr[0].ToString();
                    del.Lastname = usr[1].ToString();
                    del.Startingdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                    splitString = rev.ReturningDate.Split('/');
                    del.Endingdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                    splitString = rev.SubmitDate.Split('/', ' ');
                    del.Submitdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0] + " " + splitString[3];
                    del.Aborted = rev.Aborted;
                    del.Accepted = rev.Accepted;
                    obj5.DeleteReservation(del);*/
                    //  test.Text = del.Title + del.UserName + del.Firstname + del.Lastname + del.Startingdate + del.Endingdate + del.Submitdate + del.Aborted + del.Accepted;

                 /*   listview1.Items.Clear();
                    List<string> usrrev = obj4.UserReservationsManage(App.Current.Properties[0].ToString()).ToList();
                    for (int i = 0; i < usrrev.Capacity; i = i + 7)
                    {
                        this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), StartingDate = usrrev[i + 1].ToString(), ReturningDate = usrrev[i + 2].ToString(), SubmitDate = usrrev[i + 3].ToString(), Quantity = Convert.ToInt32(usrrev[i + 4].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 5].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 6].ToString()) });

                    }*/

              
            } 
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = System.Windows.Visibility.Hidden;
                editbtn.Visibility = System.Windows.Visibility.Visible;
                listview1.Visibility = System.Windows.Visibility.Visible;
              //  label1.Visibility = System.Windows.Visibility.Hidden;
               
                ReservationDetails2 old = new ReservationDetails2(); //App.Current.Properties[0].ToString();
                ReservationDetails2 new1 = new ReservationDetails2();

                string[] splitString =  App.Current.Properties[1].ToString().Split('/');
                
                old.Title = txt1.Text;
                old.UserName = txt3.Text;
                old.Firstname = txt4.Text;
                old.Lastname = txt5.Text;
                old.Startingdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                splitString = App.Current.Properties[2].ToString().Split('/');
                old.Endingdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                splitString = txt6.Text.Split('/',' ');
                old.Submitdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0] + " " + splitString[3];
                // old.Quantity = txt7.Text;
                old.Accepted = false;
                old.Aborted = false;

                new1.Title = txt1.Text;
                new1.UserName = txt3.Text;
                new1.Firstname = txt4.Text;
                new1.Lastname = txt5.Text;
                DateTime? a = date1.SelectedDate;
                new1.Startingdate = a.Value.Year + "-" + a.Value.Month + "-" + a.Value.Day;
                DateTime? b = date2.SelectedDate;
                new1.Endingdate = b.Value.Year + "-" + b.Value.Month + "-" + b.Value.Day;
                splitString = txt6.Text.Split('/',' ');
                new1.Submitdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0] + " " + splitString[3];
                // old.Quantity = txt7.Text;
               
                if(txt8.SelectedIndex == 0){
                    new1.Accepted = true;
                    new1.Aborted = false;

                }
                else
                {
                    new1.Accepted = false;
                    new1.Aborted = true;
                }
                obj4.Modifyandcheck(new1,old);
                string email = obj6.Email(txt3.Text);
                var url = "mailto:"+email+"?subject=ReservationAborted&body="+email2.Text;
                System.Diagnostics.Process.Start(url);
                list1.Items.Clear();
                listview1.Items.Clear();
                List<string> usrrev = obj.AllReservationsManage().ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 10)
                {
                    this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), Username = usrrev[i + 1].ToString(), FirstName = usrrev[i + 2].ToString(), LastName = usrrev[i + 3].ToString(), StartingDate = usrrev[i + 4].ToString(), ReturningDate = usrrev[i + 5].ToString(), SubmitDate = usrrev[i + 6].ToString(), Quantity = Convert.ToInt32(usrrev[i + 7].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 8].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 9].ToString()) });

                }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = System.Windows.Visibility.Hidden;
            editbtn.Visibility = System.Windows.Visibility.Visible;
            listview1.Visibility = System.Windows.Visibility.Visible;
           // label1.Visibility = System.Windows.Visibility.Hidden;
            listview1.Items.Clear();
            List<string> usrrev = obj.AllReservationsManage().ToList();
            for (int i = 0; i < usrrev.Capacity; i = i + 10)
            {
                this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), Username = usrrev[i + 1].ToString(), FirstName = usrrev[i + 2].ToString(), LastName = usrrev[i + 3].ToString(), StartingDate = usrrev[i + 4].ToString(), ReturningDate = usrrev[i + 5].ToString(), SubmitDate = usrrev[i + 6].ToString(), Quantity = Convert.ToInt32(usrrev[i + 7].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 8].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 9].ToString()) });

            }
            list1.Items.Clear();
        }

        private void date1_CalendarOpened(object sender, RoutedEventArgs e)
        {
            
            DateTime yesterday = Convert.ToDateTime(date1.SelectedDate);
            yesterday = yesterday.AddDays(-1);
            DateTime tomorrow = Convert.ToDateTime(date2.SelectedDate);
            tomorrow = tomorrow.AddDays(1);
           
            date1.BlackoutDates.Add(new CalendarDateRange(new DateTime(0001, 1, 1), new DateTime(yesterday.Year, yesterday.Month, yesterday.Day)));
            date1.BlackoutDates.Add(new CalendarDateRange(new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day), new DateTime(9999, 12, 31)));
        }

        private void date2_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DateTime yesterday = Convert.ToDateTime(date1.SelectedDate);
            yesterday = yesterday.AddDays(-1);
            DateTime tomorrow = Convert.ToDateTime(date2.SelectedDate);
            tomorrow = tomorrow.AddDays(1);

            date2.BlackoutDates.Add(new CalendarDateRange(new DateTime(0001, 1, 1), new DateTime(yesterday.Year, yesterday.Month, yesterday.Day)));
            date2.BlackoutDates.Add(new CalendarDateRange(new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day), new DateTime(9999, 12, 31)));
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            listview2.Visibility = System.Windows.Visibility.Visible;
            
            list1.Items.Clear();
            grid1.Visibility = System.Windows.Visibility.Hidden;
            editbtn.Visibility = System.Windows.Visibility.Hidden;
            listview1.Visibility = System.Windows.Visibility.Hidden;

            if (listview2.Items.Count == 0)
            {
              List<string> usrrev = obj3.ReadUsers().ToList();
               for (int i = 0; i < usrrev.Capacity; i = i + 6)
              {
                this.listview2.Items.Add(new MyItem2 {  Username = usrrev[i ].ToString(), FirstName = usrrev[i + 1].ToString(), LastName = usrrev[i + 2].ToString(), Email =usrrev[i + 3].ToString(), Age = Convert.ToInt32( usrrev[i + 4].ToString()), Telephone = Convert.ToInt64(usrrev[i + 5].ToString()) });

               }
            }else{

                listview2.Items.Clear();
                List<string> usrrev = obj3.ReadUsers().ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 6)
                {
                    this.listview2.Items.Add(new MyItem2 { Username = usrrev[i].ToString(), FirstName = usrrev[i + 1].ToString(), LastName = usrrev[i + 2].ToString(), Email = usrrev[i + 3].ToString(), Age = Convert.ToInt32(usrrev[i + 4].ToString()), Telephone = Convert.ToInt64(usrrev[i + 5].ToString()) });

                }

               
            }
            
            

        }

       

        private void name2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            email2.Visibility = System.Windows.Visibility.Visible;
            emaillbl.Visibility = System.Windows.Visibility.Visible;
        }

        private void name1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            email2.Visibility = System.Windows.Visibility.Hidden;
            emaillbl.Visibility = System.Windows.Visibility.Hidden;
        }


       

       

      

        
        
    }

}
