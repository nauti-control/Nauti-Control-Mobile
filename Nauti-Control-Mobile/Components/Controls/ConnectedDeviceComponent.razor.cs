using Nauti_Control_Mobile.Components.Pages;
using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Controls
{
    public partial class ConnectedDeviceComponent : CustomComponentBase
    {
        public ConnectedDeviceComponent()
        {
            VM = new ConnectedDeviceVM(OnStateChanged);
        }

        ConnectedDeviceVM VM { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await VM.InitialiseAysnc(NavigationManager);
        }
    }
}