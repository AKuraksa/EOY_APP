using EOY_APP.Forms;
using EOY_APP.SharedDTO;
using EOY_APP.Templates;
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
using System.Windows.Threading;

namespace EOY_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 




    public partial class MainWindow : Window

    {

        private SharedData _shared;
        private readonly Styler _styler = new Styler();
        bool firstClick = false;
        bool maximalized = false;

        public MainWindow(SharedData shared)
        {
            InitializeComponent();
            _shared = shared;

            var usernames = shared.LoginDtos;
            foreach( var user in usernames )
            {
                userLabel.Content = user.FullName;
            }
        }
        private async Task Clock()
        {
            var timeUtc = DateTime.UtcNow.ToString("t");
            var dateUtc = DateTime.UtcNow.ToString("d");
            var ticker = new DispatcherTimer();
            ticker.Interval = TimeSpan.FromSeconds(1);
            ticker.Tick += (sender, e) =>
            {
                clockLabel.Content = timeUtc;
                dateLabel.Content = dateUtc;
            };
            ticker.Start();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           await Clock();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }

        private async void SideBarMover_Click(object sender, RoutedEventArgs e)
        {



        }

        async Task MoveBar(object sender)
        {

            Grid Sidebar = (sender) as Grid;
            if (!firstClick)
            {
                Sidebar.MaxWidth = Sidebar.Width;
                Sidebar.MinWidth = 170;
                firstClick = true;
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += (sender, e) =>
            {
                if (maximalized)
                {
                    Sidebar.Width -= 10;
                    if (Sidebar.Width == Sidebar.MinWidth)
                    {
                        maximalized = false;
                        timer.Stop();
                    }

                }
                else
                {
                    Sidebar.Width += 10;
                    if (Sidebar.Width == Sidebar.MaxWidth)
                    {
                        maximalized = true;
                        timer.Stop();
                    }

                }
            };
            timer.Start();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await MoveBar(Sidebar);
        }

        private void admin_btn_Click(object sender, RoutedEventArgs e)
        {
            Admin administrator = new Admin(_shared);

            monitor_grid.Children.Add(administrator);
        }
    }
}
