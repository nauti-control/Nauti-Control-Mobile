using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class BluetoothManagerVM
    {
        private IBluetoothLE _ble;
        private IAdapter _adapter;

        public ObservableCollection<BluetoothDeviceVM> DeviceVMs { get; private set; }

        public BluetoothManagerVM()
        {
            _ble = CrossBluetoothLE.Current;
            _adapter = CrossBluetoothLE.Current.Adapter;
            _adapter.DeviceDiscovered += DeviceDiscovered;
            _adapter.ScanMode = ScanMode.Balanced;
            DeviceVMs=new ObservableCollection<BluetoothDeviceVM>();
        }

        private void DeviceDiscovered(object? sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {

            BluetoothDeviceVM vm = new BluetoothDeviceVM(e.Device);
            DeviceVMs.Add(vm);

        }

        public async Task StartScanning()
        {
            await _adapter.StartScanningForDevicesAsync();
        }
    }
}
