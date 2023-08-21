using EOY_APP.Dto;
using EOY_APP.SharedDTO;
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
using System.Windows.Shapes;

namespace EOY_APP.Forms
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        

         int port = 7106;
         RestClient myClient =new  RestClient();
         List<LoginDto> _loginDto = new List<LoginDto>();
         private SharedData sharedData=new SharedData();


        public Login()
        {
            InitializeComponent();

        }

        private void username_txt_Kopírovat1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Login_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(username_txt.Text) && !string.IsNullOrWhiteSpace(password_txt.Password))
            {

                myClient = new RestClient($"https://localhost:{port}/FindUser");
                var request = new RestRequest();
                request.AddQueryParameter("username", username_txt.Text);
                request.AddQueryParameter("password", password_txt.Password);
                try
                {
                    var response = await myClient.GetAsync(request);
                    var content = response.Content;

                    var list = JsonSerializer.Deserialize<List<LoginDto>>(content);

                    SharedData sharedData = new SharedData();
                    sharedData.LoginDtos.AddRange(list);

                 
                    
                    if (sharedData.LoginDtos.Count ==1)
                    {
                        MainWindow mw = new MainWindow(sharedData);
                        mw.Show();
                    }
                    else
                    {
                        MessageBox.Show("Špatné přihlašovací údaje");
                        password_txt.Clear();
                        username_txt.Clear();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Uživatelské jméno nebo heslo je prázdné");
            }
        }
    }
}
