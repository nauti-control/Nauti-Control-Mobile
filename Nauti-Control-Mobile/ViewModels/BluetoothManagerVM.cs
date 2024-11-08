using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class BluetoothManagerVM
    {
        private IBluetoothLE _ble;
        private IAdapter _adapter;
        private Action _updateState;


        /// <summary>
        /// Is Start Scan Button Disabled
        /// </summary>
        public bool IsStartScanDisabled
        {
            get
            {
                return _adapter.IsScanning;
            }
        }


        /// <summary>
        /// Is Stop Scan Disabled
        /// </summary>
        public bool IsStopScanDisabled
        {
            get
            {
                return !_adapter.IsScanning;
            }
        }
        /// <summary>
        /// Bluetooth Devices
        /// </summary>
        public ObservableCollection<BluetoothDeviceVM> DeviceVMs { get; private set; }

        /// <summary>
        /// Consructor
        /// </summary>
        /// <param name="updateState">callback</param>
        public BluetoothManagerVM(Action updateState)
        {

            _updateState = updateState;
            _ble = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;
            _adapter.DeviceDiscovered += DeviceDiscovered;
            _adapter.ScanMode = ScanMode.Balanced;
            _adapter.ScanTimeoutElapsed += ScanTimeoutElapsed;
            DeviceVMs = new ObservableCollection<BluetoothDeviceVM>();
        }

        private void ScanTimeoutElapsed(object? sender, EventArgs e)
        {
            _updateState();
        }

        /// <summary>
        /// Device Discovered Event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void DeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            //Check device name
            if (!string.IsNullOrWhiteSpace(e.Device.Name))
            {
                BluetoothDeviceVM vm = new BluetoothDeviceVM(e.Device);
                DeviceVMs.Add(vm);
                _updateState();
            }

        }

        /// <summary>
        /// Start Scanning
        /// </summary>
        /// <returns></returns>
        public async Task StartScanning()
        {

            PermissionStatus status = await CheckBluetoothPermission();
            if (status == PermissionStatus.Granted && !_adapter.IsScanning)
            {

                DeviceVMs.Clear();
                _updateState();
                await _adapter.StartScanningForDevicesAsync();
            }


        }


        /// <summary>
        /// Stop Scanning
        /// </summary>
        /// <returns></returns>
        public async Task StopScanning()
        {
            if (_adapter.IsScanning)
            {
                await _adapter.StopScanningForDevicesAsync();
            }
        }

        /// <summary>
        /// Check Bluetooth Permissions
        /// </summary>
        /// <returns>Status</returns>
        public async Task<PermissionStatus> CheckBluetoothPermission()
        {
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.Bluetooth>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Bluetooth>();
            }

            return status;

        }
    }
}
