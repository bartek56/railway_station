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

namespace StacjaKolejowa.View
{
    /// <summary>
    /// Interaction logic for RedLight.xaml
    /// </summary>
    public partial class RedLight : UserControl
    {
        public RedLight()
        {
            InitializeComponent();
        }

        public void Size(double width, double height)
        {
            train.Width = width;
            train.Height = height;
        }
    }
}
