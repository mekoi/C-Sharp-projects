using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BooksWpfApp
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

        private void btnQuery1_Click(object sender, RoutedEventArgs e)
        {
            lblFilterCriteria.Content = "Titles & authors sorted by title";

            using (AppDBContext dbContext = new AppDBContext())
            {
                var titlesAndAuthorsSortedByTitle = (from titl in dbContext.Titles
                         join authISBN in dbContext.AuthorISBN on titl.ISBN equals authISBN.ISBN
                         join auth in dbContext.Authors on authISBN.AuthorID equals auth.AuthorID
                         orderby titl.Title
                         select new
                         {
                             titl.Title,
                             auth.FirstName,
                             auth.LastName                
                         }).ToList();

                datagridBooks.ItemsSource = null;
                datagridBooks.ItemsSource = titlesAndAuthorsSortedByTitle;
            }
        }

        private void btnQuery2_Click(object sender, RoutedEventArgs e)
        {
            lblFilterCriteria.Content = "Titles & authors sorted by title, last name, first name";

            using (AppDBContext dbContext = new AppDBContext())
            {
                var titlesAndAuthorsSortedByTitleName = (from titl in dbContext.Titles
                                                     join authISBN in dbContext.AuthorISBN on titl.ISBN equals authISBN.ISBN
                                                     join auth in dbContext.Authors on authISBN.AuthorID equals auth.AuthorID
                                                     orderby titl.Title, auth.LastName, auth.FirstName
                                                     select new
                                                     {
                                                         titl.Title,
                                                         auth.FirstName,
                                                         auth.LastName
                                                     }).ToList();

                datagridBooks.ItemsSource = null;
                datagridBooks.ItemsSource = titlesAndAuthorsSortedByTitleName;
            }
        }

        private void btnQuery3_Click(object sender, RoutedEventArgs e)
        {
            //not finished as the requirement is ambiguous
            lblFilterCriteria.Content = "";

            using (AppDBContext dbContext = new AppDBContext())
            {
                
            }

            datagridBooks.ItemsSource = null;
        }
    }
}
