using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace EOY_APP.Templates
{
    public class Styler
    {

        public async Task CreateBoard(Grid DataSourceWindow,
            Grid panel,
            Label workplaceName, 
            Label deviceName,
            Image state,
            Button accept,
            Button decline
           )
        {




            #region BUTTON PROPERITIES
            accept.Content = "Přijmout";
            decline.Content = "Odmítnout";

            #endregion#


            #region PANEL PROPERITIES

            panel.Children.Add(workplaceName);
            panel.Children.Add(deviceName);
            panel.Children.Add(state);
            panel.Children.Add(accept);
            panel.Children.Add(decline);

            DataSourceWindow.Children.Add(panel);

            #endregion


            GetBoardStyle(Grid panel,
            Label workplaceName,
            Label deviceName,
            Image state,
            Button accept,
            Button decline);
        }

        public async Task GetBoardStyle(Grid panel,
            Label workplaceName,
            Label deviceName,
            Image state,
            Button accept,
            Button decline)
        {

        }
    }
}
