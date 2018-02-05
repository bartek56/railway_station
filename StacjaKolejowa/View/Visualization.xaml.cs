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
    /// Interaction logic for Visualization.xaml
    /// </summary>
    public partial class Visualization : Window
    {
        private GreenLight greenLight;
        private RedLight redLight;
        private SolidColorBrush redColor = new SolidColorBrush();
        private SolidColorBrush greenColor = new SolidColorBrush();
        private SolidColorBrush whiteColor = new SolidColorBrush();
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer timer2 = new DispatcherTimer();

        public Visualization()
        {
            InitializeComponent();
            InitLight();
        }

        public void DoRemoveTrain(Train train)
        {
            canTrain1.Children.Remove(train);
        }

        public void DoRemoveTrain2(Train2 train)
        {
            canTrain2.Children.Remove(train);
        }

        public void DoStartNewTrain1(int trainNumber,double[] x,double[] y,int direction)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    ViewModel.TrainViewModel.TrainFactory1(trainNumber, 60, 30,direction);
                    ViewModel.TrainViewModel.SetTrainLocation1(trainNumber, 0, 0);
                    ViewModel.TrainViewModel.StartTrain1(trainNumber,x,y);
                    Train train = ViewModel.TrainViewModel.trainList[trainNumber];
                    canTrain1.Children.Add(train);
                });
            }
            else
            {
                ViewModel.TrainViewModel.TrainFactory1(trainNumber, 60, 30,direction);
                ViewModel.TrainViewModel.SetTrainLocation1(trainNumber, 0, 0);
                ViewModel.TrainViewModel.StartTrain1(trainNumber,x,y);
                Train train = ViewModel.TrainViewModel.trainList[trainNumber];
                canTrain1.Children.Add(train);
                

            }
        }

        public void DoStartNewTrain2(int trainNumber, double[] x, double[] y)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    ViewModel.TrainViewModel.TrainFactory2(trainNumber, 60, 30);
                    ViewModel.TrainViewModel.SetTrainLocation2(trainNumber, 0, 0);
                    ViewModel.TrainViewModel.StartTrain2(trainNumber, x, y);
                    Train2 train = ViewModel.TrainViewModel.trainList2[trainNumber];
                    canTrain2.Children.Add(train);

                    // usunięcie z animacji
                    //canvas.Children.Remove(train);
                });
            }
            else
            {
                ViewModel.TrainViewModel.TrainFactory2(trainNumber, 60, 30);
                ViewModel.TrainViewModel.SetTrainLocation2(trainNumber, 0, 0);
                ViewModel.TrainViewModel.StartTrain2(trainNumber, x, y);
                Train2 train = ViewModel.TrainViewModel.trainList2[trainNumber];
                canTrain2.Children.Add(train);
            }
        }

        public void DoTurnpikePutUp(double speed)
        {

            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    if (timer2.IsEnabled)
                        timer2.Stop();
                    timer.Tick += Timer_Tick;
                    Model.ModbusProtocol.SetDataCoils(18, false);
                    Model.ModbusProtocol.SetInputStatus(70, false);
                    Model.ModbusProtocol.SetInputStatus(69, false);
                    timer.Interval = TimeSpan.FromSeconds(speed);
                    timer.Start();
                });
            }
            else
            {
                if (timer2.IsEnabled)
                    timer2.Stop();
                timer.Tick += Timer_Tick;
                Model.ModbusProtocol.SetDataCoils(18, false);
                Model.ModbusProtocol.SetInputStatus(70, false);
                Model.ModbusProtocol.SetInputStatus(69, false);
                timer.Interval = TimeSpan.FromSeconds(speed);
                timer.Start();
            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            
            turnpike1.Value -= 1;
            turnpike2.Value -= 1;
            
            if (turnpike1.Value <= turnpike1.Minimum || turnpike2.Value <= turnpike2.Minimum)
            {
                timer.Stop();
                Model.ModbusProtocol.SetInputStatus(70, true); // otwarta rogatka
            }
                
        }

        public void DoTurnpikePutDown(double speed)
        {

            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    if (timer.IsEnabled)
                        timer.Stop();
                    timer2.Tick += Timer2_Tick;
                    timer2.Interval = TimeSpan.FromSeconds(speed);
                    Model.ModbusProtocol.SetInputStatus(70, false);
                    Model.ModbusProtocol.SetInputStatus(69, false);
                    timer2.Start();
                });
            }
            else
            {
                if (timer.IsEnabled)
                    timer.Stop();
                timer2.Tick += Timer2_Tick;
                timer2.Interval = TimeSpan.FromSeconds(speed);
                Model.ModbusProtocol.SetInputStatus(70, false);
                Model.ModbusProtocol.SetInputStatus(69, false);
                timer2.Start();
            }
  
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            // podnoszenie rogatki
            turnpike1.Value += 1;
            turnpike2.Value += 1;

            if (turnpike1.Value >= turnpike1.Maximum || turnpike2.Value >= turnpike2.Maximum)
            {
                timer2.Stop();
                Model.ModbusProtocol.SetInputStatus(69, true);
            }
            
        }

        public void DoWeightOnWhite()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    whiteColor.Color = Colors.White;
                    weight.Stroke = whiteColor;
                });
            }
            else
            {
                whiteColor.Color = Colors.White;
                weight.Stroke = whiteColor;
            }
        }

        public void DoWeightOnGreen()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    greenColor.Color = Colors.Green;
                    weight.Stroke = greenColor;
                });
            }
            else
            {
                greenColor.Color = Colors.Green;
                weight.Stroke = greenColor;
            }
        }

        public void DoWeightOnRed()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    redColor.Color = Colors.Red;
                    weight.Stroke = redColor;
                });
            }
            else
            {
                redColor.Color = Colors.Red;
                weight.Stroke = redColor;
            }
        }

        public void DoShowMessage(string text)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    info.Text = text;
                    info.Visibility = Visibility.Visible;

                    info2.Text = text;
                    info2.Visibility = Visibility.Visible;

                });
            }
            else
            {
                info.Text = text;
                info.Visibility = Visibility.Visible;

                info2.Text = text;
                info2.Visibility = Visibility.Visible;
            }
        }

        public void DoHideMessage()
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    info.Visibility = Visibility.Hidden;
                    info2.Visibility = Visibility.Hidden;
                });
            }
            else
            {
                info.Visibility = Visibility.Hidden;
                info2.Visibility = Visibility.Hidden;
            }
        }

        public void DoTrackOnRed(String number)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    redColor.Color = Colors.Red;
                    ChangeColor(number, redColor);
                });
            }
            else
            {
                redColor.Color = Colors.Red;
                ChangeColor(number, redColor);
            }
        }

        public void DoTrackOnGreen(String number)
        {

            
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    greenColor.Color = Colors.Green;
                    ChangeColor(number, greenColor);
                });
            }
            else
            {
                greenColor.Color = Colors.Green;
                ChangeColor(number, greenColor);
            }
        }

        public void DoTrackOnWhite(String number)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    whiteColor.Color = Colors.White;
                    ChangeColor(number, whiteColor);
                });
            }
            else
            {
                whiteColor.Color = Colors.White;
                ChangeColor(number, whiteColor);
            }
        }

        private void ChangeColor(String number, SolidColorBrush color)
        {
            
            switch (number)
            {
                case "408": track408.Stroke = color; break;
                case "411": track411.Stroke = color; break;
                case "440": track440.Stroke = color; break;
                case "441": track441.Stroke = color; break;
                case "442": track442.Stroke = color; break;
                case "444": track444.Stroke = color; break;
                case "410": track410.Stroke = color; break;
                case "412": track412.Stroke = color; break;


                case "403a_a": track403a_a.Stroke = color; break;
                case "403a_b": track403a_b.Stroke = color; break;
                case "403a_c": track403a_c.Stroke = color; break;
                case "403a_d": track403a_d.Stroke = color; break;
                case "403a_e": track403a_e.Stroke = color; break;

                case "406a": track406a.Stroke = color; break;
                case "406b": track406b.Stroke = color; break;
                case "406c": track406c.Stroke = color; break;

                case "445": track445.Stroke = color; break;
                case "446": track446.Stroke = color; break;

                case "401a": track401a.Stroke = color; break;
                case "401b": track401b.Stroke = color; break;
                case "401c": track401c.Stroke = color; break;
                case "401d": track401d.Stroke = color; break;
                case "401e": track401e.Stroke = color; break;

                case "405a": track405a.Stroke = color; break;
                case "405b": track405b.Stroke = color; break;
                case "405c": track405c.Stroke = color; break;
                case "405d": track405d.Stroke = color; break;
                case "405e": track405e.Stroke = color; break;

                case "403a": track403a.Stroke = color; break;
                case "403b": track403b.Stroke = color; break;
                case "403c": track403c.Stroke = color; break;
                case "403d": track403d.Stroke = color; break;
                case "403e": track403e.Stroke = color; break;

                case "404a": track404a.Stroke = color; break;
                case "404b": track404b.Stroke = color; break;
                case "404c": track404c.Stroke = color; break;
                case "404d": track404d.Stroke = color; break;
                case "404e": track404e.Stroke = color; break;

                case "402a": track402a.Stroke = color; break;
                case "402b": track402b.Stroke = color; break;
                case "402c": track402c.Stroke = color; break;
                case "402d": track402d.Stroke = color; break;
                case "402e": track402e.Stroke = color; break;
            }
        }

        public void DoChangeLightOnRed(int number)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    switch (number)
                    {
                        case 1: redLight = new RedLight(); canLight408.Children.Clear(); redLight.Size(50, 50); canLight408.Children.Add(redLight); break;
                        case 2: redLight = new RedLight(); canLight404.Children.Clear(); redLight.Size(50, 50); canLight404.Children.Add(redLight); break;
                        case 3: redLight = new RedLight(); canLight402.Children.Clear(); redLight.Size(50, 50); canLight402.Children.Add(redLight); break;
                        case 4: redLight = new RedLight(); canLight401.Children.Clear(); redLight.Size(50, 50); canLight401.Children.Add(redLight); break;
                    }
                });
            }
        }

        public void DoChangeLightOnGreen(int number)
        {
            if (!CheckAccess())
            {
                Dispatcher.Invoke(delegate
                {
                    switch (number)
                    {
                        case 1: greenLight = new GreenLight(); canLight408.Children.Clear(); greenLight.Size(50, 50); canLight408.Children.Add(greenLight); break;
                        case 2: greenLight = new GreenLight(); canLight404.Children.Clear(); greenLight.Size(50, 50); canLight404.Children.Add(greenLight); break;
                        case 3: greenLight = new GreenLight(); canLight402.Children.Clear(); greenLight.Size(50, 50); canLight402.Children.Add(greenLight); break;
                        case 4: greenLight = new GreenLight(); canLight401.Children.Clear(); greenLight.Size(50, 50); canLight401.Children.Add(greenLight); break;
                    }
                });

            }
        }

        private void InitLight()
        {
            redLight = new RedLight();
            redLight.Size(50, 50);
            canLight408.Children.Add(redLight);

            redLight = new RedLight();
            redLight.Size(50, 50);
            canLight404.Children.Add(redLight);

            redLight = new RedLight();
            redLight.Size(50, 50);
            canLight402.Children.Add(redLight);

            redLight = new RedLight();
            redLight.Size(50, 50);
            canLight401.Children.Add(redLight);
        }

    }
}
