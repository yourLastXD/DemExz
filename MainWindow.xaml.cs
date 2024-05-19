using DemExz.Pages;
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
using Wpf.Ui.Controls;

namespace DemExz
{

    public partial class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AllUsers();
            //SelectEmployee.ItemsSource = humansDataGrid;
            //Строка подключения к бд
            //Scaffold-DbContext "Server=localhost\SQLEXPRESS;Database=AccountingOfEmployeesInTheOrganization;Trusted_Connection=True;TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Data" -force
        }
    }
}
