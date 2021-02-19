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

namespace _301072868_meko__lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreateTables_Click(object sender, RoutedEventArgs e)
        {
            DBOperations operations = new DBOperations();
            operations.CreateTable1();
            operations.CreateTable2();
        }

        private void BtnUsersInformation_Click(object sender, RoutedEventArgs e)
        {
            UsersInformationWindow userInfoWindow = new UsersInformationWindow();
            userInfoWindow.ShowDialog();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }
    }
}
