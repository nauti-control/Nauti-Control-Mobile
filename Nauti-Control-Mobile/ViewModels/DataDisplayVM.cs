using Nauti_Control_Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class DataDisplayVM
    {

        public string WindAngle {
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



        public DataDisplayVM()
        {
            BluetoothManagerVM.Instance.ConnectedDevice.OnDataUpdated += OnDataUpdated;
        }


        
        private void OnDataUpdated(object? sender, EventArgs e)
        {
            
        }
    }
}
