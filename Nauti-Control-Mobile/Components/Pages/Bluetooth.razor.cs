using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Bluetooth : CustomComponentBase
    {
        public Bluetooth()
        {
            VM = new BluetoothVM(OnStateChanged);
        }

        private BluetoothVM VM
        {
            get; set;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.InitialiseAysnc(NavigationManager);
        }
    }
}