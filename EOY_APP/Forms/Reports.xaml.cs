using EOY_APP.Data;
using EOY_APP.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace EOY_APP.Forms
{
    /// <summary>
    /// Interakční logika pro Reports.xaml
    /// </summary>
    public partial class Reports : UserControl
    {
        private readonly Parameters _parameter = new Parameters();



        public Reports()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await refreshGrid();
        }

        private async void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            await refreshGrid();
        }
        private async Task refreshGrid()
        {
            var myClient = new RestClient($"{_parameter.GetApiAdress()}/GetAllErrors");
            var request = new RestRequest();
            var response = myClient.Get(request);
            var content = response.Content;
            var listErrors = JsonSerializer.Deserialize<List<HistoryErrorDto>>(content);
            reportGrid.ItemsSource = listErrors;

            sumCountErrors.Content = listErrors.Count.ToString();

            var currentDate = DateTime.UtcNow;
            var thisMonthErrors = listErrors.Where(error => error.Date.Year == currentDate.Year && error.Date.Month == currentDate.Month).ToList();
            sumCountErrorsMonthly.Content = thisMonthErrors.Count.ToString();
            sumCountErrorsMonthly.Content = thisMonthErrors.Count.ToString();

            var mostFrequentError = listErrors
                .GroupBy(e => e.TypeError)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .FirstOrDefault();
            oftenlyError.Content = mostFrequentError;

            var mostFrequentWorkplace = listErrors
               .GroupBy(e => e.Workplace)
               .OrderByDescending(group => group.Count())
               .Select(group => group.Key)
               .FirstOrDefault();
            oftenlyErrorWorkplace.Content = mostFrequentWorkplace;
        }
    }
}
