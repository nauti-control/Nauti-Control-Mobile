using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Bluetooth : ComponentBase,IDisposable
    {
        private BluetoothManagerVM VM
        {
            get
            {
                return BluetoothManagerVM.Instance;
            }
        }


        public Bluetooth()
        {

            BluetoothManagerVM.Instance.OnStateChanged += OnStateChanged;
        }

        private async void OnStateChanged(object? sender, EventArgs e)
        {
            await InvokeAsync(() =>
            {
                this.StateHasChanged();
            });
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();


        }

        public void Dispose()
        {
            BluetoothManagerVM.Instance.OnStateChanged -= OnStateChanged;
        }
    }
}
