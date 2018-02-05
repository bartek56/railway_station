using StacjaKolejowa.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaKolejowa.ViewModel
{
    static class ControlViewModel
    {
        private static Control controlWindow;
        public static void ShowControlWindow()
        {
            controlWindow = new Control();
            controlWindow.Show();
        }

    }
}
