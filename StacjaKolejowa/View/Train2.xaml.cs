using StacjaKolejowa.Model;
using StacjaKolejowa.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace StacjaKolejowa.View
{
    /// <summary>
    /// Interaction logic for Train2.xaml
    /// </summary>
    public partial class Train2 : UserControl
    {
        private Vector offset;
        private Train2 newTrain;
        private DoubleAnimationUsingPath animation;
        private DispatcherTimer timer = new DispatcherTimer();
        private Storyboard storyboard;
        private bool trainInMove;

        public Train2()
        {
            InitializeComponent();
        }

        public void MakeTrain2Move(int trainNumber, double[] x, double[] y)
        {
            newTrain = ViewModel.TrainViewModel.trainList2[trainNumber];
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure figure = new PathFigure();
            Model.ModbusProtocol.SetInputStatus(67, false);
            figure.StartPoint = new Point(x[0], y[0]);

            for (int i = 0; i <= x.Length - 1; i++)
            {
                figure.Segments.Add(new LineSegment()
                {
                    Point = new Point(x[i], y[i])
                });
            }

            pathGeometry.Figures.Add(figure);

            storyboard = new Storyboard();
            animation = new DoubleAnimationUsingPath();
            animation.Duration = TimeSpan.FromSeconds(15);
            animation.PathGeometry = pathGeometry;
            animation.Source = PathAnimationSource.X;
            Storyboard.SetTarget(animation, newTrain);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));
            storyboard.Children.Add(animation);
            storyboard.Begin();

            animation = new DoubleAnimationUsingPath();
            animation.Duration = TimeSpan.FromSeconds(15);
            animation.PathGeometry = pathGeometry;
            animation.Source = PathAnimationSource.Y;
            
            trainInMove = true;


            animation.Completed += Animation_Completed;
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Start();
            Storyboard.SetTarget(animation, newTrain);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.TopProperty));
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (trainInMove)
            {

                Char delimeter = ';';
                offset = VisualTreeHelper.GetOffset(newTrain);
                String[] subString = offset.ToString().Split(delimeter);
                Double xPoint = Double.Parse(subString[0]);
                Double yPoint = Double.Parse(subString[1]);

                
                switch (ModbusProtocol.availableTrack2)
                     {
                         case 403:
                             Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);                    
                            TrackSensorsViewModel.Track445(xPoint, yPoint);
                            TrackSensorsViewModel.Track403a_a(xPoint, yPoint);
                            TrackSensorsViewModel.Track403a_b(xPoint, yPoint);
                            TrackSensorsViewModel.Track403a_c(xPoint, yPoint);
                            TrackSensorsViewModel.Track403a_d(xPoint, yPoint);
                            TrackSensorsViewModel.Track403a_e(xPoint, yPoint);
                            TrackSensorsViewModel.Track446(xPoint, yPoint);
                             break;


                         case 406:
                             Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                             TrackSensorsViewModel.Track445(xPoint, yPoint);
                             TrackSensorsViewModel.Track406a(xPoint, yPoint);
                             TrackSensorsViewModel.Track406b(xPoint, yPoint);
                             TrackSensorsViewModel.Track406c(xPoint, yPoint);
                             TrackSensorsViewModel.Track446(xPoint, yPoint);

                             break;
                     }
                 
            }
            else
                timer.Stop();

        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("zakończenie animacji2");

            if (TrainViewModel.nextTrain == 1)
            {
                ViewModel.VisualizationViewModel.StartNewTrainReturn();
                TrainViewModel.nextTrain = 0;
            }
           

            foreach (int key in TrainViewModel.trainList.Keys)
            {
                Console.WriteLine(key.ToString());
            }
            VisualizationViewModel.RemoveTrain2(newTrain);
            trainInMove = false;
        }
    }
}
