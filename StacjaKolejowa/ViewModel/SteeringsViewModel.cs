using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StacjaKolejowa.Model;

namespace StacjaKolejowa.ViewModel
{
    static class SteeringsViewModel
    {

        public static void Steering408()
        {
            if (ModbusProtocol.GetDataCoils(5) == false) // zwrotnica 408
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("411");
                ViewModel.VisualizationViewModel.TrackOnWhite("410");

                ModbusProtocol.SetInputStatus(1, true);
                ModbusProtocol.SetInputStatus(2, false);
            }
            else if (ModbusProtocol.GetDataCoils(5) == true) // zwrotnica 408
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("410");
                ViewModel.VisualizationViewModel.TrackOnWhite("411");

                ModbusProtocol.SetInputStatus(1, false);
                ModbusProtocol.SetInputStatus(2, true);
            }
        }

        public static void Steering411()
        {
            if (ModbusProtocol.GetDataCoils(6) == false) // zwrotnica 411
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401a");
                ViewModel.VisualizationViewModel.TrackOnWhite("412");

                ModbusProtocol.SetInputStatus(3, true);
                ModbusProtocol.SetInputStatus(4, false);
            }
            else if (ModbusProtocol.GetDataCoils(6) == true) // zwrotnica 411
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("412");
                ViewModel.VisualizationViewModel.TrackOnWhite("401a");

                ModbusProtocol.SetInputStatus(3, false);
                ModbusProtocol.SetInputStatus(4, true);
            }
        }

        public static void Steering410()
        {
            if (ModbusProtocol.GetDataCoils(7) == false) // zwrotnica 410
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a");
                ViewModel.VisualizationViewModel.TrackOnWhite("405a");

                ModbusProtocol.SetInputStatus(5, true);
                ModbusProtocol.SetInputStatus(6, false);
            }
            else if (ModbusProtocol.GetDataCoils(7) == true) // zwrotnica 410
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405a");
                ViewModel.VisualizationViewModel.TrackOnWhite("403a");

                ModbusProtocol.SetInputStatus(5, false);
                ModbusProtocol.SetInputStatus(6, true);
            }
        }

        public static void Steering412()
        {
            if (ModbusProtocol.GetDataCoils(8) == false) // zwrotnica 412
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402a");
                ViewModel.VisualizationViewModel.TrackOnWhite("404a");

                ModbusProtocol.SetInputStatus(7, true);
                ModbusProtocol.SetInputStatus(8, false);
            }
            else if (ModbusProtocol.GetDataCoils(8) == true) // zwrotnica 412
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404a");
                ViewModel.VisualizationViewModel.TrackOnWhite("402a");

                ModbusProtocol.SetInputStatus(7, false);
                ModbusProtocol.SetInputStatus(8, true);
            }
        }

        public static void Steering440()
        {
            if (ModbusProtocol.GetDataCoils(9) == false) // zwrotnica 440
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401e");
                ViewModel.VisualizationViewModel.TrackOnWhite("402e");

                ModbusProtocol.SetInputStatus(9, true);
                ModbusProtocol.SetInputStatus(10, false);
            }
            else if (ModbusProtocol.GetDataCoils(9) == true) // zwrotnica 440
            {
                

                ViewModel.VisualizationViewModel.TrackOnGreen("402e");
                ViewModel.VisualizationViewModel.TrackOnWhite("401e");

                ModbusProtocol.SetInputStatus(9, false);
                ModbusProtocol.SetInputStatus(10, true);
            }
        }

        public static void Steering441()
        {
            if (ModbusProtocol.GetDataCoils(10) == false) // zwrotnica 441
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("440");
                ViewModel.VisualizationViewModel.TrackOnWhite("404e");

                ModbusProtocol.SetInputStatus(11, true);
                ModbusProtocol.SetInputStatus(12, false);
            }
            else if (ModbusProtocol.GetDataCoils(10) == true) // zwrotnica 441
            {
                

                ViewModel.VisualizationViewModel.TrackOnGreen("404e");
                ViewModel.VisualizationViewModel.TrackOnWhite("440");

                ModbusProtocol.SetInputStatus(11, false);
                ModbusProtocol.SetInputStatus(12, true);
            }
        }

        public static void Steering442()
        {
            if (ModbusProtocol.GetDataCoils(11) == false) // zwrotnica 442
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403e");
                ViewModel.VisualizationViewModel.TrackOnWhite("405e");

                ModbusProtocol.SetInputStatus(13, true);
                ModbusProtocol.SetInputStatus(14, false);
            }
            else if (ModbusProtocol.GetDataCoils(11) == true) // zwrotnica 442
            {
                ViewModel.VisualizationViewModel.TrackOnWhite("403e");
                ViewModel.VisualizationViewModel.TrackOnGreen("405e");

                ModbusProtocol.SetInputStatus(13, false);
                ModbusProtocol.SetInputStatus(14, true);
            }
        }

        public static void Steering444()
        {
            if (ModbusProtocol.GetDataCoils(12) == false) // zwrotnica 444
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("441");
                ViewModel.VisualizationViewModel.TrackOnWhite("442");

                ModbusProtocol.SetInputStatus(15, true);
                ModbusProtocol.SetInputStatus(16, false);
            }
            else if (ModbusProtocol.GetDataCoils(12) == true) // zwrotnica 444
            {
                ViewModel.VisualizationViewModel.TrackOnWhite("441");
                ViewModel.VisualizationViewModel.TrackOnGreen("442");

                ModbusProtocol.SetInputStatus(15, false);
                ModbusProtocol.SetInputStatus(16, true);
            }
        }

        public static void Steering445()
        {
            if (ModbusProtocol.GetDataCoils(13) == false) // zwrotnica 445
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_a");
                ViewModel.VisualizationViewModel.TrackOnWhite("406a");

                ModbusProtocol.SetInputStatus(17, true);
                ModbusProtocol.SetInputStatus(18, false);
            }
            else if (ModbusProtocol.GetDataCoils(13) == true) // zwrotnica 445
            {
                ViewModel.VisualizationViewModel.TrackOnWhite("403a_a");
                ViewModel.VisualizationViewModel.TrackOnGreen("406a");

                ModbusProtocol.SetInputStatus(17, false);
                ModbusProtocol.SetInputStatus(18, true);
            }
        }

        public static void Steering446()
        {
            if (ModbusProtocol.GetDataCoils(14) == false) // zwrotnica 446
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_e");
                ViewModel.VisualizationViewModel.TrackOnWhite("406c");

                ModbusProtocol.SetInputStatus(19, true);
                ModbusProtocol.SetInputStatus(20, false);
            }
            else if (ModbusProtocol.GetDataCoils(14) == true) // zwrotnica 446
            {
                ViewModel.VisualizationViewModel.TrackOnWhite("403a_e");
                ViewModel.VisualizationViewModel.TrackOnGreen("406c");

                ModbusProtocol.SetInputStatus(19, false);
                ModbusProtocol.SetInputStatus(20, true);
            }
        }
    }
}
