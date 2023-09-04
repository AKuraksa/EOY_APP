using EOY_APP.Data;
using EOY_APP.Dto;
using EOY_APP.SharedDTO;
using System.Text.Json;
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
    /// Interakční logika pro EditUsers.xaml
    /// </summary>
    public partial class EditUsers : UserControl
    {
        private readonly Parameters _parameter = new Parameters();
        public EditUsers()
        {
            InitializeComponent();
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            await RefreshList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ltboxUsers.SelectedIndex!=0 && ltboxUsers.SelectedIndex > 0)
            {
                ltboxUsers.SelectedIndex--;
                selectedId.Content = (ltboxUsers.SelectedIndex+1).ToString();
            } 
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ltboxUsers.SelectedIndex != ltboxUsers.Items.Count)
            {
                ltboxUsers.SelectedIndex++;
                selectedId.Content = (ltboxUsers.SelectedIndex+1).ToString();
            }   
        }
        private void ltboxUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            if (ltboxUsers.SelectedItem != null)
            {
                var selectedLoginDto = ltboxUsers.SelectedItem as LoginDto;
                if (selectedLoginDto != null)
                {
                    firstName_txt.Text = selectedLoginDto.FirstName;
                    lastName_txt.Text = selectedLoginDto.LastName;
                    username_txt.Text = selectedLoginDto.Username;
                    email_txt.Text = selectedLoginDto.Email;
                    password_txt.Password=selectedLoginDto.Password;
                    passwordAgain_txt.Password=selectedLoginDto.Password;
                    permission_chk.IsChecked = selectedLoginDto.Permission;
                }
                selectedId.Content=(ltboxUsers.SelectedIndex+1).ToString();
            }
        }
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ltboxUsers.SelectedItem != null)
            {
                var selectedLoginDto = ltboxUsers.SelectedItem as LoginDto;

                if (MessageBoxResult.Yes == MessageBox.Show($"Opravdu chcete smazat uživatele {selectedLoginDto.FullName}?","Dotaz",MessageBoxButton.YesNo,MessageBoxImage.Question))
                {
                        try
                        {
                            var myClient = new RestClient($"{_parameter.GetApiAdress()}/DeleteByID");
                            var request = new RestRequest();
                            request.AddQueryParameter("id", selectedLoginDto.id);
                            var response = myClient.Delete(request);
                            MessageBox.Show($"Uživatel {selectedLoginDto.FullName} byl odstraněn");
                            await RefreshList();
                            ltboxUsers.SelectedIndex = 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                }
            }
        }
        private async Task RefreshList()
        {
            ltboxUsers.SelectedIndex = 0;
            var myClient = new RestClient($"{_parameter.GetApiAdress()}/All_Data_FROM_Logins");
            var request = new RestRequest();
            try
            {
                var response = await myClient.GetAsync(request);
                var content = response.Content;
                var usersList = JsonSerializer.Deserialize<List<LoginDto>>(content);
                ltboxUsers.ItemsSource = usersList;
                countId.Content = usersList.Count;
                selectedId.Content = (ltboxUsers.SelectedIndex+1).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private  async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (ltboxUsers.SelectedItem != null)
            {
                try
                {
                    
                    var DtoDataSource = ltboxUsers.SelectedItem as LoginDto;

                    var permissionValue = permission_chk.IsChecked ?? false;
                    var myClient = new RestClient($"{_parameter.GetApiAdress()}/DataChangeOfUser");
                    var request = new RestRequest();
                    if (password_txt.Password == passwordAgain_txt.Password)
                    {
                        request.AddQueryParameter("password", password_txt.Password);
                    }
                    else
                    {
                        MessageBox.Show("Hesla se neshodují");
                        
                    }
                    request.AddQueryParameter("idSet", DtoDataSource.id);
                    request.AddQueryParameter("username", username_txt.Text);
                    request.AddQueryParameter("email", email_txt.Text);
                    request.AddQueryParameter("firstName", firstName_txt.Text);
                    request.AddQueryParameter("lastName", lastName_txt.Text);
                    request.AddQueryParameter("permission", permissionValue);

                    var response = myClient.Patch(request);
                    await RefreshList();
                    MessageBox.Show("Změněno");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
              
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (ltboxUsers.SelectedIndex != 0 && ltboxUsers.SelectedIndex > 0)
                {
                    ltboxUsers.SelectedIndex--;
                    selectedId.Content = (ltboxUsers.SelectedIndex + 1).ToString();
                }
            }
            if (e.Key == Key.Right)
            {
                if (ltboxUsers.SelectedIndex != ltboxUsers.Items.Count)
                {
                    ltboxUsers.SelectedIndex++;
                    selectedId.Content = (ltboxUsers.SelectedIndex + 1).ToString();
                }
            }

        }

       
    }
}
