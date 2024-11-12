using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels.Bluetooth;
using Plugin.BLE.Abstractions.Contracts;

namespace Nauti_Control_Mobile.ViewModels
{
    public class BluetoothVM:BaseVM
    {

        private IAdapter _adapter;

        private NavigationManager? _navigationmanager;
        /// <summary>
        /// Bluetooth Devices
        /// </summary>
        public ObservableCollection<BluetoothDeviceVM> DeviceVMs { get; private set; } = new ObservableCollection<BluetoothDeviceVM>();


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
        /// Start Scanning
        /// </summary>
        /// <returns></returns>
        public async Task StartScanning()
        {

            PermissionStatus status = await CheckBluetoothPermission();
            if (status == PermissionStatus.Granted && !_adapter.IsScanning)
            {

                DeviceVMs.Clear();
                SetStateChanged();
                await _adapter.StartScanningForDevicesAsync();
            }


        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stateHasChanged">State Has CHanged</param>

        public BluetoothVM(Action stateHasChanged) : base(stateHasChanged)
        {

            _adapter = BluetoothManagerVM.Instance.Adapter;
            _adapter.DeviceDiscovered += DeviceDiscovered;
            BluetoothManagerVM.Instance.OnConnectionChanged += OnConnectionChanged;


        }

        /// <summary>
        /// On Conncetion Changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void OnConnectionChanged(object? sender, EventArgs e)
        {
           if (BluetoothManagerVM.Instance.ConnectedDevice!=null && BluetoothManagerVM.Instance.ConnectedDevice.IsConnected && _navigationmanager!=null)
            {
                _navigationmanager.NavigateTo("/remote");
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
        /// Device Discovered Event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void DeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            //Check device name
            if (!string.IsNullOrWhiteSpace(e.Device.Name))
            {
                BluetoothDeviceVM vm = new BluetoothDeviceVM(e.Device, _adapter);
                DeviceVMs.Add(vm);
                SetStateChanged();

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

        public async Task InitialiseAysnc(NavigationManager navigationManager)
        {
            _navigationmanager = navigationManager;
        }
    }
}
