using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace authregist
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    
    public partial class RegistrationWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public RegistrationWindow()
        {
            InitializeComponent();
            Loaded += RegistrationWindow_Loaded;
        }
        private void RegistrationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            db.Users.Load();
            DataContext = db.Users.Local.ToObservableCollection();
        }
        private void Registration(object sender, RoutedEventArgs e)
        {
            if(login_textbox.Text == "" || password_textbox.Text == "" || email_textbox.Text == "")
            {
                tooltip_box.Text = "Все поля должны быть заполнены";

            }
            else
            {
                User user = new User();
                user.Email = email_textbox.Text;
                user.Password = password_textbox.Text;
                user.Login = login_textbox.Text;
                db.Add(user);
                db.SaveChanges();
                MessageBox.Show("ALL GOOD");
                
            }
        }
    }
}
