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
            var time = DateTime.Now.ToString("t");
            var date = DateTime.Now.ToString("d");
            var ticker = new DispatcherTimer();
            ticker.Interval = TimeSpan.FromSeconds(1);
            ticker.Tick += (sender, e) =>
            {
                clockLabel.Content = time;
                dateLabel.Content = date;
            };
            ticker.Start(); ;
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
            await Mover(adminPanel);
        }

       private async Task Mover(Border bdr)
        {
          
            if (bdr != null)
            {
                var moverdown = new DispatcherTimer();
                var moverup = new DispatcherTimer();

                moverdown.Interval = TimeSpan.FromMilliseconds(10);
                moverup.Interval = TimeSpan.FromMilliseconds(10);
                if (bdr.Height == bdr.MaxHeight)
                    moverup.Start();
                else if (bdr.Height == bdr.MinHeight)
                    moverdown.Start();

                moverdown.Tick += (sender, e) =>
                {
                    bdr.Height += 10;
                    if (bdr.Height == bdr.MaxHeight)
                        moverdown.Stop();
                };

                moverup.Tick += (sender, e) =>
                {
                    bdr.Height -= 10;
                    if (bdr.Height == bdr.MinHeight)
                        moverup.Stop();
                };
            }
           
        }

        private void CreateUser_Click(object sender, RoutedEventArgs e)
        {
            var createUser = new CreateUser();
            wall.Children.Clear();
            wall.Children.Add(createUser);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var createUser = new EditUsers();
            wall.Children.Clear();
            wall.Children.Add(createUser);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var createUser = new Reports();
            wall.Children.Clear();
            wall.Children.Add(createUser);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var createUser = new EditIssues();
            wall.Children.Clear();
            wall.Children.Add(createUser);
        }
    }
}
