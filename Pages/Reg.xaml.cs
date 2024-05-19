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
using Wpf.Ui.Controls;
using DemExz.Data;

namespace DemExz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Log());
        }
        public static string HashPassword(string pass)
        {
            var unHashed = System.Text.Encoding.Unicode.GetBytes(pass);
            var hashed = new SHA512Managed().ComputeHash(unHashed);

            return Convert.ToBase64String(hashed);
        }

        private void SaveAcc_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxLog.Text.Length < 4)
            {
                System.Windows.MessageBox.Show("Ошибка, логин не может быть короче 4 символов");
                return;
            }
            else if (TextBoxLog.Text.Length > 15)
            {
                System.Windows.MessageBox.Show("Ошибка, логин не может быть длинее 15 символов");
                return;
            }

            if (PassBoxPass1.Password.Length < 6)
            {
                System.Windows.MessageBox.Show("Ошибка, пароль не может быть короче 6 символов");
                return;
            }
            else if (PassBoxPass1.Password.Length > 20)
            {
                System.Windows.MessageBox.Show("Ошибка, пароль не может быть длинее 20 символов");
                return;
            }

            if (PassBoxPass1.Password != PassBoxPass2.Password)
            {
                System.Windows.MessageBox.Show("Ошибка, пароли не совпадают");
                return;
            }

            using (DemContext db = new())
            {
                var user = db.Users.ToList();

                foreach (var item in user)
                {
                    if (item.Login == TextBoxLog.Text)
                    {
                        System.Windows.MessageBox.Show("Ошибка, данный логин занят!");
                        return;
                    }                
                }

                string pass = HashPassword(PassBoxPass1.Password);

                User u = new User()
                {
                    Login = TextBoxLog.Text,
                    Password = pass,
                    RoleId = 2,
                };

                System.Windows.MessageBox.Show("Успех");
                db.Users.Add(u);
                db.SaveChanges();
            }

            TextBoxLog.Clear();
            PassBoxPass1.Clear();
            PassBoxPass2.Clear();
        }
    }
}
