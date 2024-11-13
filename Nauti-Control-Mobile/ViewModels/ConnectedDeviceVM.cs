using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.ViewModels
{
    public class ConnectedDeviceVM : BaseVM
    {
        private NavigationManager? _navigationmanager;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stateHasChanged"></param>
        public ConnectedDeviceVM(Action stateHasChanged) : base(stateHasChanged)
        {
            BluetoothManagerVM.Instance.OnConnectionChanged += OnConnectionChanged;
        }

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

        public bool IsBusy { get; set; }

        /// <summary>
        /// Is Connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return (BluetoothManagerVM.Instance.ConnectedDevice != null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected);
            }
        }

        /// <summary>
        /// Initialise Async
        /// </summary>
        /// <param name="navigationManager"></param>
        /// <returns></returns>
        public async Task InitialiseAysnc(NavigationManager navigationManager)
        {
            _navigationmanager = navigationManager;
        }

        public async Task OnClick()
        {
            IsBusy = true;
            if (BluetoothManagerVM.Instance.ConnectedDevice != null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected)
            {
                await BluetoothManagerVM.Instance.ConnectedDevice.Disconnect();
            }
            IsBusy = false;
        }

        /// <summary>
        /// Connection Changed Notifications
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void OnConnectionChanged(object? sender, EventArgs e)
        {
            if (BluetoothManagerVM.Instance.ConnectedDevice == null && _navigationmanager != null)
            {
                _navigationmanager.NavigateTo("/");
            }
            SetStateChanged();
        }
    }
}