using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using RaiseExecuteChangeRepo.Model;

namespace RaiseExecuteChangeRepo.ViewModel
{
    public class ViewModelLocator
    {
        public const string SecondPageKey = "SecondPage";

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            var nav = new NavigationService();
            nav.Configure("MainPage", typeof(MainPage));
            nav.Configure(SecondPageKey, typeof(SecondPage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SecondPageVM>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public SecondPageVM Second => ServiceLocator.Current.GetInstance<SecondPageVM>();
    }
}
