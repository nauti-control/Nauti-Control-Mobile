namespace Nauti_Control_Mobile.ViewModels
{
    public class BaseVM
    {
        protected Action _stateChanged;

        public BaseVM(Action stateChanged)
        {
            _stateChanged = stateChanged;
        }

        public void SetStateChanged()
        {
            _stateChanged();
        }
    }
}