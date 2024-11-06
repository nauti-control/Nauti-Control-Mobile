using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Home : ComponentBase
    {
        private BluetoothManagerVM VM { get; set; }

  
        public Home()
        {
            VM = new BluetoothManagerVM();
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            
        }

    }
}
