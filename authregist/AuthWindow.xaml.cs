using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public AuthWindow()
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
            
            bool result = db.Users.Any(u=>u.Login == login_textbox.Text &&  u.Password == password_textbox.Text);
            if (!result)
            {
                tooltip_box.Text = "Такого пользователя нету";

            }
            else
            {
                this.Hide();
                AdminWindow window = new AdminWindow();
                window.Show();

            }
        }
    }
}
