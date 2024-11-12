using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Remote:CustomComponentBase
    {
        /// <summary>
        /// VM
        /// </summary>
        public RemoteVM VM { get; set; }


        /// <summary>
        /// Remote
        /// </summary>
        public Remote()
        {
            VM = new RemoteVM(OnStateChanged);
        }
    }
}
