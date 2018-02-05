using StacjaKolejowa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaKolejowa.ViewModel
{
    static class VisualizationViewModel
    {
        public static View.Visualization visualization;
        private static int num;

        public static void StartVisualization()
        {
            visualization = new View.Visualization();
            visualization.Show();
        }

        public static void StartNewTrain()
        {
            
            if (ModbusProtocol.GetDataCoils(1) == true)
            {
                TrainViewModel.nextTrain = 2;
                num++;
                switch (ModbusProtocol.availableTrack)
                {
                    case 401:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack401, TrackSensorsViewModel.yTrack401,1); break;
                    case 403:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack403, TrackSensorsViewModel.yTrack403,1); break;
                    case 405:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack405, TrackSensorsViewModel.yTrack405,1); break;
                }
                ModbusProtocol.SetDataCoils(19, false);
            }
            else
            {
                ViewModel.VisualizationViewModel.ShowMessage("Error");
                ModbusProtocol.SetDataCoils(16, true);
                ModbusProtocol.SetDataCoils(19, false);
            }

        }

        public static void TurnpikePutDown(double speed)
        {
            visualization.DoTurnpikePutDown(speed);
        }

        public static void TurnpikePutUp(double speed)
        {
            visualization.DoTurnpikePutUp(speed);
        }

        public static void StartNewTrain2()
        {
                switch (ModbusProtocol.availableTrack2)
                {
                    case 406:
                        visualization.DoStartNewTrain2(num, TrackSensorsViewModel.xTrack406, TrackSensorsViewModel.yTrack406); break;
                    case 403:
                        visualization.DoStartNewTrain2(num, TrackSensorsViewModel.xTrack403a, TrackSensorsViewModel.yTrack403a); break;
                }
        }

        public static void StartNewTrainReturn2()
        {

            if (Model.ModbusProtocol.GetInputStatus(69))
            {
                switch (Model.ModbusProtocol.availableTrack)
                {
                    case 404:
                        if (ViewModel.TrainViewModel.queueTrainTo404Track.Count < 1)
                            StartTrainHelp();
                        else
                        {
                            Model.ModbusProtocol.SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }
                        break;
                    case 402:
                        if (ViewModel.TrainViewModel.queueTrainTo402Track.Count < 1)
                            StartTrainHelp();
                        else
                        {
                            Model.ModbusProtocol.SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }

                        break;
                    case 401:
                        if (ViewModel.TrainViewModel.queueTrainTo401Track.Count < 1)
                            StartTrainHelp();
                        else
                        {
                            Model.ModbusProtocol.SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }
                        break;
                }
            }
            else
            {
                Model.ModbusProtocol.SetInputStatus(68, true);
                ViewModel.VisualizationViewModel.ShowMessage("Error");
            }
           
        }

        public static void StartNewTrainReturn()
        {
                switch (ModbusProtocol.availableTrack)
                {
                    case 404:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack404Return, TrackSensorsViewModel.yTrack404Return,0); break;
                    case 402:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack402Return, TrackSensorsViewModel.yTrack402Return,0); break;
                    case 401:
                        visualization.DoStartNewTrain1(num, TrackSensorsViewModel.xTrack401Return, TrackSensorsViewModel.yTrack401Return,0); break;
                }
        }

        public static void ChangeLightOnRed(int number)
        {
            visualization.DoChangeLightOnRed(number);
        }

        public static void ChangeLightOnGreen(int number)
        {
            visualization.DoChangeLightOnGreen(number);
        }

        public static void TrackOnRed(String number)
        {
            visualization.DoTrackOnRed(number);
        }

        public static void TrackOnGreen(String number)
        {
            visualization.DoTrackOnGreen(number);
        }

        public static void TrackOnWhite(String number)
        {
            visualization.DoTrackOnWhite(number);
        }

        public static void ShowMessage(String text)
        {
            visualization.DoShowMessage(text);
        }

        public static void HideMessage()
        {
            visualization.DoHideMessage();
        }

        public static void WeightOnRed()
        {
            visualization.DoWeightOnRed();
        }

        public static void WeightOnWhite()
        {
            visualization.DoWeightOnWhite();
        }

        public static void WeightOnGreen()
        {
            visualization.DoWeightOnGreen();
        }

        public static void RemoveTrain(View.Train train)
        {
            visualization.DoRemoveTrain(train);
        }

        public static void RemoveTrain2(View.Train2 train)
        {
            visualization.DoRemoveTrain2(train);
        }

        private static void StartTrainHelp()
        {
            TrainViewModel.nextTrain = 1;
            ModbusProtocol.SetDataCoils(20, false);
            num++;
            switch (ModbusProtocol.availableTrack2)
            {
                case 406:
                    visualization.DoStartNewTrain2(num, TrackSensorsViewModel.xTrack406Return, TrackSensorsViewModel.yTrack406Return); break;
                case 403:
                    visualization.DoStartNewTrain2(num, TrackSensorsViewModel.xTrack403aReturn, TrackSensorsViewModel.yTrack403aReturn); break;
            }
        }

    }
}
