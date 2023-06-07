using Microsoft.EntityFrameworkCore;
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

namespace authregist
{
   
   
    public partial class AdminWindow : Window
    {
        ApplicationContext db = new ApplicationContext();
        public AdminWindow()
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
        private void Delete_User(object sender, RoutedEventArgs e)
        {
            User user = usersList.SelectedItem as User;
            if (user is null) return;
            db.Users.Remove(user);
            db.SaveChanges();
        }
        
    }
}
