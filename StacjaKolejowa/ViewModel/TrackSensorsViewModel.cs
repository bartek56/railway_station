using StacjaKolejowa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacjaKolejowa.ViewModel
{
    static class TrackSensorsViewModel
    {
        public static double[] xTrack401 = new double[] { 0,1150, 1200, 1300, 1500, 1600 };
        public static double[] yTrack401 = new double[] { 287,287, 270, 240, 240, 240 };

        public static double[] xTrack401Return = new double[] { 1600,1500,1300,1200,1150,0,-200 };
        public static double[] yTrack401Return = new double[] { 240,240,240,270,287,287,287 };


        public static double[] xTrack403 = new double[] { 0, 80, 210, 1180, 1300, 1400, 1500, 1600 };
        public static double[] yTrack403 = new double[] { 287, 287, 332, 332, 290, 240, 240, 240 };

        public static double[] xTrack403Return = new double[] {1600,1500,1400,1300,1180,210,80,0,-200 };
        public static double[] yTrack403Return = new double[] { 240,240,240,290,332,332,287,287,287};
        

        public static double[] xTrack406 = new double[] { 0, 300, 420, 520, 600, 930, 1110, 1220, 1600 };
        public static double[] yTrack406 = new double[] { 287, 287, 260, 246, 246, 246, 260, 287, 287 };


        public static double[] xTrack406Return = new double[] {1600,1220,1110,930,600,520,420,300,0,-200 };
        public static double[] yTrack406Return = new double[] {287, 287,260,246,246,246,260,287,287,287};


        public static double[] xTrack403a = new double[] { 0, 1600 };
        public static double[] yTrack403a = new double[] { 285, 285 };

        public static double[] xTrack403aReturn = new double[] { 1600,-200 };
        public static double[] yTrack403aReturn = new double[] { 287, 287 };


        public static double[] xTrack405 = new double[] { 0, 80, 200, 220, 355, 400, 1200, 1400, 1500, 1600 };
        public static double[] yTrack405 = new double[] { 287, 287, 332, 332, 380, 380, 380, 240, 240, 240 };



        public static double[] xTrack402Return = new double[] { 1600, 260,190,-200 };
        public static double[] yTrack402Return = new double[] { 240,  240,287,287 };

        public static double[] xTrack404Return = new double[] { 1600, 1310,1210,400,270,260,190,-200};
        public static double[] yTrack404Return = new double[] { 240, 240,196,196,240,240,287,287};



        // --------------------------------40---------------------------------------------- //
        public static void Track408(double xPoint, double yPoint)
        {
            if (xPoint > 10 && xPoint < 70 && yPoint > 285 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(21, true);
                ViewModel.VisualizationViewModel.TrackOnRed("408");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("408");
                ModbusProtocol.SetInputStatus(21, false);
            }
        }

        public static void Track411(double xPoint, double yPoint)
        {
            if (xPoint > 90 && xPoint < 150 && yPoint > 285 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(22, true);
                ViewModel.VisualizationViewModel.TrackOnRed("411");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("411");
                ModbusProtocol.SetInputStatus(22, false);
            }
        }

        public static void Track410(double xPoint, double yPoint)
        {
            if (xPoint > 90 && xPoint < 200 && yPoint > 290 && yPoint < 330)
            {
                ModbusProtocol.SetInputStatus(23, true);
                ViewModel.VisualizationViewModel.TrackOnRed("410");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("410");
                ModbusProtocol.SetInputStatus(23, false);
            }
        }

        public static void Track412(double xPoint, double yPoint)
        {
            if (xPoint > 195 && xPoint < 250 && yPoint > 235 && yPoint < 287)
            {
                ModbusProtocol.SetInputStatus(24, true);
                ViewModel.VisualizationViewModel.TrackOnRed("412");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("412");
                ModbusProtocol.SetInputStatus(24, false);
            }
        }

        public static void Track445(double xPoint, double yPoint)
        {
            if (xPoint > 10 && xPoint < 270 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(25, true);
                ViewModel.VisualizationViewModel.TrackOnRed("445");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("445");
                ModbusProtocol.SetInputStatus(25, false);
            }
        }

        public static void Track446(double xPoint, double yPoint)
        {
            if (xPoint > 1250 && xPoint < 1500 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(26, true);
                ViewModel.VisualizationViewModel.TrackOnRed("446");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("446");
                ModbusProtocol.SetInputStatus(26, false);
            }
        }

        public static void Track440(double xPoint, double yPoint)
        {
            if (xPoint > 1280 && xPoint < 1350 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(27, true);
                ViewModel.VisualizationViewModel.TrackOnRed("440");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("440");
                ModbusProtocol.SetInputStatus(27, false);
            }
        }

        public static void Track442(double xPoint, double yPoint)
        {
            if (xPoint > 1330 && xPoint < 1400 && yPoint > 245 && yPoint < 330)
            {
                ModbusProtocol.SetInputStatus(28, true);
                ViewModel.VisualizationViewModel.TrackOnRed("442");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("442");
                ModbusProtocol.SetInputStatus(28, false);
            }
        }

        public static void Track441(double xPoint, double yPoint)
        {
            if (xPoint > 1350 && xPoint < 1420 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(29, true);
                ViewModel.VisualizationViewModel.TrackOnRed("441");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("441");
                ModbusProtocol.SetInputStatus(29, false);
            }
        }


        public static void Track444(double xPoint, double yPoint)
        {
            if (xPoint > 1420 && xPoint < 1550 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(30, true);
                ViewModel.VisualizationViewModel.TrackOnRed("444");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("444");
                ModbusProtocol.SetInputStatus(30, false);
            }
        }
// --------------------------------30---------------------------------------------- //

        public static void Track401a(double xPoint, double yPoint)
        {
            if (xPoint > 190 && xPoint < 400 && yPoint > 286 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(31, true);
                ViewModel.VisualizationViewModel.TrackOnRed("401a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401a");
                ModbusProtocol.SetInputStatus(31, false);
            }
        }

        public static void Track401b(double xPoint, double yPoint)
        {
            if (xPoint > 440 && xPoint < 670 && yPoint > 285 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(32, true);
                ViewModel.VisualizationViewModel.TrackOnRed("401b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401b");
                ModbusProtocol.SetInputStatus(32, false);
            }
        }

        public static void Track401c(double xPoint, double yPoint)
        {
            if (xPoint > 700 && xPoint < 930 && yPoint > 285 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(33, true);
                ViewModel.VisualizationViewModel.TrackOnRed("401c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401c");
                ModbusProtocol.SetInputStatus(33, false);
            }
        }

        public static void Track401d(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1150 && yPoint > 285 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(34, true);
                ViewModel.VisualizationViewModel.TrackOnRed("401d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401d");
                ModbusProtocol.SetInputStatus(34, false);
            }
        }

        public static void Track401e(double xPoint, double yPoint)
        {
            if (xPoint > 1160 && xPoint < 1280 && yPoint > 245 && yPoint < 280)
            {
                ModbusProtocol.SetInputStatus(35, true);
                ViewModel.VisualizationViewModel.TrackOnRed("401e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("401e");
                ModbusProtocol.SetInputStatus(35, false);
            }
        }

        public static void Track403a(double xPoint, double yPoint)
        {
            if (xPoint > 240 && xPoint < 400 && yPoint > 330 && yPoint < 335)
            {
                ModbusProtocol.SetInputStatus(36, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a");
                ModbusProtocol.SetInputStatus(36, false);
            }
        }

        public static void Track403b(double xPoint, double yPoint)
        {
            if (xPoint > 440 && xPoint < 670 && yPoint > 330 && yPoint < 335)
            {
                ModbusProtocol.SetInputStatus(37, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403b");
                ModbusProtocol.SetInputStatus(37, false);
            }
        }

        public static void Track403c(double xPoint, double yPoint)
        {
            if (xPoint > 700 && xPoint < 930 && yPoint > 330 && yPoint < 335)
            {
                ModbusProtocol.SetInputStatus(38, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403c");
                ModbusProtocol.SetInputStatus(38, false);
            }
        }

        public static void Track403d(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1150 && yPoint > 330 && yPoint < 335)
            {
                ModbusProtocol.SetInputStatus(39, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403d");
                ModbusProtocol.SetInputStatus(39, false);
            }
        }

        public static void Track403e(double xPoint, double yPoint)
        {
            if (xPoint > 1100 && xPoint < 1300 && yPoint > 245 && yPoint < 330)
            {
                ModbusProtocol.SetInputStatus(40, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403e");
                ModbusProtocol.SetInputStatus(40, false);
            }
        }

        // ------------------------40--------------------------------------- //


        public static void Track404a(double xPoint, double yPoint)
        {
            if (xPoint > 260 && xPoint < 400 && yPoint > 200 && yPoint < 240)
            {
                ModbusProtocol.SetInputStatus(41, true);
                ViewModel.VisualizationViewModel.TrackOnRed("404a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404a");
                ModbusProtocol.SetInputStatus(41, false);
            }
        }

        public static void Track404b(double xPoint, double yPoint)
        {
            if (xPoint > 440 && xPoint < 670 && yPoint > 195 && yPoint < 197)
            {
                ModbusProtocol.SetInputStatus(42, true);
                ViewModel.VisualizationViewModel.TrackOnRed("404b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404b");
                ModbusProtocol.SetInputStatus(42, false);
            }
        }

        public static void Track404c(double xPoint, double yPoint)
        {
            if (xPoint > 700 && xPoint < 930 && yPoint > 195 && yPoint < 197)
            {
                ModbusProtocol.SetInputStatus(43, true);
                ViewModel.VisualizationViewModel.TrackOnRed("404c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404c");
                ModbusProtocol.SetInputStatus(43, false);
            }
        }

        public static void Track404d(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1150 && yPoint > 195 && yPoint < 197)
            {
                ModbusProtocol.SetInputStatus(44, true);
                ViewModel.VisualizationViewModel.TrackOnRed("404d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404d");
                ModbusProtocol.SetInputStatus(44, false);
            }
        }

        public static void Track404e(double xPoint, double yPoint)
        {
            if (xPoint > 1160 && xPoint < 1300 && yPoint > 195 && yPoint < 240)
            {
                ModbusProtocol.SetInputStatus(45, true);
                ViewModel.VisualizationViewModel.TrackOnRed("404e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("404e");
                ModbusProtocol.SetInputStatus(45, false);
            }
        }


        public static void Track402a(double xPoint, double yPoint)
        {
            
            if (xPoint > 260 && xPoint < 420 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(46, true);
                ViewModel.VisualizationViewModel.TrackOnRed("402a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402a");
                ModbusProtocol.SetInputStatus(46, false);
            }
            
        }

        public static void Track402b(double xPoint, double yPoint)
        {
            if (xPoint > 440 && xPoint < 670 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(47, true);
                ViewModel.VisualizationViewModel.TrackOnRed("402b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402b");
                ModbusProtocol.SetInputStatus(47, false);
            }
        }

        public static void Track402c(double xPoint, double yPoint)
        {
            if (xPoint > 700 && xPoint < 930 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(48, true);
                ViewModel.VisualizationViewModel.TrackOnRed("402c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402c");
                ModbusProtocol.SetInputStatus(48, false);
            }
        }

        public static void Track402d(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1150 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(49, true);
                ViewModel.VisualizationViewModel.TrackOnRed("402d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402d");
                ModbusProtocol.SetInputStatus(49, false);
            }
        }

        public static void Track402e(double xPoint, double yPoint)
        {
            if (xPoint > 1160 && xPoint < 1280 && yPoint > 238 && yPoint < 242)
            {
                ModbusProtocol.SetInputStatus(50, true);
                ViewModel.VisualizationViewModel.TrackOnRed("402e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("402e");
                ModbusProtocol.SetInputStatus(50, false);
            }
        }

        // ----------------------------50----------------------------------- //


        public static void Track405a(double xPoint, double yPoint)
        {
            if (xPoint > 220 && xPoint < 380 && yPoint > 332 && yPoint < 390)
            {
                ModbusProtocol.SetInputStatus(51, true);
                ViewModel.VisualizationViewModel.TrackOnRed("405a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405a");
                ModbusProtocol.SetInputStatus(51, false);
            }
        }

        public static void Track405b(double xPoint, double yPoint)
        {
            if (xPoint > 440 && xPoint < 670 && yPoint > 378 && yPoint < 382)
            {
                ModbusProtocol.SetInputStatus(52, true);
                ViewModel.VisualizationViewModel.TrackOnRed("405b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405b");
                ModbusProtocol.SetInputStatus(52, false);
            }
        }

        public static void Track405c(double xPoint, double yPoint)
        {
            if (xPoint > 700 && xPoint < 930 && yPoint > 378 && yPoint < 382)
            {
                ModbusProtocol.SetInputStatus(53, true);
                ViewModel.VisualizationViewModel.TrackOnRed("405c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405c");
                ModbusProtocol.SetInputStatus(53, false);
            }
        }

        public static void Track405d(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1150 && yPoint > 378 && yPoint < 382)
            {
                ModbusProtocol.SetInputStatus(54, true);
                ViewModel.VisualizationViewModel.TrackOnRed("405d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405d");
                ModbusProtocol.SetInputStatus(54, false);
            }
        }

        public static void Track405e(double xPoint, double yPoint)
        {
            if (xPoint > 1200 && xPoint < 1300 && yPoint > 280 && yPoint < 380)
            {
                ModbusProtocol.SetInputStatus(55, true);
                ViewModel.VisualizationViewModel.TrackOnRed("405e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("405e");
                ModbusProtocol.SetInputStatus(55, false);
            }
        }

        public static void Track403a_a(double xPoint, double yPoint)
        {
            if (xPoint > 310 && xPoint < 570 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(56, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a_a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_a");
                ModbusProtocol.SetInputStatus(56, false);
            }
        }

        public static void Track403a_b(double xPoint, double yPoint)
        {
            if (xPoint > 590 && xPoint < 710 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(57, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a_b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_b");
                ModbusProtocol.SetInputStatus(57, false);
            }
        }

        public static void Track403a_c(double xPoint, double yPoint)
        {
            if (xPoint > 710 && xPoint < 810 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(64, true);
                ModbusProtocol.SetInputStatus(58, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a_c");
                ViewModel.VisualizationViewModel.WeightOnRed();
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_c");
                ViewModel.VisualizationViewModel.WeightOnGreen();
                ModbusProtocol.SetInputStatus(58, false);
                ModbusProtocol.SetInputStatus(64, false);
            }
        }

        public static void Track403a_d(double xPoint, double yPoint)
        {
            if (xPoint > 820 && xPoint < 930 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(59, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a_d");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_d");
                ModbusProtocol.SetInputStatus(59, false);
            }
        }

        public static void Track403a_e(double xPoint, double yPoint)
        {
            if (xPoint > 950 && xPoint < 1220 && yPoint > 282 && yPoint < 290)
            {
                ModbusProtocol.SetInputStatus(60, true);
                ViewModel.VisualizationViewModel.TrackOnRed("403a_e");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("403a_e");
                ModbusProtocol.SetInputStatus(60, false);
            }
        }

        // ------------------------------60--------------------------------- //

        public static void Track406a(double xPoint, double yPoint)
        {
            if (xPoint > 310 && xPoint < 570 && yPoint > 245 && yPoint < 286)
            {
                ModbusProtocol.SetInputStatus(61, true);
                ViewModel.VisualizationViewModel.TrackOnRed("406a");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("406a");
                ModbusProtocol.SetInputStatus(61, false);
            }
        }

        public static void Track406b(double xPoint, double yPoint)
        {
            if (xPoint > 600 && xPoint < 900 && yPoint > 245 && yPoint < 247)
            {
                ModbusProtocol.SetInputStatus(62, true);
                ViewModel.VisualizationViewModel.TrackOnRed("406b");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("406b");
                ModbusProtocol.SetInputStatus(62, false);
            }
        }

        public static void Track406c(double xPoint, double yPoint)
        {
            if (xPoint > 940 && xPoint < 1220 && yPoint > 245 && yPoint < 288)
            {
                ModbusProtocol.SetInputStatus(63, true);
                ViewModel.VisualizationViewModel.TrackOnRed("406c");
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnGreen("406c");
                ModbusProtocol.SetInputStatus(63, false);
            }
        }

    }
}
