using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
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
using EOY_API.Tables;
using EOY_WEBapp.Data;
using IDLoginEOY_APP.Data;
using RestSharp;

namespace IDLoginEOY_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EOY_Functions _fce= new EOY_Functions();
        private readonly EOY_Values _values = new EOY_Values();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.WORKERS_CONTROLLER, EOY_Values.GET));
                var request = new RestRequest();
                var response = myClient.Get(request);
                var content = response.Content;

                var workersList = JsonSerializer.Deserialize<List<Worker>>(content);
                var passwordExist = workersList.Where(x => x.AuthentificatorID == authentificatorId_txt.Password).Any();
                if (passwordExist)
                {
                    var user = workersList.Where(x => x.AuthentificatorID == authentificatorId_txt.Password).FirstOrDefault();

                    var workplaceCLient = new RestClient(_fce.GetApiAdress(EOY_Values.WORKERS_CONTROLLER, EOY_Values.PATCH));
                    var workplaceRequest = new RestRequest();
                    workplaceRequest.AddQueryParameter("workerID", user.ID);
                    workplaceRequest.AddQueryParameter("mac", _values.MyMacAdress);
                    var responseWorkplace = workplaceCLient.Patch(workplaceRequest);
                    this.Hide();
                }
                else
                    MessageBox.Show("Toto ID neexistuje");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
