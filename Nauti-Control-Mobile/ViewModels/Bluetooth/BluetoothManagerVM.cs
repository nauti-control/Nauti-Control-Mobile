using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;

namespace Nauti_Control_Mobile.ViewModels.Bluetooth
{
    public class BluetoothManagerVM
    {
        private IAdapter _adapter;
        private IBluetoothLE _ble;
        private BluetoothDeviceVM? _connectedDevice;

        /// <summary>
        /// Consructor
        /// </summary>
        public BluetoothManagerVM()
        {
            _ble = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;

            _adapter.ScanMode = ScanMode.Balanced;
            _adapter.ScanTimeoutElapsed += ScanTimeoutElapsed;

            Instance = this;
        }

        public event EventHandler? OnConnectionChanged;

        public event EventHandler? OnDataUpdated;

        public event EventHandler? OnStateChanged;

        /// <summary>
        /// Static Instance
        /// </summary>
        public static BluetoothManagerVM Instance { get; internal set; }

        /// <summary>
        /// BT Adapter
        /// </summary>
        public IAdapter Adapter
        { get { return _adapter; } }

        public BluetoothDeviceVM? ConnectedDevice
        {
            get
            {
                return _connectedDevice;
            }

            set
            {
                _connectedDevice = value;
                if (OnConnectionChanged != null)
                {
                    OnConnectionChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Data Updated
        /// </summary>
        public void DataUpdated()
        {
            if (OnDataUpdated != null)
            {
                OnDataUpdated(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// State Changed
        /// </summary>
        protected void StateChanged()
        {
            if (OnStateChanged != null)
            {
                OnStateChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Scan Timeout Elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanTimeoutElapsed(object? sender, EventArgs e)
        {
            StateChanged();
        }
    }
}