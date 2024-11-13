using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.ViewModels
{
    public class NavMenuVM : BaseVM
    {
        /// <summary>
        /// Disable Nav if Not Connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                bool isConnected = false;
                if (BluetoothManagerVM.Instance.ConnectedDevice != null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected)
                {
                    isConnected = true;
                }
                return isConnected;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stateChanged"></param>
        public NavMenuVM(Action stateChanged) : base(stateChanged)
        {
            BluetoothManagerVM.Instance.OnConnectionChanged += OnConnectionChanged;
        }

        /// <summary>
        /// On Connection Chnaged
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">event</param>
        private void OnConnectionChanged(object? sender, EventArgs e)
        {
            SetStateChanged();
        }
    }
}