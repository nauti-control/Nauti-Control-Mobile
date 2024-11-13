using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels.Bluetooth;

namespace Nauti_Control_Mobile.Components.Layout
{
    public partial class MainLayout : LayoutComponentBase
    {
        private BluetoothManagerVM bluetoothManagerVM = new BluetoothManagerVM();
    }
}