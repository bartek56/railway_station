using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace StacjaKolejowa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string selectedPort;
        private string selectedBaudRate;
        private string selectedParity;
        private string selectedDataBits;
        private string selectedStopBits;        

        public MainWindow()
        {
            InitializeComponent();
            cbPort.ItemsSource = SerialPort.GetPortNames();
            
        }

        private void NewThread()
        {
            Model.ModbusProtocol.Slave(selectedPort, selectedBaudRate, selectedParity, selectedDataBits, selectedStopBits);
        }

        private void buttonClickSelect(object sender, RoutedEventArgs e)
        {
                String selectedPort = cbPort.SelectedValue.ToString();
                this.selectedPort = selectedPort;


                ComboBoxItem selectedItemBaudRate = (ComboBoxItem)(cbBaudRate.SelectedValue);
                this.selectedBaudRate = (string)(selectedItemBaudRate.Content);

                ComboBoxItem selectedItemParity = (ComboBoxItem)(cbParity.SelectedValue);
                this.selectedParity = (string)(selectedItemParity.Content);


                ComboBoxItem selectedItemDataBits = (ComboBoxItem)(cbDataBits.SelectedValue);
                this.selectedDataBits = (string)(selectedItemDataBits.Content);


                ComboBoxItem selectedItemStopBits = (ComboBoxItem)(cbStopBits.SelectedValue);
                this.selectedStopBits = (string)(selectedItemStopBits.Content);

                
                ViewModel.VisualizationViewModel.StartVisualization();
                ViewModel.ControlViewModel.ShowControlWindow();


                Thread t1 = new Thread(NewThread);
                t1.SetApartmentState(ApartmentState.STA);
                t1.IsBackground = true;
                t1.Start();


                Close();
        }
    }
}
