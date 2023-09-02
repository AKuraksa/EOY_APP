using EOY_APP.Dto;
using EOY_APP.SharedDTO;
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
    /// Interakční logika pro admin.xaml
    /// </summary>
    public partial class Admin : UserControl
    {
        private SharedData _shared;

        public Admin(SharedData shared)
        {
            InitializeComponent();
            _shared = shared;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //  var userInfo = _shared.LoginDtos;

            //    foreach (var item in userInfo)
            //    {
            //        nameUser.Text = $"{item.FirstName} {item.LastName}";
            //        idUser.Text = $"{item.id}";
            //        mailUser.Text = $"{item.Email}";
            //    }
        }

    private void Button_Click(object sender, RoutedEventArgs e)
        {
            var edit = new EditUsers();
            panels.Children.Add(edit);
            
          
            
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var edit = new CreateUser();
            panels.Children.Add(edit);
        }
    }
}
