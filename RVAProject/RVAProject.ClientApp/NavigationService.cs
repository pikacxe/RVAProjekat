﻿using RVAProject.ClientApp.Modules;
using RVAProject.ClientApp.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public string serviceToken { get; set; }

        public Visibility BackButtonVisibility => NavigationService.Instance.CurrentView.GetType() == typeof(LoginViewModel) ? Visibility.Hidden : Visibility.Visible;

        private BindableBase previousView;
        public AppCommand NavigateBackCommand { get; private set; }

        private NavigationService() 
        {
            NavigateBackCommand = new AppCommand(NavigateBack);
        }

        public void NavigateTo(string viewModelName, object model = null)
        {
            var viewModel = ViewModelFactory.CreateViewModel(viewModelName, model);
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
