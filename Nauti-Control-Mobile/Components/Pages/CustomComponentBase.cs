using Microsoft.AspNetCore.Components;

namespace Nauti_Control_Mobile.Components.Pages
{
    public class CustomComponentBase : ComponentBase
    {
        /// <summary>
        /// On State Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OnStateChanged()
        {
            await InvokeAsync(() =>
            {
                this.StateHasChanged();
            });
        }
    }
}