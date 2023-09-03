using EOY_APP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
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
using System.Windows.Threading;

namespace EOY_APP.Forms
{
    /// <summary>
    /// Interakční logika pro EditIssues.xaml
    /// </summary>
    /// 


    public partial class EditIssues : UserControl
    {
        private readonly Parameters _parameter = new Parameters();

        public EditIssues()
        {
            InitializeComponent();
        }

        private async Task TurnOnIssue(object sender,EventArgs e)
        {
            var btn = (Button)sender;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (sender, e) =>
            {
                if (btn.Background == Brushes.GreenYellow)
                    btn.Background = Brushes.Orange;
                else if (btn.Background == Brushes.Orange)
                    btn.Background = Brushes.GreenYellow;
            };
            if (btn.Background == Brushes.White )
            {
                btn.Background= Brushes.GreenYellow;

                timer.Interval = TimeSpan.FromSeconds(3); ;
                
                timer.Start();
            }
            else
            {
                timer.Stop();
                btn.Background = Brushes.White;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
           await TurnOnIssue(sender,e);
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await TurnOnIssue(sender, e);
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            await TurnOnIssue(sender, e);
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            await TurnOnIssue(sender, e);
        }
    }
}
