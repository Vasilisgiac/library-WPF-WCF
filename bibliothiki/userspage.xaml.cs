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
using bibliothiki.ReservationReference;
using bibliothiki.BookLoadingReference;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using bibliothiki.ReadNamesReference;
using bibliothiki.ReservationsManageReference;
using bibliothiki.DeleteReservationReference;

namespace bibliothiki
{
    /// <summary>
    /// Interaction logic for userspage.xaml
    /// </summary>
    public partial class userspage : Window
    {
        ReservationReference.Service1Client obj = new ReservationReference.Service1Client();
        BookLoadingReference.Service1Client obj2 = new BookLoadingReference.Service1Client();
        ReadNamesReference.Service1Client obj3 = new ReadNamesReference.Service1Client();
        ReservationsManageReference.Service1Client obj4 = new ReservationsManageReference.Service1Client();
        DeleteReservationReference.Service1Client obj5 = new DeleteReservationReference.Service1Client();
        public userspage()
        {
            InitializeComponent();
           /* var gridView = new GridView();
            this.listview1.View = gridView;
           

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Title",
                DisplayMemberBinding = new Binding("Title"),
              //  Name ="111" 
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "StartingDate",
                DisplayMemberBinding = new Binding("StartingDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "ReturningDate",
                DisplayMemberBinding = new Binding("ReturningDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "SubmitDate",
                DisplayMemberBinding = new Binding("SubmitDate")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Quantity",
                DisplayMemberBinding = new Binding("Quantity")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Accepted",
                DisplayMemberBinding = new Binding("Accepted")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Aborted",
                DisplayMemberBinding = new Binding("Aborted")
            });

*/

           wel.Visibility = System.Windows.Visibility.Visible;
           txt1.Text= App.Current.Properties[0].ToString();
           List<string> books = obj2.BookLoading().ToList();
           for (int i = 0; i < books.Capacity; i++)
           {

               ListBoxItem itm = new ListBoxItem();
               itm.Content = books[i].ToString();
               itm.Name = "itm" + i;

               list1.Items.Add(itm);



           }


        }

        public class MyItem
        {
            public string Title { get; set; }
            public string StartingDate { get; set; }
            public string ReturningDate { get; set; }
            public string SubmitDate { get; set; }
            public int Quantity { get; set; }
            public bool Accepted { get; set; }
            public bool Aborted { get; set; }
        }

             

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            MainWindow winm = new MainWindow();
            winm.Show();
            this.Close();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             wel.Visibility = System.Windows.Visibility.Hidden;
            label1.Visibility = System.Windows.Visibility.Visible;
            label2.Visibility = System.Windows.Visibility.Visible;
            date1.Visibility = System.Windows.Visibility.Visible;
            date2.Visibility = System.Windows.Visibility.Visible;
            btn1.Visibility = System.Windows.Visibility.Visible;
            list1.Visibility = System.Windows.Visibility.Visible;
            quan.Visibility = System.Windows.Visibility.Visible;
            quan2.Visibility = System.Windows.Visibility.Visible;
            lbl5.Visibility = System.Windows.Visibility.Hidden;
            listview1.Visibility = System.Windows.Visibility.Hidden;
            btn10.Visibility = System.Windows.Visibility.Hidden;
            labeld1.Visibility = System.Windows.Visibility.Hidden;
            labeld2.Visibility = System.Windows.Visibility.Hidden;
            labeld3.Visibility = System.Windows.Visibility.Hidden;
            lbel3.Visibility = System.Windows.Visibility.Hidden;
            lbll3.Visibility = System.Windows.Visibility.Hidden;
            lbll2.Visibility = System.Windows.Visibility.Hidden;
        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             wel.Visibility = System.Windows.Visibility.Visible;
            label1.Visibility = System.Windows.Visibility.Hidden;
            label2.Visibility = System.Windows.Visibility.Hidden;
            date1.Visibility  = System.Windows.Visibility.Hidden;
            date2.Visibility  = System.Windows.Visibility.Hidden;
            btn1.Visibility = System.Windows.Visibility.Hidden;
            list1.Visibility = System.Windows.Visibility.Hidden;
            lbl5.Visibility = System.Windows.Visibility.Hidden;
            quan.Visibility = System.Windows.Visibility.Hidden;
            quan2.Visibility = System.Windows.Visibility.Hidden;
            listview1.Visibility = System.Windows.Visibility.Hidden;
            btn10.Visibility = System.Windows.Visibility.Hidden;
            labeld1.Visibility = System.Windows.Visibility.Hidden;
            labeld2.Visibility = System.Windows.Visibility.Hidden;
            labeld3.Visibility = System.Windows.Visibility.Hidden;
            lbel3.Visibility = System.Windows.Visibility.Hidden;
            lbll3.Visibility = System.Windows.Visibility.Hidden;
            lbll2.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            wel.Visibility = System.Windows.Visibility.Hidden;
            label1.Visibility = System.Windows.Visibility.Hidden;
            label2.Visibility = System.Windows.Visibility.Hidden;
            date1.Visibility = System.Windows.Visibility.Hidden;
            date2.Visibility = System.Windows.Visibility.Hidden;
            btn1.Visibility = System.Windows.Visibility.Hidden;
            list1.Visibility = System.Windows.Visibility.Hidden;
            quan.Visibility = System.Windows.Visibility.Hidden;
            quan2.Visibility = System.Windows.Visibility.Hidden;
            listview1.Visibility = System.Windows.Visibility.Visible;
            btn10.Visibility = System.Windows.Visibility.Visible;
            labeld1.Visibility = System.Windows.Visibility.Hidden;
            labeld2.Visibility = System.Windows.Visibility.Hidden;
            labeld3.Visibility = System.Windows.Visibility.Hidden;
            lbel3.Visibility = System.Windows.Visibility.Hidden;
            lbll3.Visibility = System.Windows.Visibility.Hidden;
            lbll2.Visibility = System.Windows.Visibility.Hidden;

