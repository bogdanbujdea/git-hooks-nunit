using ReactiveUI;

namespace OpenMotics.App.ViewModels
{
    public class ViewModelBase: ReactiveObject
    {
        protected ObservableAsPropertyHelper<bool> _isLoading;

        public bool IsLoading
        {
            get { return _isLoading.Value; }
        }
    }
}
