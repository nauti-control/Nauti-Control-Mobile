﻿using Nauti_Control_Mobile.Components.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.ViewModels
{
    public class RemoteVM
    {
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