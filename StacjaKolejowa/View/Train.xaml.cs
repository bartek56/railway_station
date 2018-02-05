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
    /// Interaction logic for Train.xaml
    /// </summary>
    public partial class Train : UserControl
    {

        private Vector offset;
        private Train newTrain;
        private DoubleAnimationUsingPath animation;
        public DispatcherTimer timer = new DispatcherTimer();
        public Storyboard storyboard;
        private bool trainInMove;
        private int trainNumber;
        private int direction;
        public Train(int direction, int trainNumber)
        {
            this.trainNumber = trainNumber;
            this.direction = direction;
            InitializeComponent();

        }

        public void MakeTrainMove(double[] x, double[] y)
        {
            Model.ModbusProtocol.SetInputStatus(66, false);
            newTrain = ViewModel.TrainViewModel.trainList[trainNumber];
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure figure = new PathFigure();

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

                switch (ModbusProtocol.availableTrack)
                {
                    case 401:
                        Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                        CheckTrack401(xPoint,yPoint);
                        break;
                    case 403:
                        Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                        CheckTrack403(xPoint,yPoint);
                        break;
                    case 405:
                        Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                        CheckTrack405(xPoint, yPoint);
                        break;
                    case 404:
                        Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                        CheckTrack404(xPoint, yPoint);
                        break;
                    case 402:
                        Console.WriteLine("x: {0} y:{1}", xPoint, yPoint);
                        CheckTrack402(xPoint, yPoint);
                        break;

                }

            }
            else
                timer.Stop();
            
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            Console.WriteLine("zakończenie animacji");

            foreach (int key in TrainViewModel.trainList.Keys)
            {
                Console.WriteLine(key.ToString());
            }

            if (TrainViewModel.nextTrain == 2)
            {
                TrainViewModel.nextTrain = 0;
                ViewModel.VisualizationViewModel.StartNewTrain2();
            }
           
            VisualizationViewModel.RemoveTrain(newTrain);
            
            trainInMove = false;
        }


        private void CheckTrack401(double xPoint, double yPoint)
        {
            if (ModbusProtocol.GetDataCoils(4) == false && xPoint < 500 && xPoint != 0 && direction == 0)
            {
                storyboard.Pause();
                timer.Stop();
                TrainViewModel.queueTrainTo401Track.Add(trainNumber);
            }

            TrackSensorsViewModel.Track408(xPoint, yPoint);
            TrackSensorsViewModel.Track411(xPoint, yPoint);
            TrackSensorsViewModel.Track401a(xPoint, yPoint);
            TrackSensorsViewModel.Track401b(xPoint, yPoint);
            TrackSensorsViewModel.Track401c(xPoint, yPoint);
            TrackSensorsViewModel.Track401d(xPoint, yPoint);
            TrackSensorsViewModel.Track401e(xPoint, yPoint);
            TrackSensorsViewModel.Track440(xPoint, yPoint);
            TrackSensorsViewModel.Track441(xPoint, yPoint);
            TrackSensorsViewModel.Track444(xPoint, yPoint);
        }

        private void CheckTrack403(double xPoint, double yPoint)
        {
            TrackSensorsViewModel.Track408(xPoint, yPoint);
            TrackSensorsViewModel.Track410(xPoint, yPoint);
            TrackSensorsViewModel.Track403a(xPoint, yPoint);
            TrackSensorsViewModel.Track403b(xPoint, yPoint);
            TrackSensorsViewModel.Track403c(xPoint, yPoint);
            TrackSensorsViewModel.Track403d(xPoint, yPoint);
            TrackSensorsViewModel.Track403e(xPoint, yPoint);
            TrackSensorsViewModel.Track442(xPoint, yPoint);
            TrackSensorsViewModel.Track444(xPoint, yPoint);
        }

        private void CheckTrack405(double xPoint, double yPoint)
        {
            TrackSensorsViewModel.Track408(xPoint, yPoint);
            TrackSensorsViewModel.Track410(xPoint, yPoint);
            TrackSensorsViewModel.Track405a(xPoint, yPoint);
            TrackSensorsViewModel.Track405b(xPoint, yPoint);
            TrackSensorsViewModel.Track405c(xPoint, yPoint);
            TrackSensorsViewModel.Track405d(xPoint, yPoint);
            TrackSensorsViewModel.Track405e(xPoint, yPoint);
            TrackSensorsViewModel.Track442(xPoint, yPoint);
            TrackSensorsViewModel.Track444(xPoint, yPoint);
        }

        private void CheckTrack404(double xPoint, double yPoint)
        {
            if (ModbusProtocol.GetDataCoils(2) == false && xPoint < 500 && xPoint != 0)
            {
                TrainViewModel.queueTrainTo404Track.Add(trainNumber);
                storyboard.Pause();
                timer.Stop();

            }


            TrackSensorsViewModel.Track408(xPoint, yPoint);
            TrackSensorsViewModel.Track411(xPoint, yPoint);
            TrackSensorsViewModel.Track412(xPoint, yPoint);
            TrackSensorsViewModel.Track404a(xPoint, yPoint);
            TrackSensorsViewModel.Track404b(xPoint, yPoint);
            TrackSensorsViewModel.Track404c(xPoint, yPoint);
            TrackSensorsViewModel.Track404d(xPoint, yPoint);
            TrackSensorsViewModel.Track404e(xPoint, yPoint);
            TrackSensorsViewModel.Track441(xPoint, yPoint);
            TrackSensorsViewModel.Track444(xPoint, yPoint);
        }


        private void CheckTrack402(double xPoint, double yPoint)
        {
            if (ModbusProtocol.GetDataCoils(3) == false && xPoint < 500 && xPoint != 0)
            {
                storyboard.Pause();
                timer.Stop();
                TrainViewModel.trainWait = true;
                TrainViewModel.queueTrainTo402Track.Add(trainNumber);
            }

            TrackSensorsViewModel.Track408(xPoint, yPoint);
            TrackSensorsViewModel.Track411(xPoint, yPoint);
            TrackSensorsViewModel.Track412(xPoint, yPoint);
            TrackSensorsViewModel.Track402a(xPoint, yPoint);
            TrackSensorsViewModel.Track402b(xPoint, yPoint);
            TrackSensorsViewModel.Track402c(xPoint, yPoint);
            TrackSensorsViewModel.Track402d(xPoint, yPoint);
            TrackSensorsViewModel.Track402e(xPoint, yPoint);
            TrackSensorsViewModel.Track440(xPoint, yPoint);
            TrackSensorsViewModel.Track441(xPoint, yPoint);
            TrackSensorsViewModel.Track444(xPoint, yPoint);
        }
        
        

    }
}

