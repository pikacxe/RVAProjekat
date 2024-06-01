using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RVAProject.ClientApp.ViewModels
{
    public class BindableBase : INotifyPropertyChanged
    {
        public string Title { get; set; }
        protected virtual void SetProperty<T>(ref T member, T val,
          [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;

            member = val;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
