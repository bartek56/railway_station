using Modbus.Data;
using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StacjaKolejowa.Model
{
    static class ModbusProtocol
    {
       
        public static ModbusSlave slave;
        public static int avaliableDeparture { get; set; }

        public static int availableTrack { get; set; }
        public static int availableTrack2 { get; set; }
        
        public static void Slave(string selectedPort, string selectedBaudRate, string selectedParity, string selectedDataBits, string selectedStopBits)
        {
            int baudRate = int.Parse(selectedBaudRate);
            int dataBits = int.Parse(selectedDataBits);


            using (SerialPort slavePort = new SerialPort(selectedPort))
            {
                slavePort.BaudRate = baudRate;
                slavePort.DataBits = dataBits;
                SetParity(selectedParity, slavePort);
                SetStopBits(selectedStopBits,slavePort);
                slavePort.Open();

                slave = ModbusSerialSlave.CreateRtu(1, slavePort);
                slave.DataStore = DataStoreFactory.CreateDefaultDataStore();
                slave.DataStore.DataStoreWrittenTo += new EventHandler<DataStoreEventArgs>(Modbus_DataStoreWriteTo);

                SetDefaultValue();

                slave.Listen();
            }
        }

        private static void Modbus_DataStoreWriteTo(object sender, DataStoreEventArgs e)
        {
            int number = 0;

            int Address = e.StartAddress;//e.StartAddress;

            switch (e.ModbusDataType)
            {
                case ModbusDataType.HoldingRegister:
                    SetInputStatus(68, false);
                    Console.WriteLine("Holding Register");
                    Console.WriteLine("address: " + Address.ToString());
                    Console.WriteLine("length frame: " + e.Data.B.Count.ToString());
                    Console.Write("data: ");
                    for (int i = 1; i <= e.Data.B.Count; i++)
                    {
                        Console.Write(ModbusProtocol.GetDataHoldingRegister(Address + i) + ",");

                    }
                    Console.WriteLine();
                    ViewModel.VisualizationViewModel.HideMessage();

                    if (Address == 0)
                    {
                        if (GetDataCoils(15) == true)
                            ViewModel.VisualizationViewModel.TurnpikePutDown(SetSpeedTurnpike());
                        else if (GetDataCoils(15) == false)
                            ViewModel.VisualizationViewModel.TurnpikePutUp(SetSpeedTurnpike());                        
                    }


                    break;

                case ModbusDataType.Coil:
                    
                    Console.WriteLine("Coil");
                    Console.WriteLine("address: " + Address.ToString());
                    Console.WriteLine("length frame: " + e.Data.A.Count.ToString());
                    Console.Write("data: ");

                    for (int i = 0; i < e.Data.A.Count; i++)
                    {
                        Console.Write(ModbusProtocol.GetDataCoils(Address + i+1) + ",");
                        number++;
                    }

                    ViewModel.VisualizationViewModel.HideMessage();
                    SetInputStatus(68, false);
                    
                    Answers(Address);
                    CheckAvaliableDeparture();
                    SetAvaliableTrack1();
                    SetAvaliableTrack2();

                    Console.WriteLine("avaliable track: {0}", availableTrack);
                    Console.WriteLine("avaliable track2: {0}", availableTrack2);
                    Console.WriteLine("avaliable departure track: {0}", avaliableDeparture);
                    Console.WriteLine();
                    
                    break;
            }
        }

        public static ushort GetDataHoldingRegister(int index)
        {
            return slave.DataStore.HoldingRegisters[index];
        }

        public static bool GetDataCoils(int index)
        {
            return slave.DataStore.CoilDiscretes[index];
        }

        public static void SetInputStatus(int index, bool status)
        {
            slave.DataStore.InputDiscretes[index] = status;
        }

        public static bool GetInputStatus(int index)
        {
            return slave.DataStore.InputDiscretes[index];
        }

        public static void SetDataCoils(int index, bool status)
        {
            slave.DataStore.CoilDiscretes[index]=status;
        }

        private static void SetParity(String selectedParity, SerialPort slavePort)
        {
            switch (selectedParity)
            {
                case "None": slavePort.Parity = Parity.None; break;
                case "Odd": slavePort.Parity = Parity.Odd; break;
                case "Even": slavePort.Parity = Parity.Even; break;
                case "Mark": slavePort.Parity = Parity.Mark; break;
                case "Space": slavePort.Parity = Parity.Space; break;
            }
        }

        private static void SetStopBits(String selectedStopBits, SerialPort slavePort)
        {
            switch (selectedStopBits)
            {
                case "1": slavePort.StopBits = StopBits.One; break;
                case "1.5": slavePort.StopBits = StopBits.OnePointFive; break;
                case "2": slavePort.StopBits = StopBits.Two; ; break;
            }
        }

        private static void SetDefaultValue()
        {
            // czujniki zwrotnic
            slave.DataStore.InputDiscretes[1] = true;
            slave.DataStore.InputDiscretes[3] = true;
            slave.DataStore.InputDiscretes[5] = true;
            slave.DataStore.InputDiscretes[7] = true;
            slave.DataStore.InputDiscretes[9] = true;
            slave.DataStore.InputDiscretes[11] = true;
            slave.DataStore.InputDiscretes[13] = true;
            slave.DataStore.InputDiscretes[15] = true;
            slave.DataStore.InputDiscretes[17] = true;
            slave.DataStore.InputDiscretes[19] = true;

            // rogatka otwarta
            slave.DataStore.InputDiscretes[70] = true; 

            // kolory torów
            ViewModel.VisualizationViewModel.TrackOnGreen("408");
            ViewModel.VisualizationViewModel.TrackOnGreen("411");
            ViewModel.VisualizationViewModel.TrackOnGreen("401a");
            ViewModel.VisualizationViewModel.TrackOnGreen("401b");
            ViewModel.VisualizationViewModel.TrackOnGreen("401c");
            ViewModel.VisualizationViewModel.TrackOnGreen("401d");
            ViewModel.VisualizationViewModel.TrackOnGreen("401e");
            ViewModel.VisualizationViewModel.TrackOnGreen("440");
            ViewModel.VisualizationViewModel.TrackOnGreen("441");
            ViewModel.VisualizationViewModel.TrackOnGreen("444");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a");
            ViewModel.VisualizationViewModel.TrackOnGreen("402a");
            ViewModel.VisualizationViewModel.TrackOnGreen("403e");
            ViewModel.VisualizationViewModel.TrackOnGreen("445");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a_a");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a_b");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a_c");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a_d");
            ViewModel.VisualizationViewModel.TrackOnGreen("403a_e");
            ViewModel.VisualizationViewModel.TrackOnGreen("446");
            ViewModel.VisualizationViewModel.WeightOnGreen();
        }

        private static double SetSpeedTurnpike()
        {
            if (GetDataHoldingRegister(1) > 0 && GetDataHoldingRegister(1) <= 100)
                return .9;
            else if (GetDataHoldingRegister(1) > 100 && GetDataHoldingRegister(1) <= 200)
                return .8;
            else if (GetDataHoldingRegister(1) > 200 && GetDataHoldingRegister(1) <= 300)
                return .7;
            else if (GetDataHoldingRegister(1) > 300 && GetDataHoldingRegister(1) <= 400)
                return .6;
            else if (GetDataHoldingRegister(1) > 400 && GetDataHoldingRegister(1) <= 500)
                return .5;
            else if (GetDataHoldingRegister(1) > 500 && GetDataHoldingRegister(1) <= 600)
                return .4;
            else if (GetDataHoldingRegister(1) > 600 && GetDataHoldingRegister(1) <= 700)
                return .3;
            else if (GetDataHoldingRegister(1) > 700 && GetDataHoldingRegister(1) <= 800)
                return .2;
            else if (GetDataHoldingRegister(1) > 800 && GetDataHoldingRegister(1) <= 900)
                return .1;
            else if (GetDataHoldingRegister(1) > 900 && GetDataHoldingRegister(1) <= 1000)
                return .05;

            return 0;
        }

        private static void CheckAvaliableTrack1()
        {
            if (ModbusProtocol.GetDataCoils(9) == false && ModbusProtocol.GetDataCoils(12) == false && ModbusProtocol.GetDataCoils(10) == false && ModbusProtocol.GetDataCoils(6) == false && ModbusProtocol.GetDataCoils(5) == false)
                availableTrack = 401;
            else if (ModbusProtocol.GetDataCoils(9) == true && ModbusProtocol.GetDataCoils(12) == false && ModbusProtocol.GetDataCoils(10) == false && ModbusProtocol.GetDataCoils(6) == true && ModbusProtocol.GetDataCoils(8) == false && ModbusProtocol.GetDataCoils(5) == false)
                availableTrack = 402;
            else if (ModbusProtocol.GetDataCoils(11) == false && ModbusProtocol.GetDataCoils(12) == true && ModbusProtocol.GetDataCoils(7) == false && ModbusProtocol.GetDataCoils(5) == true)
                availableTrack = 403;
            else if (ModbusProtocol.GetDataCoils(10) == true && ModbusProtocol.GetDataCoils(12) == false && ModbusProtocol.GetDataCoils(8) == true && ModbusProtocol.GetDataCoils(6) == true && ModbusProtocol.GetDataCoils(5) == false)
                availableTrack = 404;
            else if (ModbusProtocol.GetDataCoils(11) == true && ModbusProtocol.GetDataCoils(12) == true && ModbusProtocol.GetDataCoils(11) == true && ModbusProtocol.GetDataCoils(7) == true && ModbusProtocol.GetDataCoils(5) == true)
                availableTrack = 405;
            else
                availableTrack = 0;
        }

        private static void CheckAvaliableTrack2()
        {
            if (GetDataCoils(13) == false && GetDataCoils(14) == false)
                availableTrack2 = 403;
            else if (GetDataCoils(13) == true && GetDataCoils(14) == true)
                availableTrack2 = 406;
            else
                availableTrack2 = 0;
        }

        private static void CheckAvaliableDeparture()
        {
            if (GetDataCoils(5) == false && GetDataCoils(6) == false)
                avaliableDeparture = 401;
            else if (GetDataCoils(5) == false && GetDataCoils(6) == true && GetDataCoils(8) == false)
                avaliableDeparture = 402;
            else if (GetDataCoils(5) == false && GetDataCoils(6) == true && GetDataCoils(8) == true)
                avaliableDeparture = 404;
            else
                avaliableDeparture = 0;

        }

        private static void SetAvaliableTrack1()
        {

            CheckAvaliableTrack1();

            if (availableTrack != 0)
            {
                switch (availableTrack)
                {
                    case 404:
                        if (ViewModel.TrainViewModel.queueTrainTo404Track.Count == 0)
                        {
                            ViewModel.VisualizationViewModel.TrackOnGreen("404b");
                            ViewModel.VisualizationViewModel.TrackOnGreen("404c");
                            ViewModel.VisualizationViewModel.TrackOnGreen("404d");
                        }
                        /*
                        else
                        {
                            SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }
                        */
                        break;
                    case 402:
                        if (ViewModel.TrainViewModel.queueTrainTo402Track.Count == 0)
                        {
                            ViewModel.VisualizationViewModel.TrackOnGreen("402b");
                            ViewModel.VisualizationViewModel.TrackOnGreen("402c");
                            ViewModel.VisualizationViewModel.TrackOnGreen("402d");
                        }
                        /*
                        else
                        {
                            SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }
                        */
                        break;
                    case 401:
                        if (ViewModel.TrainViewModel.queueTrainTo401Track.Count == 0)
                        {
                            ViewModel.VisualizationViewModel.TrackOnGreen("401b");
                            ViewModel.VisualizationViewModel.TrackOnGreen("401c");
                            ViewModel.VisualizationViewModel.TrackOnGreen("401d");

                        }
                        /*
                        else
                        {
                            SetInputStatus(68, true);
                            ViewModel.VisualizationViewModel.ShowMessage("Error");
                        }
                        */
                        break;
                    case 403: ViewModel.VisualizationViewModel.TrackOnGreen("403b"); ViewModel.VisualizationViewModel.TrackOnGreen("403c"); ViewModel.VisualizationViewModel.TrackOnGreen("403d"); break;
                    case 405: ViewModel.VisualizationViewModel.TrackOnGreen("405b"); ViewModel.VisualizationViewModel.TrackOnGreen("405c"); ViewModel.VisualizationViewModel.TrackOnGreen("405d"); break;
                }
            }
            else
            {
                if (avaliableDeparture == 0)
                {
                    ViewModel.VisualizationViewModel.ChangeLightOnRed(1);
                    ViewModel.VisualizationViewModel.ChangeLightOnRed(2);
                    ViewModel.VisualizationViewModel.ChangeLightOnRed(3);
                    ViewModel.VisualizationViewModel.ChangeLightOnRed(4);
                    SetDataCoils(1, false);
                    SetDataCoils(2, false);
                    SetDataCoils(3, false);
                    SetDataCoils(4, false);

                }

                ViewModel.VisualizationViewModel.TrackOnWhite("404b");
                ViewModel.VisualizationViewModel.TrackOnWhite("404c");
                ViewModel.VisualizationViewModel.TrackOnWhite("404d");

                ViewModel.VisualizationViewModel.TrackOnWhite("402b");
                ViewModel.VisualizationViewModel.TrackOnWhite("402c");
                ViewModel.VisualizationViewModel.TrackOnWhite("402d");

                ViewModel.VisualizationViewModel.TrackOnWhite("401b");
                ViewModel.VisualizationViewModel.TrackOnWhite("401c");
                ViewModel.VisualizationViewModel.TrackOnWhite("401d");

                ViewModel.VisualizationViewModel.TrackOnWhite("403b");
                ViewModel.VisualizationViewModel.TrackOnWhite("403c");
                ViewModel.VisualizationViewModel.TrackOnWhite("403d");

                ViewModel.VisualizationViewModel.TrackOnWhite("405b");
                ViewModel.VisualizationViewModel.TrackOnWhite("405c");
                ViewModel.VisualizationViewModel.TrackOnWhite("405d");
            }

            

        }

        private static void SetAvaliableTrack2()
        {
            CheckAvaliableTrack2();

            if (availableTrack2 != 0)
            {
                switch (availableTrack2)
                {
                    case 406: ViewModel.VisualizationViewModel.TrackOnGreen("406b"); break;
                    case 403: ViewModel.VisualizationViewModel.TrackOnGreen("403a_b"); ViewModel.VisualizationViewModel.TrackOnGreen("403a_c"); ViewModel.VisualizationViewModel.TrackOnGreen("403a_d"); ViewModel.VisualizationViewModel.WeightOnGreen(); break;

                }
            }
            else
            {
                ViewModel.VisualizationViewModel.TrackOnWhite("406b");
                ViewModel.VisualizationViewModel.TrackOnWhite("403a_b");
                ViewModel.VisualizationViewModel.TrackOnWhite("403a_c");
                ViewModel.VisualizationViewModel.TrackOnWhite("403a_d");
                ViewModel.VisualizationViewModel.WeightOnWhite();

            }
        }

        private static void Answers(int Address)
        {
            switch (Address)
            {
                case 0: ViewModel.LightViewModel.ChangeLight1(); break;
                case 1: ViewModel.LightViewModel.ChangeLight2(); break;
                case 2: ViewModel.LightViewModel.ChangeLight3(); break;
                case 3: ViewModel.LightViewModel.ChangeLight4(); break;
                case 4: ViewModel.SteeringsViewModel.Steering408(); break;
                case 5: ViewModel.SteeringsViewModel.Steering411(); break;
                case 6: ViewModel.SteeringsViewModel.Steering410(); break;
                case 7: ViewModel.SteeringsViewModel.Steering412(); break;
                case 8: ViewModel.SteeringsViewModel.Steering440(); break;
                case 9: ViewModel.SteeringsViewModel.Steering441(); break;
                case 10: ViewModel.SteeringsViewModel.Steering442(); break;
                case 11: ViewModel.SteeringsViewModel.Steering444(); break;
                case 12: ViewModel.SteeringsViewModel.Steering445(); break;
                case 13: ViewModel.SteeringsViewModel.Steering446(); break;
                case 18: ViewModel.VisualizationViewModel.StartNewTrain(); break;
                case 19: ViewModel.VisualizationViewModel.StartNewTrainReturn2(); break;
            }
        }

    }
}
