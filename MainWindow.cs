using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Input;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using System.Timers;


namespace ArcamDialNameSpace
{
 
    public partial class MainWindow : Form
    {
        private Thread FocusThread;
        int Volume = 0;
        int Balance = 0;
        bool Connected = false;
        bool Standby = false;
        bool Muted = false;
        int NetworkState = 0;
        int DacFilter = 0;
        bool ScreenDirty = true;
        string Model = "-";
        string Version = "-";
        int MaxVolume = 0;
        int VolPerClicks = 1;
        int LiftTemp = 0;
        int OutputTemp = 0;
        int RoomEQCurrent = 0;

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        /// <summary>The GetForegroundWindow function returns a handle to the foreground window.</summary>
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(HandleRef hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

        public MainWindow()
        {
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            //WindowState = FormWindowState.Maximized;

            InitializeComponent();
            ArcamStatusScreenUpdate();
            InitClickTimer();

            FocusThread = new Thread(FocusKeeper);
            FocusThread.IsBackground = true;
        }

        

        private void FocusKeeper()
        {
            while (true)
            {
                if (cbForceFocus.Checked)
                {
                    this.Invoke(new Action(() =>
                    {
                        uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
                        uint appThread = GetCurrentThreadId();
                        const uint SW_SHOW = 5;
                        if (foreThread != appThread)
                        {
                            AttachThreadInput(foreThread, appThread, true);
                            BringWindowToTop(this.Handle);
                            ShowWindow(this.Handle, SW_SHOW);
                            AttachThreadInput(foreThread, appThread, false);
                        }
                        else
                        {
                            BringWindowToTop(this.Handle);
                            ShowWindow(this.Handle, SW_SHOW);
                        }
                        this.Activate();

                    }));
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        protected override void OnFormClosing(System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveToRegistry();
        }

        protected override void OnDeactivate(EventArgs e)
        {
            lblWindowStatus.Text = "Window lost control";
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            CreateController();
            LoadFromRegistry();
            SubscribeToControllerCallbacks();
            RemoveMenu();

            bool networkIsSetup = false;
            if (cbNetwork.Text != "")
            {
                cbNetwork.Items.Add(cbNetwork.Text);
                networkIsSetup = false;
            }
            

            Discover discover = new Discover();
            List<Discover.Device> devices = discover.GetAllMacAddressesAndIppairs();
            for (int i = 0; i < devices.Count; i++)
            {
                cbNetwork.Items.Add(devices[i].IpAddress);
            }
            cbNetwork.SelectedIndex = 0;
            if (networkIsSetup)
            {
                ConnectToArcam();
                if (ArcamInitStatusGet())
                {
                    // Bug? Need to call ArcamStatusGet() twice on startup before getting all values back from the device...
                    ArcamStatusGet();
                    ArcamStatusGet();
                }
            }
            
            ArcamStatusScreenUpdate();

            FocusThread.Start();
            
        }

        public delegate void HandleReceivedAnswer(byte[] answer, int StartIdx);
        HandleReceivedAnswer answerDelegate;

        private void ConnectToArcam()
        {
            lblError.Text = "Connecting...";
            Application.DoEvents();

            answerDelegate = handleReceivedAnswer;
            if (Arcam.Connect(cbNetwork.Text, answerDelegate))
            {
                
                Connected = true;
            }
            else
            {
                Connected = false;
            }
            lblError.Text = Arcam.ErrorText;
        }


        private bool ArcamInitStatusGet()
        {
            if (Arcam.RequestData(eArcamCommand.MaxVolume))
            {
                Arcam.RequestData(eArcamCommand.RoomEQ);
                Arcam.RequestData(eArcamCommand.RoomEQNames);

                return true;
            }
            else
            {
                return false;
            }
        }



        static bool statusGetBusy = false;

        private bool ArcamStatusGet()
        {
            if (statusGetBusy) return true;
            statusGetBusy = true;

            if (Connected)
            {
                if (Arcam.RequestData(eArcamCommand.NetworkState))
                {
                    Arcam.RequestData(eArcamCommand.LiftTemp);
                    Arcam.RequestData(eArcamCommand.OutputTemp);
                    Arcam.RequestData(eArcamCommand.Status);
                }
                else return false;
                //Arcam.RequestData(eArcamCommand.Power);
                //Arcam.RequestData(eArcamCommand.Volume);
                //Arcam.RequestData(eArcamCommand.MuteUnmute);
                //Arcam.RequestData(eArcamCommand.DACFilter);
                //Arcam.RequestData(eArcamCommand.Balance);
                //Arcam.RequestData(eArcamCommand.Status);
            }
            statusGetBusy = false;

            return true;
        }

        static bool screenBusy = false;

        private void ArcamStatusScreenUpdate()
        {
            if (screenBusy) return;

            screenBusy = true;

            if (!Connected)
            {
                foreach (Control c in groupBox2.Controls )
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        c.Text = "-";
                    }
                }
                lblNetworkState.Text = "Not connected";

            }
            else if (ScreenDirty)
            {
                lblPower.Text = Standby ? "Standby" : "On";

                lblVolume.Text = Volume.ToString() + " / " + MaxVolume.ToString();

                lblVolume.Text = Muted ? "Muted" : lblVolume.Text;
                lblBalance.Text = Balance > 127 ? (-Balance + 128).ToString() : Balance.ToString();

                lblNetworkState.Text = "-";
                if (NetworkState == 0) lblNetworkState.Text = "Stopped";
                if (NetworkState == 1) lblNetworkState.Text = "Transitioning";
                if (NetworkState == 2) { lblNetworkState.Text = "Playing"; }
                if (NetworkState == 3) { lblNetworkState.Text = "Paused"; }

                switch (DacFilter)
                {
                    case 0x00: lblFilter.Text = "Linear Phase Fast Roll Off"; break;
                    case 0x01: lblFilter.Text = "Linear Phase Slow Roll Off"; break;
                    case 0x02: lblFilter.Text = "Minimum Phase Fast Roll Off"; break;
                    case 0x03: lblFilter.Text = "Minimum Phase Slow Roll Off"; break;
                    case 0x04: lblFilter.Text = "Brick Wall"; break;
                    case 0x05: lblFilter.Text = "Corrected Phase Fast Roll Off"; break;
                    case 0x06: lblFilter.Text = "Apodizing"; break;
                }
                lblModel.Text = Model;
                lblVersion.Text = Version;
                lblError.Text = Arcam.ErrorText;

                lblTempLift.Text = LiftTemp.ToString() + " \x00B0C";
                lblTempOutput.Text = OutputTemp.ToString() + " \x00B0C";
                ScreenDirty = false;
            }

            screenBusy = false;
        }

       

        enum eArcamClickOptionMenu { PauseUnpause = 0, NextTrack = 1, PreviousTrack = 2, MuteUnmute = 3, Standby = 4, DACFilter = 5, Nothing = 6 };

        enum eArcamRotateHoldMenu { Volume = 0, Balance = 1, DisplayPage = 2, DisplayBrightness = 3,  Nothing = 4 };


        private void SendClickCommand(eArcamClickOptionMenu ClickCommand)
        {
            if (!Arcam.Connected) return;

            byte[] cmd = new byte[2];
            switch (ClickCommand)
            {
                case eArcamClickOptionMenu.PauseUnpause:
                    if (NetworkState == 0 || NetworkState == 3 ) // 0 = stopped 3 = paused  2= transitioning  1 = playing
                    {
                        cmd[0] = 0x10; cmd[1] = 0x35;
                        Arcam.SendCommand(eArcamCommand.RC5, cmd);
                    }
                    else if (NetworkState == 1 || NetworkState == 2)
                    {
                        cmd[0] = 0x10; cmd[1] = 0x30;
                        Arcam.SendCommand(eArcamCommand.RC5, cmd);
                    }
                    
                    break;

                case eArcamClickOptionMenu.NextTrack:
                    cmd[0] = 0x10;
                    cmd[1] = 0x0B;
                    Arcam.SendCommand(eArcamCommand.RC5, cmd);
                    break;

                case eArcamClickOptionMenu.PreviousTrack:
                    cmd[0] = 0x10;
                    cmd[1] = 0x21;
                    Arcam.SendCommand(eArcamCommand.RC5, cmd);
                    break;

                case eArcamClickOptionMenu.MuteUnmute:
                    if (Muted)
                    {
                        cmd[0] = 0x01;
                    }
                    else
                    {
                        cmd[0] = 0x00;
                    }
                    Muted = !Muted;
                    Arcam.SendCommand(eArcamCommand.MuteUnmute, cmd);

                    break;

                case eArcamClickOptionMenu.Standby:
                    cmd[0] = 0x02;  
                    Arcam.SendCommand(eArcamCommand.Power, cmd); // eArcamCommand.RC5, cmd);
                    break;

                case eArcamClickOptionMenu.DACFilter:
                    DacFilter = (DacFilter + 1) % 7;
                    cmd[0] = (byte)DacFilter;
                    Arcam.SendCommand(eArcamCommand.DACFilter, cmd);
                    break;

                case eArcamClickOptionMenu.Nothing:
                    return;

                default:
                    return;
            }

            ArcamStatusGet();
            ArcamStatusScreenUpdate();
        }

        

        private void SaveToRegistry()
        {
            Microsoft.Win32.RegistryKey myKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ArcamDial");
            myKey.SetValue("NetworkName", cbNetwork.Text);
            myKey.SetValue("HapticFeedback", cbHaptic.Checked);
            myKey.SetValue("ForceFocus", cbForceFocus.Checked);
            myKey.SetValue("Sensitivity", (int)numSensitivity.Value);
            myKey.SetValue("VolPerClicks", (int)VolPerClicks);
            myKey.SetValue("SingleClick", cbSingleClick.SelectedIndex);
            myKey.SetValue("DoubleClick", cbDoubleClick.SelectedIndex);
            myKey.SetValue("TripleClick", cbTripleClick.SelectedIndex);
            myKey.SetValue("LongClick", cbLongClick.SelectedIndex);
            myKey.SetValue("RotateHold", cbRotateHold.SelectedIndex);
            myKey.SetValue("WindowWidth", this.Width);
            myKey.SetValue("WindowHeight", this.Height);
            myKey.SetValue("WindowLocationX", this.Location.X);
            myKey.SetValue("WindowLocationY", this.Location.Y);
            myKey.Close();
        }

        private void LoadFromRegistry()
        {
            Microsoft.Win32.RegistryKey myKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("ArcamDial");
            cbNetwork.Text = (string)myKey.GetValue("NetworkName", (object)"");
            string checkedStr = (string)myKey.GetValue("HapticFeedback", "True");
            cbHaptic.Checked = checkedStr == "True";
            string focusStr = (string)myKey.GetValue("ForceFocus", "False");
            cbForceFocus.Checked = focusStr == "True";
            int sens = (int)myKey.GetValue("Sensitivity", 20);
            numSensitivity.Value = sens;
            VolPerClicks = (int)myKey.GetValue("VolPerClicks", 1);
            numVolPerClicks.Value = VolPerClicks;
            cbSingleClick.SelectedIndex = (int)myKey.GetValue("SingleClick", eArcamClickOptionMenu.PauseUnpause);
            cbDoubleClick.SelectedIndex = (int)myKey.GetValue("DoubleClick", eArcamClickOptionMenu.NextTrack);
            cbTripleClick.SelectedIndex = (int)myKey.GetValue("TripleClick", eArcamClickOptionMenu.PreviousTrack);
            cbLongClick.SelectedIndex = (int)myKey.GetValue("LongClick", eArcamClickOptionMenu.DACFilter);
            cbRotateHold.SelectedIndex = (int)myKey.GetValue("RotateHold", eArcamRotateHoldMenu.Balance);
            this.Width = (int)myKey.GetValue("WindowWidth", 820);
            this.Height = (int)myKey.GetValue("WindowHeight", 400);
            Point loc = new Point(10, 10);
            loc.X = (int)myKey.GetValue("WindowLocationX", 100);
            loc.Y = (int)myKey.GetValue("WindowLocationY", 100);
            this.Location = loc;
            
            myKey.Close(); 
        }


   


        public void handleReceivedAnswer(byte[] Answer, int StartIdx)
        {
            int dataLen = (int)Answer[StartIdx+4];
            eArcamCommand cmd = (eArcamCommand)Answer[StartIdx + 2];
            int data1 = Answer[StartIdx + 5];
            int data2 = Answer[StartIdx + 6];
 
            switch (cmd)
            {
                case eArcamCommand.Power:
                    {
                        Standby = data1 == 0 ? true : false;
                        break;
                    }

                case eArcamCommand.MuteUnmute:
                    {
                        Muted = data1 == 0 ? true : false;
                        break;
                    }

                case eArcamCommand.NetworkState:
                    {
                        NetworkState = data1;
                        break;
                    }

                case eArcamCommand.DACFilter:
                    {
                        DacFilter = data1;
                        break;
                    }

                case eArcamCommand.MaxVolume:
                    {
                        MaxVolume = (int)data1;
                        break;
                    }

                case eArcamCommand.Model:
                    {
                        Model = getStringFromBytes(Answer, StartIdx, dataLen);
                        break;
                    }
                case eArcamCommand.SoftwareVersion:
                    {
                        Version = "V" + data1 + "." + data2;
                        break;
                    }
                case eArcamCommand.Volume:
                    {
                        Volume = (int)data1;
                        break;
                    }
                case eArcamCommand.Balance:
                    {
                        Balance = (int)data1;
                        break;
                    }
                case eArcamCommand.LiftTemp:
                    {
                        LiftTemp = (int)data1;
                        break;
                    }
                case eArcamCommand.OutputTemp:
                    {
                        OutputTemp = (int)data1;
                        break;
                    }
                case eArcamCommand.RoomEQ:
                    {
                        RoomEQCurrent = (int)data1;
                        lblDirac1.ForeColor = RoomEQCurrent == 1 ? Color.Black : Color.Gray;
                        lblDirac2.ForeColor = RoomEQCurrent == 2 ? Color.Black : Color.Gray;
                        lblDirac3.ForeColor = RoomEQCurrent == 3 ? Color.Black : Color.Gray;
                        break;
                    }
                case eArcamCommand.RoomEQNames:
                    {
                        String names = getStringFromBytes(Answer, StartIdx, dataLen);
                        lblDirac1.Text = names.Substring(0 * 20, 20);
                        lblDirac2.Text = names.Substring(1 * 20, 20);
                        lblDirac3.Text = names.Substring(2 * 20, 20);
                        break;
                    }
                case eArcamCommand.DCOffset:
                    {
                        cbDCOffset.Checked = (int)data1 != 0;
                        break;
                    }
                case eArcamCommand.ShortCircuit:
                    {
                        cbShortCircuit.Checked = (int)data1 != 0;
                        break;
                    }
                default:
                    return;
            }
            ScreenDirty = true;
        }

        private string getStringFromBytes(byte[] bytes, int StartIdx, int DataLen)
        {
            char[] str = new char[100];
            for (int i = 0; i < DataLen && bytes[StartIdx + i + 5] != 0; i++)
            {
                str[i] = (char)(bytes[StartIdx + i + 5]);
            }
            return new string(str);
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            ArcamInitStatusGet();
            ArcamStatusGet();
            ArcamStatusScreenUpdate();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Arcam.Disconnect();
            ArcamStatusScreenUpdate();
            Application.DoEvents();
            ConnectToArcam();
            ArcamInitStatusGet();
            // Bug? Need to call ArcamStatusGet() twice on startup before getting all values back from the device...
            ArcamStatusGet();
            ArcamStatusGet();
            ArcamStatusScreenUpdate();
        }


        private void btExit_Click(object sender, EventArgs e)
        {
            SaveToRegistry();
            Arcam.Disconnect();
            base.Close();
        }

        
    }
}
