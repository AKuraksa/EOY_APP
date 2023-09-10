using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
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
using RestSharp;
using EOY_WEBapp.Data;
using EOY_ENDPOINT.Dto;
using System.Text.Json;
using IDLoginEOY_APP.Data;

namespace EOY_ENDPOINT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly EOY_Functions _fce = new EOY_Functions();
        private readonly EOY_Values _values = new EOY_Values();
      

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.WORKPLACE_CONTROLLER, EOY_Values.GET));
                var request = new RestRequest();
                var response = myClient.Get(request);
                var content = response.Content;
                var allWorkplaces = JsonSerializer.Deserialize<List<WorkplaceDto>>(content);
                var getMacWorkplace = allWorkplaces.Where(x => x.Mac == _values.MY_DEVICE_MAC).ToList();

                if (getMacWorkplace.Count > 0)
                {
                    this.Hide();
                    MessageBox.Show("Tento počítač byl již zaregistrován");
                    App.Current.Shutdown();
                    
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MAC_txt.Text= _fce.MacFormatingString(_values.MY_DEVICE_MAC);
            device_txt.Text = _values.MY_DEVICE_MAC;
            IP_txt.Text = _values.MY_IPV4_ADRESS;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(workplaceName_txt.Text))
            {
                try
                {
                    var myClient = new RestClient(_fce.GetApiAdress(EOY_Values.WORKPLACE_CONTROLLER,EOY_Values.POST));
                    var request = new RestRequest();
                    request.AddQueryParameter("workplaceName", workplaceName_txt.Text);
                    request.AddQueryParameter("ipv4", IP_txt.Text);
                    request.AddQueryParameter("macAdress", MAC_txt.Text);
                    request.AddQueryParameter("deviceName", device_txt.Text);
                    var response = myClient.Post(request);
                    MessageBox.Show("Počítač byl zaregistrován");
                    App.Current.Shutdown();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Není vyplněno heslo");
            }
        }
    }
}
