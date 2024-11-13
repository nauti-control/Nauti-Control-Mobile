using Nauti_Control_Mobile.Components.Pages;
using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Layout
{
    public partial class NavMenu : CustomComponentBase
    {
        public NavMenu()
        {
            VM = new NavMenuVM(OnStateChanged);
        }

        private NavMenuVM VM { get; set; }
    }
}