            if (listview1.Items.Count == 0)
            {
                List<string> usrrev = obj4.UserReservationsManage(App.Current.Properties[0].ToString()).ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 7)
                {
                    this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), StartingDate = usrrev[i + 1].ToString(), ReturningDate = usrrev[i + 2].ToString(), SubmitDate = usrrev[i + 3].ToString(), Quantity = Convert.ToInt32(usrrev[i + 4].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 5].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 6].ToString()) });

                }


            }
            else {
                listview1.Items.Clear();
                List<string> usrrev = obj4.UserReservationsManage(App.Current.Properties[0].ToString()).ToList();
                for (int i = 0; i < usrrev.Capacity; i = i + 7)
                {
                    this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), StartingDate = usrrev[i + 1].ToString(), ReturningDate = usrrev[i + 2].ToString(), SubmitDate = usrrev[i + 3].ToString(), Quantity = Convert.ToInt32(usrrev[i + 4].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 5].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 6].ToString()) });

                }
            }
            
           
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            bool u1, u2, u3, u4 = false;
           
              int parsedValue;

              if (!int.TryParse(quan.Text, out parsedValue) || string.IsNullOrWhiteSpace(quan.Text.Trim('0')))
            {
                lbel3.Visibility = System.Windows.Visibility.Visible;
                u1 = false;


            }
              else { u1 = true; }
            if(date1.SelectedDate==null){
                labeld1.Visibility = System.Windows.Visibility.Visible;
                u2 = false;
            }
            else { u2 = true; }
            if (date2.SelectedDate == null)
            {
                labeld2.Visibility = System.Windows.Visibility.Visible;
                u3 = false;
            }
            else { u3 = true; }

            if (list1.SelectedItems.Count==0)
            {
                labeld3.Visibility = System.Windows.Visibility.Visible;
                u4 = false;
            }
            else { u4 = true; }

            if (u1 == true && u2 == true && u3 == true && u4 == true)
            {

                List<string> usr = obj3.ReadNames(App.Current.Properties[0].ToString()).ToList();
                


                ReservationDetails reservationinfo = new ReservationDetails();
                reservationinfo.Title = ((ListBoxItem)list1.SelectedValue).Content.ToString();
                reservationinfo.UserName = App.Current.Properties[0].ToString();
                reservationinfo.Firstname = usr[0].ToString();
                reservationinfo.Lastname = usr[1].ToString();
                DateTime? a = date1.SelectedDate;
                reservationinfo.Startingdate = a.Value.Year + "-" + a.Value.Month + "-" + a.Value.Day;
                DateTime? b = date2.SelectedDate;
                reservationinfo.Endingdate = b.Value.Year + "-" + b.Value.Month + "-" + b.Value.Day;
                DateTime? c = DateTime.Now;
                reservationinfo.Submitdate = c.Value.Year + "-" + c.Value.Month + "-" + c.Value.Day+ " " + c.Value.Hour + ":" + c.Value.Minute+":" + c.Value.Second;
                reservationinfo.Quantity = Convert.ToInt32(quan.Text);
                reservationinfo.Accepted = false;
                reservationinfo.Aborted = false;
                obj.Reservation(reservationinfo);

               
               

                wel.Visibility = System.Windows.Visibility.Hidden;
                label1.Visibility = System.Windows.Visibility.Hidden;
                label2.Visibility = System.Windows.Visibility.Hidden;
                date1.Visibility = System.Windows.Visibility.Hidden;
                date2.Visibility = System.Windows.Visibility.Hidden;
                btn1.Visibility = System.Windows.Visibility.Hidden;
                list1.Visibility = System.Windows.Visibility.Hidden;
                lbl5.Visibility = System.Windows.Visibility.Visible;
                quan.Visibility = System.Windows.Visibility.Hidden;
                quan2.Visibility = System.Windows.Visibility.Hidden;
            }

            
        }

       

        private void quan_MouseEnter(object sender, MouseEventArgs e)
        {
            lbel3.Visibility = System.Windows.Visibility.Hidden;
        }

        private void date1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (date2.SelectedDate < date1.SelectedDate)
            {
                lbll1.Visibility = System.Windows.Visibility.Visible;
                date2.SelectedDate = null;

            }
            else{
            date2.BlackoutDates.Add(new CalendarDateRange(new DateTime(0001, 1, 1), new DateTime(date1.SelectedDate.Value.Year, date1.SelectedDate.Value.Month, date1.SelectedDate.Value.Day)));

           }
        }

        private void date1_CalendarOpened(object sender, RoutedEventArgs e)
        {
            date1.BlackoutDates.Add(new CalendarDateRange(new DateTime(0001, 1, 1), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - 1)));
            labeld1.Visibility = System.Windows.Visibility.Hidden;
            lbll1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void date2_CalendarOpened(object sender, RoutedEventArgs e)
        {
            labeld2.Visibility = System.Windows.Visibility.Hidden;
            lbll1.Visibility = System.Windows.Visibility.Hidden;
            if (date1.SelectedDate != null)
            {
                date2.BlackoutDates.Add(new CalendarDateRange(new DateTime(0001, 1, 1), new DateTime(date1.SelectedDate.Value.Year, date1.SelectedDate.Value.Month, date1.SelectedDate.Value.Day)));
            }
        }

        private void list1_MouseEnter(object sender, MouseEventArgs e)
        {
            labeld3.Visibility = System.Windows.Visibility.Hidden;
        }

        private void date2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (date2.SelectedDate < date1.SelectedDate)
            {
                lbll1.Visibility = System.Windows.Visibility.Visible;
                date2.SelectedDate = null;

           }
           
           
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            /*MyItem rev = (MyItem)listview1.SelectedItems[0];
            string[] splitString = rev.StartingDate.Split('/');
            DateTime dte = new DateTime(Convert.ToInt32(splitString[2]), Convert.ToInt32(splitString[1]), Convert.ToInt32(splitString[0]));*/
            if (listview1.SelectedItems.Count == 0)
            {
                //dte > DateTime.Now
                lbll3.Visibility = System.Windows.Visibility.Visible;

            }
            else{
                MyItem rev = (MyItem)listview1.SelectedItems[0];
                string[] splitString = rev.StartingDate.Split('/');
                DateTime dte = new DateTime(Convert.ToInt32(splitString[2]), Convert.ToInt32(splitString[1]), Convert.ToInt32(splitString[0]));
              
                List<string> usr = obj3.ReadNames(App.Current.Properties[0].ToString()).ToList();

                if(dte > DateTime.Now){
                    ReservationDetails3 del = new ReservationDetails3();
                    del.Title = rev.Title;
                    del.UserName = App.Current.Properties[0].ToString();
                    del.Firstname = usr[0].ToString();
                    del.Lastname = usr[1].ToString();
                    del.Startingdate = splitString[2]+"-"+splitString[1]+"-"+splitString[0];
                    splitString = rev.ReturningDate.Split('/');
                    del.Endingdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0];
                    splitString = rev.SubmitDate.Split('/',' ');
                    del.Submitdate = splitString[2] + "-" + splitString[1] + "-" + splitString[0] + " " + splitString[3];
                    del.Aborted = rev.Aborted;
                    del.Accepted = rev.Accepted;
                    obj5.DeleteReservation(del);
                  //  test.Text = del.Title + del.UserName + del.Firstname + del.Lastname + del.Startingdate + del.Endingdate + del.Submitdate + del.Aborted + del.Accepted;

                    listview1.Items.Clear();
                    List<string> usrrev = obj4.UserReservationsManage(App.Current.Properties[0].ToString()).ToList();
                    for (int i = 0; i < usrrev.Capacity; i = i + 7)
                    {
                        this.listview1.Items.Add(new MyItem { Title = usrrev[i].ToString(), StartingDate = usrrev[i + 1].ToString(), ReturningDate = usrrev[i + 2].ToString(), SubmitDate = usrrev[i + 3].ToString(), Quantity = Convert.ToInt32(usrrev[i + 4].ToString()), Accepted = Convert.ToBoolean(usrrev[i + 5].ToString()), Aborted = Convert.ToBoolean(usrrev[i + 6].ToString()) });

                    }

                }
                else
                {
                    lbll2.Visibility = System.Windows.Visibility.Visible;
                }
            } 
        }

        private void listview1_MouseEnter(object sender, MouseEventArgs e)
        {
            lbll2.Visibility = System.Windows.Visibility.Hidden;
            lbll3.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
