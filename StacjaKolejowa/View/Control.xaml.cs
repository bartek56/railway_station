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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StacjaKolejowa.View
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer timer2 = new DispatcherTimer();

        public Control()
        {
            InitializeComponent();
        }

        private void returnTrain_Click(object sender, RoutedEventArgs e)
        {
            Model.ModbusProtocol.SetInputStatus(67, true);
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            ViewModel.VisualizationViewModel.StartNewTrainReturn2();
        }

        private void nextTrain_Click(object sender, RoutedEventArgs e)
        {
            Model.ModbusProtocol.SetInputStatus(66, true);
            timer2.Tick += Timer2_Tick;
            timer2.Interval = TimeSpan.FromSeconds(5);
            timer2.Start();
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            ViewModel.VisualizationViewModel.StartNewTrain();
            timer2.Stop();
        }
    }
}
