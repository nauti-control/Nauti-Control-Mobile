using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class DataDisplay : CustomComponentBase
    {
        private DataDisplayVM VM { get; set; }

        public DataDisplay()
        {
            VM = new DataDisplayVM(OnStateChanged);
        }
    }
}