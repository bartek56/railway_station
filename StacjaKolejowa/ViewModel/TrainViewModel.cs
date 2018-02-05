using StacjaKolejowa.Model;
using StacjaKolejowa.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace StacjaKolejowa.ViewModel
{
    static class TrainViewModel
    {

        public static List<int> queueTrainTo404Track = new List<int>();
        public static List<int> queueTrainTo402Track = new List<int>();
        public static List<int> queueTrainTo401Track = new List<int>();
        
        public static bool trainWait;
        private static DispatcherTimer timer = new DispatcherTimer();

        
        public static int nextTrain;
        public static Dictionary<int, Train> trainList = new Dictionary<int, Train>();
        public static Dictionary<int, Train2> trainList2 = new Dictionary<int, Train2>();

        public static Train TrainFactory1(int trainNumber,double width, double height, int direction)
        {
            Train train = new Train(direction, trainNumber);
            trainList.Add(trainNumber, train);
            train.Width = width;
            train.Height = height;
            return train;
        }

        public static void SetTrainLocation1(int trainNumber, double x, double y)
        {
            Train train = trainList[trainNumber];
            Canvas.SetLeft(train, x);
            Canvas.SetTop(train, y);
        }

        public static void StartTrain1(int trainNumber, double[] xTrack, double[] yTrack)
        {
            Train train = trainList[trainNumber];
            train.MakeTrainMove(xTrack, yTrack);
        }

        public static void StartTrain2(int trainNumber, double[] xTrack, double[] yTrack)
        {
            Train2 train = trainList2[trainNumber];
            train.MakeTrain2Move(trainNumber, xTrack, yTrack);
        }

        public static Train2 TrainFactory2(int trainNumber, double width, double height)
        {
            Train2 train = new Train2();
            trainList2.Add(trainNumber, train);
            train.Width = width;
            train.Height = height;
            return train;
        }

        public static void SetTrainLocation2(int trainNumber, double x, double y)
        {
            Train2 train = trainList2[trainNumber];
            Canvas.SetLeft(train, x);
            Canvas.SetTop(train, y);
        }
     
    }
}
