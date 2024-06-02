using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RVAProject.ClientApp
{
    internal class NavigationService : INotifyPropertyChanged
    {
        private static NavigationService _instance;

        public static NavigationService Instance => _instance ?? (_instance = new NavigationService());

        private BindableBase _currentView = new LoginViewModel();
        public BindableBase CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged();
                    OnPropertyChanged("BackButtonVisibility");
                }
            }
        }

        public Visibility BackButtonVisibility => NavigationService.Instance.CurrentView.GetType() == typeof(LoginViewModel) ? Visibility.Hidden : Visibility.Visible;

        private BindableBase previousView;
        public AppCommand NavigateBackCommand { get; private set; }

        private NavigationService() 
        {
            NavigateBackCommand = new AppCommand(NavigateBack);
        }

        public void NavigateTo(BindableBase viewModel)
        {
            previousView = CurrentView;
            CurrentView = viewModel;
        }

        public void NavigateBack()
        {
            CurrentView = previousView;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
