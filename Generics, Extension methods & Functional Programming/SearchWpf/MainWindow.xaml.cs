using System;
using System.Windows;

namespace SearchWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] randomIntegers;
        private double[] randomDoubles;
        private readonly int minNumber = 1;
        private readonly int maxNumber = 999;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerateInteger_Click(object sender, RoutedEventArgs e)
        {
            randomIntegers = new int[10];
            randomDoubles = null;
            Random random = new Random();

            for (int i = 0; i < randomIntegers.Length; i++) 
            {
                randomIntegers[i] = random.Next(minNumber, maxNumber);
            }

            lblGeneratedRandomNumbers.Content = "";

            for (int i = 0; i < randomIntegers.Length; i++)
            {
                lblGeneratedRandomNumbers.Content +=  randomIntegers[i].ToString() + "  ";
            }          
        }

        private void BtnGenerateDoubles_Click(object sender, RoutedEventArgs e)
        {
            randomDoubles = new double[10];
            randomIntegers = null;
            Random random = new Random();

            for (int i = 0; i < randomDoubles.Length; i++)
            {
                randomDoubles[i] = Math.Round(random.NextDouble() * (maxNumber - minNumber)*2, 2);
            }

            lblGeneratedRandomNumbers.Content = "";

            for (int i = 0; i < randomDoubles.Length; i++)
            {
                lblGeneratedRandomNumbers.Content += randomDoubles[i].ToString() + "  ";
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (randomDoubles != null)  //generated numbers are doubles
                {
                    double searchKeyDouble = Double.Parse(textBoxSearchKey.Text);

                    int index = Search(randomDoubles, searchKeyDouble);

                    if (index != -1)
                    {
                        lblSearchResult.Content = "Number=" + searchKeyDouble + " is found in index=" + index + ".";
                    }
                    else
                    {
                        lblSearchResult.Content = "Number=" + searchKeyDouble + " is not found.";
                    }
                }

                if (randomIntegers != null) //generated numbers are integers
                {
                    int searchKeyInteger = int.Parse(textBoxSearchKey.Text);
                    int index = Search(randomIntegers, searchKeyInteger);

                    if (index != -1)
                    {
                        lblSearchResult.Content = "Number=" + searchKeyInteger + " is found in index=" + index + ".";
                    }
                    else
                    {
                        lblSearchResult.Content = "Number=" + searchKeyInteger + " is not found.";
                    }
                }
            }
            catch
            {
                lblSearchResult.Content = "Enter a valid number to search!";
            }
        }

        public static int Search<T>(T[] arrayToSearch, T searchKey) where T : IComparable
        {
            for (int i = 0; i< arrayToSearch.Length; i++)
            {
                if (arrayToSearch[i].CompareTo(searchKey) == 0)
                {
                    return i;
                }    
            }
            return -1;
        }
    }
}

