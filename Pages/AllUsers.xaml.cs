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

namespace DemExz.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllUsers.xaml
    /// </summary>
    public partial class AllUsers : Page
    {
        public AllUsers()
        {
            InitializeComponent();
            
            using(DemContext db = new DemContext())
            {
                List<User> users = new List<User>();
                users = db.Users.ToList();

                SelectedUser.ItemsSource = users;
            }
        }
    }
}
