using Nauti_Control_Mobile.ViewModels.Bluetooth;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class ConnectedDeviceVM:BaseVM
    {
        public string ConnectionMessage
        {
            get
            {
                if (BluetoothManagerVM.Instance.ConnectedDevice != null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected)
                {
                    return "Connected";
                }
                else
                {
                    return "Disconnected";
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stateHasChanged"></param>
        public ConnectedDeviceVM(Action stateHasChanged):base(stateHasChanged)
        {
            BluetoothManagerVM.Instance.OnConnectionChanged += OnConnectionChanged;
        }

        /// <summary>
        /// Connection Changed Notifications
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void OnConnectionChanged(object? sender, EventArgs e)
        {
            SetStateChanged();
        }
    }
}
