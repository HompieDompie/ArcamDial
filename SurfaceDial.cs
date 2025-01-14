using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.UI.Input;
using System.Timers;

namespace ArcamDialNameSpace
{
    public partial class MainWindow : Form
    {
        RadialController radialController;
        private System.Timers.Timer clickTimer;
        double degrees = 0, lastDegrees = 0;

        public void InitClickTimer()
        {
            clickTimer = new System.Timers.Timer(750);
            clickTimer.Elapsed += ClickTimerElapsed;
            clickTimer.AutoReset = false;
        }

        public void CreateController()
        {
            IRadialControllerInterop interop = (IRadialControllerInterop)System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal.GetActivationFactory(typeof(RadialController));
            Guid guid = typeof(RadialController).GetInterface("IRadialController").GUID;

            radialController = interop.CreateForWindow(this.Handle, ref guid);
            degrees = lastDegrees = (35.0 - (double)numSensitivity.Value) * VolPerClicks;
            radialController.RotationResolutionInDegrees = degrees;
        }

        public void SubscribeToControllerCallbacks()
        {
            radialController.ControlAcquired += RadialController_ControlAcquired;
            radialController.ControlLost += RadialController_ControlLost;
            //radialController.ButtonClicked += RadialController_ButtonClicked;
            radialController.RotationChanged += RadialController_RotationChanged;
            radialController.ButtonHolding += RadialController_ButtonHolding;
            radialController.ButtonPressed += RadialController_ButtonPressed;
            radialController.ButtonReleased += RadialController_ButtonReleased;
        }


        int doubleClickCounter = 0;
        DateTime lastReleaseTime;
        bool Holding = false;
        bool Rotated = false;

        private void RadialController_ButtonReleased(RadialController sender, RadialControllerButtonReleasedEventArgs args)
        {
            lastReleaseTime = DateTime.Now;
            if (Holding)
            {
                Holding = false;
                radialController.RotationResolutionInDegrees = lastDegrees;
                if (!Rotated)
                {
                    this.Invoke(new Action(() =>
                    {
                        lblDialStatus.Text = "Long click";
                        SendClickCommand((eArcamClickOptionMenu)cbLongClick.SelectedIndex);
                    }));
                }
            }
            Rotated = false;
        }

        private void RadialController_ButtonPressed(RadialController sender, RadialControllerButtonPressedEventArgs args)
        {
            clickTimer.Start();
            doubleClickCounter++;
        }

        private void ClickTimerElapsed(Object source, ElapsedEventArgs e)
        {
            DateTime now = DateTime.Now;

            if (Holding)
            {

            }
            else if (doubleClickCounter == 1)
            {
                if (now.Ticks - lastReleaseTime.Ticks > 660000)
                {
                    this.Invoke(new Action(() => {
                        lblDialStatus.Text = "Single click";
                        SendClickCommand((eArcamClickOptionMenu)cbSingleClick.SelectedIndex);
                    }));
                }
            }
            else if (doubleClickCounter == 2)
            {
                this.Invoke(new Action(() =>
                {
                    lblDialStatus.Text = "Double click";
                    SendClickCommand((eArcamClickOptionMenu)cbDoubleClick.SelectedIndex);
                }));
            }
            else if (doubleClickCounter == 3)
            {
                this.Invoke(new Action(() =>
                {
                    lblDialStatus.Text = "Triple click";
                    SendClickCommand((eArcamClickOptionMenu)cbTripleClick.SelectedIndex);
                }));
            }
            doubleClickCounter = 0;
            
        }


        private void RadialController_ButtonHolding(RadialController sender, RadialControllerButtonHoldingEventArgs args)
        {
            Holding = true;
            //clickTimer.Stop();
            doubleClickCounter = 0;
            lastDegrees = degrees;
            if ((eArcamRotateHoldMenu)cbRotateHold.SelectedIndex == eArcamRotateHoldMenu.DisplayBrightness ||
                (eArcamRotateHoldMenu)cbRotateHold.SelectedItem == eArcamRotateHoldMenu.DisplayPage)
            {
                radialController.RotationResolutionInDegrees = 10;
            }
            //this.Invoke(new Action(() =>
            //{
            //    lblDialStatus.Text = "Long click";
            //    SendClickCommand((eArcamOptionMenu)cbLongClick.SelectedIndex);
            //}));
        }


        private void RadialController_ControlLost(RadialController sender, object args)
        {
            lblWindowStatus.Text = "Window lost control";
        }

