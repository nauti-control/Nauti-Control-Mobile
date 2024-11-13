using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.ViewModels
{
    public class RemoteVM : BaseVM
    {
        public RemoteVM(Action stateChanged) : base(stateChanged)
        {
        }

        public BluetoothDeviceVM? ConnectedDevice
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice;
            }
        }

        /// <summary>
        /// Remote Code
        /// </summary>
        /// <param name="remoteCode">Code</param>
        public async Task OnClick(int remoteCode)
        {
            if (ConnectedDevice != null)
            {
                await ConnectedDevice.SendCommand(remoteCode.ToString());
            }
        }
    }
}