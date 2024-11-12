using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels.Bluetooth
{
    public class BluetoothManagerVM
    {
        private IBluetoothLE _ble;
        private IAdapter _adapter;

        public event EventHandler? OnStateChanged;
        public event EventHandler? OnDataUpdated;
        public event EventHandler? OnConnectionChanged;


        /// <summary>
        /// BT Adapter
        /// </summary>
        public IAdapter Adapter { get { return _adapter; } }


        private BluetoothDeviceVM? _connectedDevice;
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
        /// Static Instance
        /// </summary>
        public static BluetoothManagerVM? Instance { get; internal set; }

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



        /// <summary>
        /// Scan Timeout Elapsed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanTimeoutElapsed(object? sender, EventArgs e)
        {
            StateChanged();
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



    }
}