        private void RadialController_ControlAcquired(RadialController sender, RadialControllerControlAcquiredEventArgs args)
        {
            lblWindowStatus.Text = "Window acquired control";
        }

        private void RadialController_RotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args)
        {
            lblDialStatus.Text = "Rotate " + args.RotationDeltaInDegrees + " degrees" + (Holding ? " -- holding": "");

            int diff = (int)(args.RotationDeltaInDegrees / radialController.RotationResolutionInDegrees) * VolPerClicks;
            if (Holding)
            {
                RotateAndHoldCommand(diff);
            }
            else
            {
                ChangeVolume(diff);
            }
            Rotated = true;
        }

        private void RotateAndHoldCommand(int Diff)
        {
            byte[] cmd = new byte[2];

            switch ((eArcamRotateHoldMenu)cbRotateHold.SelectedIndex)
            {
                case eArcamRotateHoldMenu.Volume:
                    ChangeVolume(Diff);
                    break;

                case eArcamRotateHoldMenu.Balance:
                    ChangeBalance(Diff);
                    break;

                case eArcamRotateHoldMenu.DisplayPage:
                    cmd[0] = 0x10; cmd[1] = 0x37;
                    Arcam.SendCommand(eArcamCommand.RC5, cmd);
                    break;

                case eArcamRotateHoldMenu.DisplayBrightness:
                    cmd[0] = 0x10; cmd[1] = 0x3B;
                    Arcam.SendCommand(eArcamCommand.RC5, cmd);
                 
                    break;

                case eArcamRotateHoldMenu.Nothing:
                    return;

                default:
                    return;
            }
        }



        private void ChangeVolume(int VolumeDiff)
        {
            int count = 0;
            byte[] cmd = new byte[1];

            radialController.RotationResolutionInDegrees = (35.0 - (double)numSensitivity.Value) * VolPerClicks;
            if (VolumeDiff > 0)
            {
                if (Volume + VolumeDiff > MaxVolume)
                {
                    return;
                }
                cmd[0] = 0xF1;
                count = VolumeDiff;
            }
            else
            {  
                if (Volume + VolumeDiff < 0)
                {
                    return;
                }
                cmd[0] = 0xF2;
                count = -VolumeDiff;
            }

            for (int i = 0; i < count; i++)
            {
                Arcam.SendCommand(eArcamCommand.Volume, cmd);
            }

            ScreenDirty = true;
            ArcamStatusScreenUpdate();
        }

        private void ChangeBalance(int BalanceDiff)
        {
            byte[] cmd = new byte[1];
            int count;

            if (BalanceDiff >= 0)
            {
                cmd[0] = 0xF1;
                count = BalanceDiff;
            }
            else
            {
                cmd[0] = 0xF2;
                count = -BalanceDiff;
            }

            for (int i = 0; i < count; i++)
            {
                Arcam.SendCommand(eArcamCommand.Balance, cmd);
            }
            Balance += BalanceDiff;

            ScreenDirty = true;
            ArcamStatusScreenUpdate();
        }


        public void RemoveMenu()
        {
            RadialControllerConfiguration radialControllerConfig;
            IRadialControllerConfigurationInterop radialControllerConfigInterop = (IRadialControllerConfigurationInterop)System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal.GetActivationFactory(typeof(RadialControllerConfiguration));
            Guid guid = typeof(RadialControllerConfiguration).GetInterface("IRadialControllerConfiguration").GUID;

            radialControllerConfig = radialControllerConfigInterop.GetForWindow(this.Handle, ref guid);
            radialControllerConfig.ActiveControllerWhenMenuIsSuppressed = radialController;
            radialControllerConfig.IsMenuSuppressed = true;
        }

        private void cbHaptic_CheckedChanged(object sender, EventArgs e)
        {
            radialController.UseAutomaticHapticFeedback = cbHaptic.Checked;
            numVolPerClicks.Enabled = radialController.UseAutomaticHapticFeedback;
            if (!numVolPerClicks.Enabled)
            {
                numVolPerClicks.Value = 1;
            }
        }

        private void numSensitivity_ValueChanged(object sender, EventArgs e)
        {
            decimal s = numSensitivity.Value;
            if (s < 1) numSensitivity.Value = 1;
            if (s > 30) numSensitivity.Value = 30;
            if (!(radialController is null))
            {
                radialController.RotationResolutionInDegrees = (35.0 - (double)numSensitivity.Value) * VolPerClicks;
            }
        }

        private void numVolPerClicks_ValueChanged(object sender, EventArgs e)
        {
            VolPerClicks = (int)numVolPerClicks.Value;
        }

    }
}
