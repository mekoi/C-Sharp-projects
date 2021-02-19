using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Question1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public String filePath = "D:\\Iris_college\\Courses\\Semester2\\Comp212_Program3\\Labs\\Lab5\\Lab#5\\ToSubmit\\301072868(meko)_Lab5\\301072868(meko)_Lab5\\Question1\\stockData_SavedInCsv.csv";

        public MainWindow()
        {
            InitializeComponent();
        }

        public async Task<DataTable> PopulateDataGrid() 
        {
            
            DataTable dataTable = new DataTable();
            
            dataTable = await ReadCSV(filePath);      
            
            return dataTable;
        }      

        public Task<DataTable> ReadCSV(string flPath)
        {
            DataTable dt = new DataTable();        

            // Creating the columns
            File.ReadLines(flPath).Take(1)
                .SelectMany(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .ToList()
                .ForEach(x => dt.Columns.Add(x.Trim()));

            // Adding the rows
            dt.Columns[0].DataType = typeof(string);
            dt.Columns[1].DataType = typeof(DateTime);
            dt.Columns[2].DataType = typeof(decimal);
            dt.Columns[3].DataType = typeof(decimal);
            dt.Columns[4].DataType = typeof(decimal);
            dt.Columns[5].DataType = typeof(decimal);
            
            File.ReadLines(flPath).Skip(1)
                .Select(x => x.Split(';'))
                .ToList()
                .ForEach(line => dt.Rows.Add(line));

            DataTable tblFiltered = dt.AsEnumerable().Where(row => row.Field<decimal>("Low") > 0).OrderBy(row => row.Field<DateTime>("Date")).CopyToDataTable();

            return Task.FromResult(tblFiltered);
        }

        private async void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {
            labelWarning.Content = "";
            progressBar.IsIndeterminate = true;
            var result = await PopulateDataGrid();
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    for (int i = 0; i < progressBar.Maximum + 1; i++)
                        {
                            (progressBar).Value = i;
                        }
                }));
            });
            progressBar.IsIndeterminate = false;
            datagridStockData.ItemsSource = result.AsDataView();
        }

        public async Task<DataTable> SearchByCompanyName(string symbol)
        {

            DataTable dataTable = new DataTable();

            dataTable = await ReadCSV(filePath);

            DataTable searchResults = dataTable.AsEnumerable().Where(row => row.Field<string>("Symbol").Equals(symbol)).OrderBy(row => row.Field<DateTime>("Date")).CopyToDataTable();

            return searchResults;
        }

        private async void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                labelWarning.Content = "";
                var result = await SearchByCompanyName(textBoxCompanyName.Text);
                datagridStockData.ItemsSource = result.AsDataView();
            }
            catch
            {
                labelWarning.Content = "No data found for this company.";
            }                      
        }

        //calculating factorial part of the application 
        private async void ButtonCalculateFactorial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // retrieve user's input as an integer
                long number = long.Parse(textBoxFactorialInput.Text);                

                // Task to perform Factorial calculation in separate thread
                Task<long> factorialTask = Task.Run(() => Factorial(number));

                // wait for Task in separate thread to complete
                await factorialTask;

                // display result after Task in separate thread completes
                labelFactorialResult.Content = "Factorial of " + textBoxFactorialInput.Text + " is " + factorialTask.Result.ToString() + ".";
            }
            catch (Exception ex)
            {
                labelFactorialResult.Content = "Please enter a valid number.";
            }
        }

        public long Factorial(long number)
        {
            if (number == 1)
                return 1;
            else
                return number * Factorial(number - 1);
        }

        


    }
}
