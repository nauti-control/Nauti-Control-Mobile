using Microsoft.AspNetCore.Components;
using Nauti_Control_Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class DataDisplay:CustomComponentBase
    {
        private DataDisplayVM VM { get; set; }

        public DataDisplay()
        {
            VM = new DataDisplayVM(OnStateChanged);
        }

     

    }
}
