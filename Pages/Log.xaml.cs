using DemExz.Data;
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
using XSystem.Security.Cryptography;

namespace DemExz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Log.xaml
    /// </summary>
    public partial class Log : Page
    {
        public Log()
        {
            InitializeComponent();
        }

        public static string HashPassword(string pass)
        {
            var unHashed = System.Text.Encoding.Unicode.GetBytes(pass);
            var hashed = new SHA512Managed().ComputeHash(unHashed);

            return Convert.ToBase64String(hashed);
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Reg());
        }

        private void SaveLog_Click(object sender, RoutedEventArgs e)
        {
            string pass = HashPassword(PassBoxLog.Password);

            using (DemContext db = new())
            {
                List<User> users = new List<User>();
                users = db.Users.ToList();

                foreach (User user in users)
                {
                    if (user.Login == TextBoxLog.Text && user.Password == pass)
                    {
                        MessageBox.Show("Успех!");
                        return;
                    }
                }
            }

            MessageBox.Show("Неверный логин и/или пароль");
        }
    }
}
