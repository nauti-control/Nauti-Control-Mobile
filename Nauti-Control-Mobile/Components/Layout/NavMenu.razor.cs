using Nauti_Control_Mobile.Components.Pages;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Layout
{
    public partial class NavMenu:CustomComponentBase
    {
        NavMenuVM VM { get; set; }
        public NavMenu()
        {
            VM = new NavMenuVM(OnStateChanged);
        }
    }
}
