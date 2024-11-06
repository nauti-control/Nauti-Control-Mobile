using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class BluetoothDeviceVM
    {
        private IDevice _bluetoothDevice;

        public BluetoothDeviceVM(IDevice bluetoothDevice)
        {
            _bluetoothDevice = bluetoothDevice;
        }
    }
}
