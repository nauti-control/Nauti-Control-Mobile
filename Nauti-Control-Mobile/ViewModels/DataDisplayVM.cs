using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.ViewModels
{
    public class DataDisplayVM : BaseVM
    {
        public DataDisplayVM(Action stateChanged) : base(stateChanged)
        {
            // No event subscription needed
        }

        public double COG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.COG;
            }
        }

        public double Depth
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.DPT;
            }
        }

        public double HDG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.HDG;
            }
        }

        public double SOG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.SOG;
            }
        }

        public double STW
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.STW;
            }
        }

        public double WindAngle
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.AWA;
            }
        }

        public double WindSpeed
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.AWS;
            }
        }

        /// <summary>
        /// On Data Updated Event
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event</param>
        private void OnDataUpdated(object? sender, EventArgs e)
        {
            SetStateChanged();
        }
    }
}