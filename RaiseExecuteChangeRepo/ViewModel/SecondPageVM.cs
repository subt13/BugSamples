using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseExecuteChangeRepo.ViewModel
{
    public class SecondPageVM :ViewModelBase
    {
        private RelayCommand navigateCommand;
        INavigationService navigationService;
        public SecondPageVM(INavigationService navigationService)
        {
            this.navigationService = navigationService;
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

        private void Nav()
        {
            this.navigationService.NavigateTo("MainPage");
        }
    }
}
