using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

enum eArcamCommand { Power = 0x00, DisplayBrightness = 0x01, SoftwareVersion = 0x04, RC5 = 0x08, Volume = 0x0D, MuteUnmute = 0x0E,
                     NetworkState = 0x1C, InputSource = 0x1D, HeartBeat = 0x25, RoomEQNames = 0x34, RoomEQ = 0x37,  Balance = 0x3B,
                     DCOffset = 0x51, ShortCircuit = 0x52, LiftTemp = 0x56, OutputTemp = 0x57, Status = 0x5D, Model = 0x5E, 
                     DACFilter = 0x61, MaxVolume = 0x66};

enum eArcamAnswerCode { StatusUpdate = 0x00, ZoneInvalid = 0x82, CommandNotRecognised = 0x83, ParameterNotRecognised = 0x84,
                        CommandUInvalidAtThisTime = 0x85, InvalidDataLength= 0x86 };



namespace ArcamDialNameSpace
{
    class Arcam
    {
        private static Socket sender;
        public static byte[] answerMsg;
        public static bool Connected = false;
        private static string LastNetName;
        public static string ErrorText { get; set; }

        static MainWindow.HandleReceivedAnswer CallHandleReceivedAnswer;

        public static bool Connect(string NetName, MainWindow.HandleReceivedAnswer handleReceivedAnswer)
        {
            byte[] bytes = new byte[1024];

            if (handleReceivedAnswer != null)
            {
                CallHandleReceivedAnswer = handleReceivedAnswer;
            }
            LastNetName = NetName;

            try
            {
                // Connect to Remote server  

                IPAddress ipAddress;
                if (IPAddress.TryParse(NetName, out ipAddress))
                {
                   // IPHostEntry host = Dns.GetHostEntry(ipAddress);
                    //string a = host.HostName;
                }
                else
                {
                    IPHostEntry host = Dns.GetHostEntry(NetName);
                    ipAddress = host.AddressList[0];
                }
                
                                
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 50000);

                // Create a TCP/IP  socket.    
                sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    sender.ReceiveTimeout = 1000;
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    ErrorText = ane.Message;
                    return false;
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    ErrorText = se.Message;
                    return false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    ErrorText = e.Message;
                    return false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ErrorText = e.Message;
                return false;
            }
            return true;
        }

        public static bool Reconnect()
        {
            System.Threading.Thread.Sleep(100);
            return Connect(LastNetName, null);
        }

        public static bool Disconnect()
        {
            // SaveSettings();
            if (!(sender is null))
            {
                try
                {
                    // Release the socket.    
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                    Connected = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString()); 
                    return false;
                }
            }
            return true;
        }

        public static bool RequestData(eArcamCommand Command)
        {
            byte[] cmd = { 0xF0 };      // 0x0F = request data
            return SendCommand(Command, cmd);
        }

        

        public static bool SendCommand(eArcamCommand Command, byte[] Parameters)
        {
            if (sender == null) return false;
            Connected = sender.Connected;
            if (!Connected)
            {
                Connected = false;
                if (!Reconnect())  return false ;
            }

            //// Encode the data string into a byte array.    
            byte[] sendMsg = new byte[100];
            byte[] recMsg = new byte[1000];
            int i;

            sendMsg[0] = 0x21;
            sendMsg[1] = 0x01;  // Zone
            sendMsg[2] = (Byte)Command;
            sendMsg[3] = (Byte)Parameters.Length;
            for (i = 0; i < Parameters.Length; i++)
            {
                sendMsg[4 + i] = (Byte)Parameters[i];
            }
            sendMsg[4 + i] = 0x0D;

            try
            {
                //// Send the data through the socket.    
                int bytesSent = sender.Send(sendMsg, 5 + i, 0);

                //// Receive the response from the remote device. 
                //System.Threading.Thread.Sleep(100);
                int bytesRec = sender.Receive(recMsg);

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ErrorText = "Exception: " + e.Message;
                return false;
            }

            int startIdx = 0;
   
            answerMsg = new byte[1000];

            for (startIdx = 0; startIdx < 95; startIdx++)
            {
                if (recMsg[startIdx] == 0x21)
                {
                    switch ((eArcamAnswerCode)recMsg[startIdx + 3])
                    {
                        case eArcamAnswerCode.StatusUpdate:
                            CallHandleReceivedAnswer(recMsg, startIdx);
                            int dataLen = (int)recMsg[startIdx + 4];
                            startIdx += dataLen + 4;
                            ErrorText = "OK";
                            break;
                        case eArcamAnswerCode.ZoneInvalid:
                            ErrorText = "Invalid Zone";
                            break;
                        case eArcamAnswerCode.CommandNotRecognised:
                            ErrorText = "Command not recognised";
                            break;
                        case eArcamAnswerCode.ParameterNotRecognised:
                            ErrorText = "Parameter not recognised";
                            break;
                        case eArcamAnswerCode.CommandUInvalidAtThisTime:
                            ErrorText = "Command invalid at this time";
                            break;
                        case eArcamAnswerCode.InvalidDataLength:
                            ErrorText = "Invalid data length";
                            break;
                        default:
                            break;
                    }
                }
            }

            return true;
        }
    }
}
