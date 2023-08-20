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

        private readonly Styler _styler;
        bool firstClick = false;
        bool maximalized = true;
        public MainWindow(Styler styler)
        {
            InitializeComponent();
            _styler = styler;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _styler.CreateBoard();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape) 
            {
                Application.Current.Shutdown();
            }
        }

        private async void SideBarMover_Click(object sender, RoutedEventArgs e)
        {
            await MoveWithBar();
        }
        private async Task MoveWithBar()
        {
            if (!firstClick)
            {
                Sidebar.MaxWidth = Sidebar.Width;
                Sidebar.MinWidth = 30;
                firstClick = true;
            }

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
             timer.Tick +=  (sender, e) =>
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
       
    }
}
