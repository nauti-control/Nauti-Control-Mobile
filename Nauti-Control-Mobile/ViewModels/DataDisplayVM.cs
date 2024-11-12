using Nauti_Control_Mobile.Models;
using Nauti_Control_Mobile.ViewModels.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class DataDisplayVM : BaseVM
    {

        public string WindAngle
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.AWA.ToString();
            }
        }

        public string WindSpeed
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.AWS.ToString();
            }
        }

        public string Depth
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.DPT.ToString();
            }
        }

        public string SOG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.SOG.ToString();
            }
        }

        public string STW
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.STW.ToString();
            }
        }

        public string COG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.COG.ToString();
            }
        }

        public string HDG
        {
            get
            {
                return BluetoothManagerVM.Instance.ConnectedDevice.Data.HDG.ToString();
            }
        }



        public DataDisplayVM(Action stateChanged) : base(stateChanged)
        {
            
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
