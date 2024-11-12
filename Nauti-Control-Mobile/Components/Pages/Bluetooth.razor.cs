using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels;
using Nauti_Control_Mobile.ViewModels.Bluetooth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Bluetooth : CustomComponentBase
    {
        private BluetoothVM VM
        {
            get;set;
        }


        public Bluetooth()
        {

            VM = new BluetoothVM(OnStateChanged);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
           await  VM.InitialiseAysnc(NavigationManager);
        }
    }
}
