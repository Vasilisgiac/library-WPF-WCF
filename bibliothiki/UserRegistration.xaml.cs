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
using bibliothiki.LoginUserReference;
using bibliothiki.ValidationReference;

namespace bibliothiki
{
    /// <summary>
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        LoginUserReference.Service1Client obj = new LoginUserReference.Service1Client();
        ValidationReference.Service1Client obj2 = new ValidationReference.Service1Client();
        public UserRegistration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win1 = new MainWindow();
            win1.Show();
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            bool tx1,tx2,tx3,tx4,tx5,tx6,tx7,tx8,tx31 = false;

            if (textbox1.Text.Length == 0 || string.IsNullOrWhiteSpace(textbox1.Text))
            {
                label1.Visibility = System.Windows.Visibility.Visible ;
                tx1 = false;
            }
            else
            {
                tx1 = true;
            }

            if (textbox2.Text.Length == 0 || string.IsNullOrWhiteSpace(textbox2.Text))
            {

                label2.Visibility = System.Windows.Visibility.Visible;
                tx2 = false;
            }
            else
            {
                tx2 = true;
            }

            if (textbox3.Text.Length == 0 || string.IsNullOrWhiteSpace(textbox3.Text))
            {
                if (label31.Visibility == System.Windows.Visibility.Visible)
                {
                    label31.Visibility = System.Windows.Visibility.Hidden;
                }
                label3.Visibility = System.Windows.Visibility.Visible;
                
                tx3 = false;
            }
            else
            {
                tx3 = true;
            }
            if (textbox4.Password.Length == 0 || string.IsNullOrWhiteSpace(textbox4.Password))
            {
                textbox4.Password = null;
                label4.Visibility = System.Windows.Visibility.Visible;
                tx4 = false;
            }
            else
            {
                tx4 = true;
            }
            if (textbox5.Password.Length == 0 || string.IsNullOrWhiteSpace(textbox5.Password))
            {
                textbox5.Password = null;
                if(label51.Visibility==System.Windows.Visibility.Visible){
                    label51.Visibility = System.Windows.Visibility.Hidden;
                }
                label5.Visibility = System.Windows.Visibility.Visible;
                tx5 = false;
            }
            else {
                if (textbox4.Password != textbox5.Password)
                {
                    textbox5.Password = null;
                    label51.Visibility = System.Windows.Visibility.Visible;
                    tx5 = false;
                }
                else
                {
                    tx5 = true;
                }
            }

            if (textbox6.Text.Length == 0)
            {

                label6.Visibility = System.Windows.Visibility.Visible;
                label61.Visibility = System.Windows.Visibility.Hidden;
                tx6 = false;
            }
            else
            {
               System.Text.RegularExpressions.Regex newmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
               if (!newmail.IsMatch(textbox6.Text))
               {
                   
                   textbox6.Text = null;
                   label61.Visibility = System.Windows.Visibility.Visible;
                   tx6 = false;
                }
               else
               {
                   tx6 = true;
               }
            }




           // Int64 tel = Convert.ToInt64(textbox7.Text.ToString());
            if (textbox7.Text.Length == 0)
            {

                label7.Visibility = System.Windows.Visibility.Visible;
                label71.Visibility = System.Windows.Visibility.Hidden;
                tx7 = false;
            }
            else
            {
                Int64 parsedValue;
                if (!Int64.TryParse(textbox7.Text, out parsedValue) || textbox7.Text.Length < 10)
                {
                    
                    label71.Visibility = System.Windows.Visibility.Visible;
                    textbox7.Text = null;
                    tx7 = false;
                }
                else
                {
                    tx7 = true;
                }
            }
           


            if (textbox8.Text.Length == 0)
            {

                label8.Visibility = System.Windows.Visibility.Visible;
                label81.Visibility = System.Windows.Visibility.Hidden;
                tx8 = false;
            }
            else
            {
                   int parsedValue;
                   if (!int.TryParse(textbox8.Text, out parsedValue))
                   {
                       
                       label81.Visibility = System.Windows.Visibility.Visible;
                       textbox8.Text = null;
                       tx8 = false;
                   }
                   else
                   {
                       tx8 = true;
                   }
            }
            UserDetails2 userinfo2 = new UserDetails2();
            userinfo2.UserName = textbox3.Text;
            string val = obj2.ValidateUserName(userinfo2);
            if(val != null){
                textbox3.Text = null;
                if(label3.Visibility==System.Windows.Visibility.Visible){
                   label3.Visibility = System.Windows.Visibility.Hidden;
                }
                label31.Visibility = System.Windows.Visibility.Visible;
                tx31=false;
            }
            else{
                tx31 = true;
            }

            if (tx1 == true && tx2 == true && tx3 == true && tx4 == true && tx5 == true && tx6 == true && tx7 == true && tx8 == true && tx31==true ){
                try
                {
                    UserDetails userinfo = new UserDetails();
                    userinfo.Firstname = textbox1.Text;
                    userinfo.Lastname = textbox2.Text;
                    userinfo.UserName = textbox3.Text; 
                    userinfo.Password = textbox4.Password;
                    userinfo.Email = textbox6.Text;
                    userinfo.Telephone = Convert.ToInt64(textbox7.Text.ToString());
                    userinfo.Age = Convert.ToInt32(textbox8.Text.ToString());
                    userinfo.User = true;
                    userinfo.ReservationManager = false;

                    obj.RegistrationUser(userinfo);
                    //  Label3.Text = "Employee Name = " + msg.ElementAt(0) + " Employee Id = " + msg.ElementAt(1);
                    MainWindow winm = new MainWindow();
                    winm.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                  //  Label3.Text = "Wrong Id Or Password";
                }


                
            }
            
           

        }

        //
        //
        //
        private void textbox1_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label1.Visibility == System.Windows.Visibility.Visible)
            {
                label1.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox2_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label2.Visibility == System.Windows.Visibility.Visible)
            {
                label2.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox3_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label3.Visibility == System.Windows.Visibility.Visible)
            {
                label3.Visibility = System.Windows.Visibility.Hidden;
            }
            if (label31.Visibility == System.Windows.Visibility.Visible)
            {
                label31.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox4_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label4.Visibility == System.Windows.Visibility.Visible)
            {
                label4.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox5_MouseEnter(object sender, MouseEventArgs e)
        {
            
            if (label5.Visibility == System.Windows.Visibility.Visible)
            {
                label5.Visibility = System.Windows.Visibility.Hidden;
            }
            if (label51.Visibility == System.Windows.Visibility.Visible)
            {
                label51.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox6_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label6.Visibility == System.Windows.Visibility.Visible)
            {
                label6.Visibility = System.Windows.Visibility.Hidden;
            }
            if (label61.Visibility == System.Windows.Visibility.Visible)
            {
                label61.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void textbox7_MouseEnter(object sender, MouseEventArgs e)
        {
            if (label7.Visibility == System.Windows.Visibility.Visible)
            {
                label7.Visibility = System.Windows.Visibility.Hidden;
            }
            if (label71.Visibility == System.Windows.Visibility.Visible)
           {

               label71.Visibility = System.Windows.Visibility.Hidden;
           }
        }
          


       private void textbox8_MouseEnter(object sender, MouseEventArgs e)
       {
           if (label8.Visibility == System.Windows.Visibility.Visible)
           {
               label8.Visibility = System.Windows.Visibility.Hidden;
           }
           if (label81.Visibility == System.Windows.Visibility.Visible)
           {

               label81.Visibility = System.Windows.Visibility.Hidden;
           }

           
       }

       private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
       {

       }

       

         

      

       

       
    }
}
