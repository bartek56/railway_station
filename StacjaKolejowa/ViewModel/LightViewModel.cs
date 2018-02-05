using StacjaKolejowa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaKolejowa.ViewModel
{
    static class LightViewModel
    {
        public static void ChangeLight1()
        {
            
            if (ModbusProtocol.GetInputStatus(69))
            {
                if (ModbusProtocol.availableTrack2 != 0 && ModbusProtocol.availableTrack == 401 || ModbusProtocol.availableTrack == 403 || ModbusProtocol.availableTrack == 405)
                {
                    ChangeLight(1);
                }
                else
                {
                    ViewModel.VisualizationViewModel.ShowMessage("Error");
                    ModbusProtocol.SetDataCoils(1, false);
                    ModbusProtocol.SetInputStatus(68, true);
                }
            }
            else
            {
                ViewModel.VisualizationViewModel.ShowMessage("Error");
                ModbusProtocol.SetDataCoils(1, false);
                ModbusProtocol.SetInputStatus(68, true);
            }

        }
        
        public static void ChangeLight2()
        {
            if (ModbusProtocol.GetDataCoils(2) == true)
            {
                if (TrainViewModel.queueTrainTo404Track.Count != 0 && ModbusProtocol.avaliableDeparture == 404 && ModbusProtocol.GetInputStatus(69)==true)
                {
                    ChangeLight(2);
                    int number = TrainViewModel.queueTrainTo404Track.First();
                    View.Train train = TrainViewModel.trainList[number];
                    TrainViewModel.queueTrainTo404Track.Remove(number);

                    train.storyboard.Resume();
                    train.timer.Start();

                }
                else if (ModbusProtocol.GetInputStatus(69))
                {


                    if (ModbusProtocol.availableTrack2 != 0 && ModbusProtocol.availableTrack == 404)
                    {
                        ChangeLight(2);
                    }
                    else
                    {
                        ViewModel.VisualizationViewModel.ShowMessage("Error");
                        ModbusProtocol.SetDataCoils(2, false);
                        ModbusProtocol.SetInputStatus(68, true);
                    }
                }
                else
                {
                    ViewModel.VisualizationViewModel.ShowMessage("Error");
                    ModbusProtocol.SetDataCoils(2, false);
                    ModbusProtocol.SetInputStatus(68, true);
                }
            }
            else
                ChangeLight(2);
        }

        public static void ChangeLight3()
        {
            if (ModbusProtocol.GetDataCoils(3) == true)
            {

                if (TrainViewModel.queueTrainTo402Track.Count != 0 && ModbusProtocol.avaliableDeparture == 402 && ModbusProtocol.GetInputStatus(69) == true)
                {
                    ChangeLight(3);
                    int number = TrainViewModel.queueTrainTo402Track.First();
                    View.Train train = TrainViewModel.trainList[number];
                    TrainViewModel.queueTrainTo402Track.Remove(number);

                    train.storyboard.Resume();
                    train.timer.Start();
                }


                else if (ModbusProtocol.GetInputStatus(69))
                {
                    if (ModbusProtocol.availableTrack2 != 0 && ModbusProtocol.availableTrack == 402)
                    {
                        ChangeLight(3);

                    }
                    else
                    {
                        ViewModel.VisualizationViewModel.ShowMessage("Error");
                        ModbusProtocol.SetDataCoils(3, false);
                        ModbusProtocol.SetInputStatus(68, true);

                    }
                }
                else
                {
                    ViewModel.VisualizationViewModel.ShowMessage("Error");
                    ModbusProtocol.SetDataCoils(3, false);
                    ModbusProtocol.SetInputStatus(68, true);

                }
            }
            else
                ChangeLight(3);
        }

        public static void ChangeLight4()
        {
            if (ModbusProtocol.GetDataCoils(4) == true)
            {
                if (TrainViewModel.queueTrainTo401Track.Count != 0 && ModbusProtocol.avaliableDeparture == 401 && ModbusProtocol.GetInputStatus(69) == true)
                {
                    ChangeLight(4);
                    int number = TrainViewModel.queueTrainTo401Track.First();
                    View.Train train = TrainViewModel.trainList[number];
                    TrainViewModel.queueTrainTo401Track.Remove(number);

                    train.storyboard.Resume();
                    train.timer.Start();
                }

                else if (ModbusProtocol.GetInputStatus(69))
                {
                    if (ModbusProtocol.availableTrack2 != 0 && ModbusProtocol.availableTrack == 401 && ModbusProtocol.GetDataCoils(1) == false)
                    {
                        ChangeLight(4);

                    }
                    else
                    {
                        ViewModel.VisualizationViewModel.ShowMessage("Error");
                        ModbusProtocol.SetInputStatus(68, true);
                        ModbusProtocol.SetDataCoils(4, false);
                    }
                }
                else
                {
                    ViewModel.VisualizationViewModel.ShowMessage("Error");
                    ModbusProtocol.SetDataCoils(4, false);
                    ModbusProtocol.SetInputStatus(68, true);
                }
            }
            else
                ChangeLight(4);
        }

        private static void ChangeLight(int number)
        {
            if (ModbusProtocol.GetDataCoils(number) == true)
            {
                ViewModel.VisualizationViewModel.ChangeLightOnGreen(number);
            }
            else if (ModbusProtocol.GetDataCoils(number) == false)
            {
                ViewModel.VisualizationViewModel.ChangeLightOnRed(number);
            }
        }
    }
}
