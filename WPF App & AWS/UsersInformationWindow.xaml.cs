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

namespace _301072868_meko__lab2
{
    /// <summary>
    /// Interaction logic for UsersInformationWindow.xaml
    /// </summary>
    public partial class UsersInformationWindow : Window
    {
        public UsersInformationWindow()
        {
            InitializeComponent();
        }  

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            txtBoxUserEmail.Text = "";
            txtBoxIsbn.Text = "";
            txtBoxTitle.Text = "";
            txtBoxAuthor1.Text = "";
            txtBoxAuthor2.Text = "";
            txtBoxAuthor3.Text = "";
            txtBoxPublisher.Text = "";
            txtBoxEdition.Text = "";
            txtBoxCopyrightYear.Text = "";
            txtBoxPageNo.Text = "";
            txtBlockSearchResults.Text = "";
        }

        private void BtnAdd2MyBookshelf_Click(object sender, RoutedEventArgs e)
        {
            txtBlockSearchResults.Text = "";
            DBOperations operations = new DBOperations();
            operations.InsertItem2Bookshelf(txtBoxUserEmail.Text, txtBoxIsbn.Text, txtBoxTitle.Text, txtBoxAuthor1.Text, txtBoxAuthor2.Text, txtBoxAuthor3.Text, txtBoxPublisher.Text, txtBoxEdition.Text, txtBoxCopyrightYear.Text);
        }

        private void BtnAddUsersSnapshot_Click(object sender, RoutedEventArgs e)
        {
            txtBlockSearchResults.Text = "";
            DBOperations operations = new DBOperations();
            operations.InsertSnapshot(txtBoxUserEmail.Text, txtBoxIsbn.Text, txtBoxTitle.Text, txtBoxPageNo.Text);            
        }

        private void BtnShowUsersBooklist_Click(object sender, RoutedEventArgs e)
        {
            txtBlockSearchResults.Text = "";
            DBOperations operations = new DBOperations();
            txtBlockSearchResults.Text= operations.ShowBookshelf(txtBoxUserEmail.Text,txtBoxIsbn.Text);
        }

        private void BtnShowUsersSnapshot_Click(object sender, RoutedEventArgs e)
        {
            txtBlockSearchResults.Text = "";
            DBOperations operations = new DBOperations();
            txtBlockSearchResults.Text = operations.ShowSnapshot(txtBoxUserEmail.Text, txtBoxIsbn.Text);
        }

        private void BtnPopulateSampleData_Click(object sender, RoutedEventArgs e)
        {
            DBOperations operations = new DBOperations();
            operations.InsertItem2Bookshelf("irismeko@gmail.com", "9781119508199", "AWS Certified Developer Official Study Guide, Associate Exam", "Nick Alteen", "Jennifer Fisher", "Casey Gerena", "Sybex", "1", "2019");
            operations.InsertItem2Bookshelf("irismeko@gmail.com", "9781119490708", "AWS Certified Cloud Practitioner Study Guide", "Ben Piper", "David Clinton", "", "Sybex", "1", "2019");
            operations.InsertItem2Bookshelf("irismeko@gmail.com", "9781788837934", "Building Serverless Python Web Services with Zappa", "Abdulwahid Abdulhaque Barguzar", "", "", "Packt Publishing", "1", "2018");
            operations.InsertItem2Bookshelf("irismeko@gmail.com", "9780596003845", "Java Enterprise Best Practices", "Ram Kulkarni", "", "", "O'Reilly Media", "1", "2017");
            MessageBox.Show("Table population finished." , "Table population");
        }
    }
}
