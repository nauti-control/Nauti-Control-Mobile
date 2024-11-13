using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.ViewModels
{
    public class ConnectedDeviceVM : BaseVM
    {
        public bool IsBusy { get; set; }

        private NavigationManager? _navigationmanager;

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
        /// Is Connected
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return (BluetoothManagerVM.Instance.ConnectedDevice != null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected);
            }
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
        /// Constructor
        /// </summary>
        /// <param name="stateHasChanged"></param>
        public ConnectedDeviceVM(Action stateHasChanged) : base(stateHasChanged)
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
            if (BluetoothManagerVM.Instance.ConnectedDevice == null && _navigationmanager != null)
            {
                _navigationmanager.NavigateTo("/");
            }
            SetStateChanged();
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
    }
}