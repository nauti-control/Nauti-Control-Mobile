using Nauti_Control_Mobile.ViewModels;

namespace Nauti_Control_Mobile.Components.Pages
{
    public partial class Remote : CustomComponentBase
    {
        /// <summary>
        /// Remote
        /// </summary>
        public Remote()
        {
            VM = new RemoteVM(OnStateChanged);
        }

        /// <summary>
        /// VM
        /// </summary>
        public RemoteVM VM { get; set; }
    }
}