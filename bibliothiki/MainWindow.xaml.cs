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
using System.Windows.Navigation;
using System.Windows.Shapes;
using bibliothiki.LoginUser3Refence;


namespace bibliothiki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LoginUser3Refence.Service1Client obj3 = new LoginUser3Refence.Service1Client();


       
        public MainWindow()
        {
            
            InitializeComponent();
            textbox11mp.Foreground = new SolidColorBrush(Colors.Gray);
            textbox21mp.Foreground = new SolidColorBrush(Colors.Gray);

            
        }
      
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration win2 = new UserRegistration();
            win2.Show();
            this.Close();
        }

        private void textbox21mp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox21mp.Visibility = System.Windows.Visibility.Hidden;
            textbox2mp.Visibility = System.Windows.Visibility.Visible;
        }

        

        private void textbox11mp_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textbox11mp.Visibility = System.Windows.Visibility.Hidden;
            textbox1mp.Visibility = System.Windows.Visibility.Visible;
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserDetails3 userinfo3 = new UserDetails3();
            userinfo3.UserName = textbox1mp.Text ;
            List<string> usernamelist = obj3.LoginUser3(userinfo3).ToList();
            
            if(usernamelist.Capacity != 0){
                if (usernamelist[0].ToString() == textbox2mp.Password && Convert.ToBoolean(usernamelist[1]) == true&& Convert.ToBoolean(usernamelist[2]) == false)
                {

                    App.Current.Properties[0] = textbox1mp.Text.Trim();
                  userspage win3 = new userspage();
                   win3.Show();
                  this.Close();

                    
                 }  else if(usernamelist[0].ToString() == textbox2mp.Password && Convert.ToBoolean(usernamelist[1]) == false && Convert.ToBoolean(usernamelist[2]) == true){
                     App.Current.Properties[0] = textbox1mp.Text.Trim();
                     managerpage win4 = new managerpage();
                     win4.Show();
                     this.Close();
                     
                 }
                else{
                      textbox21mp.Visibility = System.Windows.Visibility.Hidden;
                     textbox2mp.Visibility = System.Windows.Visibility.Visible;
                     label2.Visibility = System.Windows.Visibility.Visible;
                     textbox2mp.Password = null;
                }
                
            }else
            {

                textbox1mp.Text = null;
                textbox11mp.Visibility = System.Windows.Visibility.Hidden;
                textbox1mp.Visibility = System.Windows.Visibility.Visible;
                textbox2mp.Visibility = System.Windows.Visibility.Hidden;
                textbox21mp.Visibility = System.Windows.Visibility.Visible;
                label1.Visibility = System.Windows.Visibility.Visible;



            }
         
        }

       
        
        
        
        private void textbox1mp_MouseEnter(object sender, MouseEventArgs e)
        {
            label1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void textbox11mp_MouseEnter(object sender, MouseEventArgs e)
        {
            label1.Visibility = System.Windows.Visibility.Hidden;
        }

        private void textbox2mp_MouseEnter(object sender, MouseEventArgs e)
        {
            label2.Visibility = System.Windows.Visibility.Hidden;
        }

        private void textbox21mp_MouseEnter(object sender, MouseEventArgs e)
        {
            label1.Visibility = System.Windows.Visibility.Hidden;
        }




       

       

       

      
        

       
    }

}
