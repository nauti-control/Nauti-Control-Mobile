using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.Components.Pages;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Controls
{
    public partial class ConnectedDeviceComponent : CustomComponentBase
    {
        ConnectedDeviceVM VM { get; set; }

        public ConnectedDeviceComponent()
        {
            VM = new ConnectedDeviceVM(OnStateChanged);
        }

        
        
    }
}
