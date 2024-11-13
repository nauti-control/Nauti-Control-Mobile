using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Remote : CustomComponentBase
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