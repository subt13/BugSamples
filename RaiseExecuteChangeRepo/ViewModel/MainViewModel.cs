using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using RaiseExecuteChangeRepo.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace RaiseExecuteChangeRepo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private RelayCommand selectCommand;
        private RelayCommand loadDataCommand;
        private RelayCommand navigateCommand;

        public MainViewModel(
            INavigationService navigationService, 
            IMessenger messengerService)
        { 
            this.navigationService = navigationService;
            this.Data = new ObservableCollection<AnotherVM>();
        }

        public ObservableCollection<AnotherVM> Data
        {
            get;
            private set;
        }

        public RelayCommand LoadDataCommand
        {
            get
            {
                return this.loadDataCommand ?? (
                    this.loadDataCommand =
                    new RelayCommand(this.ExecuteLoadDataCommandAsync));
            }
        }

        public RelayCommand SelectCommand
        {
            get
            {
                return
                    this.selectCommand ??
                    (this.selectCommand = new RelayCommand(this.Select));
            }
        }


        public RelayCommand NavigateCommand
        {
            get
            {
                return this.navigateCommand ?? (
                    this.navigateCommand =
                    new RelayCommand(this.Nav));
            }
        }

        /// <summary>
        /// Navigate to second page
        /// </summary>
        private void Nav()
        {
            this.navigationService.NavigateTo("SecondPage");
        }

        /// <summary>
        /// Slow the app down
        /// </summary>
        /// <returns></returns>
        public List<DataItem> GetData()
        {
            var myList = new List<DataItem>();
            for (int i = 0; i < 100000; ++i)
            {
                myList.Add(new DataItem("Welcome to MVVM Light"));

            }

            return myList;
        }

        private async void ExecuteLoadDataCommandAsync()
        {
            // cause the app to slow done.
            var data = await Task.Run(() => GetData()); 
        
            if (data != null)
            {
                this.Data.Clear();

                foreach (var item in data)
                {
                    this.Data.Add(new AnotherVM(item));
                }
            }

            // have the select job command rerun its condition
            this.SelectCommand.RaiseCanExecuteChanged();
        }

        private void Select()
        { 
        }
    }
}