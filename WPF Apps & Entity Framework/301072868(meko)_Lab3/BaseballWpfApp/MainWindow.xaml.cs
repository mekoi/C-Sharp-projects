using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace BaseballWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                var lastNamePlayer = from player in dbContext.Players
                                     where player.LastName.Contains(txtLastNameFind.Text)
                                     orderby player.LastName, player.FirstName
                                     select player;

                datagridPlayers.ItemsSource = null;
                datagridPlayers.ItemsSource = new ObservableCollection<Players>(lastNamePlayer.ToList());
            }
        }

        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                datagridPlayers.ItemsSource = null;
                datagridPlayers.ItemsSource = new ObservableCollection<Players>(dbContext.Players.ToList());
            }
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Players newPlayer = new Players();
                newPlayer.FirstName = txtFirstName.Text;
                newPlayer.LastName = txtLastName.Text;
                newPlayer.BattingAverage = Decimal.Parse(txtBattingAverage.Text);
                dbContext.Players.Add(newPlayer);
                dbContext.SaveChanges();

                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtBattingAverage.Text = "";
            }
        }
    }
}
