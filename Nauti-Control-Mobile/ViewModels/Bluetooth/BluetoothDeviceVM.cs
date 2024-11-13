using Nauti_Control_Mobile.Models;
using Plugin.BLE.Abstractions.Contracts;
using System.Diagnostics;
using System.Text;

namespace Nauti_Control_Mobile.ViewModels.Bluetooth
{
    public class BluetoothDeviceVM
    {
        private IAdapter _adapter;

        private const string ServiceUUID = "778e5a27-1cc1-4bca-994f-7b2dbe34fcc6";

        private const string CmdCharacteristicUUID = "46ba71f1-c22c-42ae-832c-81414bde99ee";

        private const string AwaCharacteristicUUID = "fd3e532c-f882-499a-b2fd-c68cca630949";

        private const string AwsCharacteristicUUID = "6dce0177-7b5c-4274-a726-9202e292ec0c";

        private const string StwCharacteristicUUID = "83e0c967-4352-4187-9feb-d7cd3c89e01d";

        private const string SogCharacteristicUUID = "5eacdf71-af9a-458c-86db-e247db17e399";

        private const string CogCharacteristicUUID = "dc0439f8-23bc-44b0-8e0c-a8e06272f4fa";

        private const string HdgCharacteristicUUID = "799ee17b-5f1a-4962-b236-ac80185d9186";

        private const string DptCharacteristicUUID = "7fdda184-b61a-4358-9213-41a5f934a7bb";

        private ICharacteristic? _cmdCharacteristic;
        private ICharacteristic? _awaCharacteristic;
        private ICharacteristic? _awsCharacteristic;
        private ICharacteristic? _stwCharacteristic;
        private ICharacteristic? _sogCharacteristic;
        private ICharacteristic? _cogCharacteristic;
        private ICharacteristic? _hdgCharacteristic;
        private ICharacteristic? _dptCharacteristic;

        public BluetoothManagerVM ParentManager { get; set; }

        /// <summary>
        /// Is Conected
        /// </summary>
        public bool IsConnected { get; set; }

        /// <summary>
        /// Is Busy
        /// </summary>
        public bool IsBusy { get; set; }

        /// <summary>
        /// Boat Data
        /// </summary>
        public BoatData Data { get; set; }

        /// <summary>
        /// Device Name
        /// </summary>
        public string Name
        {
            get
            {
                return _bluetoothDevice.Name;
            }
        }

        private IDevice _bluetoothDevice;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bluetoothDevice">Device</param>
        /// <param name="adapter">Adapter</param>
        public BluetoothDeviceVM(IDevice bluetoothDevice, IAdapter adapter)
        {
            _bluetoothDevice = bluetoothDevice;
            _adapter = adapter;
            Data = new BoatData();
            ParentManager = BluetoothManagerVM.Instance;
        }

        /// <summary>
        /// Connect
        /// </summary>
        public async Task Connect()
        {
            IsBusy = true;
            try
            {
                await _adapter.ConnectToDeviceAsync(_bluetoothDevice);
                IService service = await _bluetoothDevice.GetServiceAsync(Guid.Parse(ServiceUUID));
                if (service != null)
                {
                    _cmdCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(CmdCharacteristicUUID));
                    if (_cmdCharacteristic != null)
                    {
                        _cmdCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _awaCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(AwaCharacteristicUUID));
                    if (_awaCharacteristic != null)
                    {
                        _awaCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _awsCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(AwsCharacteristicUUID));
                    if (_awsCharacteristic != null)
                    {
                        _awsCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _stwCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(StwCharacteristicUUID));
                    if (_stwCharacteristic != null)
                    {
                        _stwCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _sogCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(SogCharacteristicUUID));
                    if (_sogCharacteristic != null)
                    {
                        _sogCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _cogCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(CogCharacteristicUUID));
                    if (_cogCharacteristic != null)
                    {
                        _cogCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _hdgCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(HdgCharacteristicUUID));
                    if (_hdgCharacteristic != null)
                    {
                        _hdgCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    _dptCharacteristic = await service.GetCharacteristicAsync(Guid.Parse(DptCharacteristicUUID));
                    if (_dptCharacteristic != null)
                    {
                        _dptCharacteristic.ValueUpdated += ValueUpdated;
                    }
                    IsConnected = true;
                    ParentManager.ConnectedDevice = this;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                IsConnected = false;
                ParentManager.ConnectedDevice = null;
            }
            IsBusy = false;
        }

        /// <summary>
        /// Notification from BLE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueUpdated(object? sender, Plugin.BLE.Abstractions.EventArgs.CharacteristicUpdatedEventArgs e)
        {
            ICharacteristic characteristic = e.Characteristic;
            if (characteristic != null)
            {
                byte[]? value = characteristic.Value;

                if (value != null)
                {
                    double dobValue = BitConverter.ToDouble(value);
                    if (_awaCharacteristic == characteristic)
                    {
                        Data.AWA = dobValue;
                    }
                    else if (_awsCharacteristic == characteristic)
                    {
                        Data.AWS = dobValue;
                    }
                    else if (_stwCharacteristic == characteristic)
                    {
                        Data.STW = dobValue;
                    }
                    else if (_sogCharacteristic == characteristic)
                    {
                        Data.SOG = dobValue;
                    }
                    else if (_cogCharacteristic == characteristic)
                    {
                        Data.COG = dobValue;
                    }
                    else if (_hdgCharacteristic == characteristic)
                    {
                        Data.HDG = dobValue;
                    }
                    else if (_dptCharacteristic == characteristic)
                    {
                        Data.DPT = dobValue;
                    }
                    ParentManager.DataUpdated();
                }
            }
        }

        /// <summary>
        /// Send Command Over BT
        /// </summary>
        /// <param name="command">command</param>
        public async Task SendCommand(string command)
        {
            if (_cmdCharacteristic != null)
            {
                await _cmdCharacteristic.WriteAsync(Encoding.ASCII.GetBytes(command));
            }
        }

        /// <summary>
        /// Disconnect
        /// </summary>
        internal async Task Disconnect()
        {
            await _adapter.DisconnectDeviceAsync(_bluetoothDevice);
            ParentManager.ConnectedDevice = null;
        }
    }
}