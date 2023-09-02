using EOY_APP.Data;
using RestSharp;
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

namespace EOY_APP.Forms
{
    /// <summary>
    /// Interakční logika pro CreateUser.xaml
    /// </summary>
    public partial class CreateUser : UserControl
    {
        private readonly Parameters _parameter = new Parameters();

        public CreateUser()
        {
            InitializeComponent();
        }

        private async void createUser_btn_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(userName_txt.Text)
            &&!string.IsNullOrWhiteSpace(password_txt.Password)
            &&!string.IsNullOrWhiteSpace(passwordAgain_txt.Password)
            &&!string.IsNullOrWhiteSpace(email_txt.Text)
            &&!string.IsNullOrWhiteSpace(firstName_txt.Text)
            && !string.IsNullOrWhiteSpace(lastName_txt.Text))
            {
                if (password_txt.Password == passwordAgain_txt.Password)
                {
                    try
                    {
                        var permissionValue = permission_chk.IsChecked ?? false;
                        var myClient = new RestClient($"{_parameter.GetApiAdress()}/CreateLogin");
                        var request = new RestRequest();
                        request.AddQueryParameter("username", userName_txt.Text);
                        request.AddQueryParameter("password", password_txt.Password);
                        request.AddQueryParameter("email", email_txt.Text);
                        request.AddQueryParameter("firstName", firstName_txt.Text);
                        request.AddQueryParameter("lastName", lastName_txt.Text);
                        request.AddQueryParameter("admin", permissionValue);

                        var response = myClient.Post(request);
                        await ClearBoxes();
                        MessageBox.Show("Uživatel byl vytvořen");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Hesla nejsou totožné","Chyba",MessageBoxButton.OK,MessageBoxImage.Error);
               
            }
            
           

        }
        private async Task ClearBoxes()
        {
            userName_txt.Text =
               password_txt.Password =
               passwordAgain_txt.Password =
               email_txt.Text =
               lastName_txt.Text =
               firstName_txt.Text =
               "";
            permission_chk.IsChecked = false;
        }
    }
}
