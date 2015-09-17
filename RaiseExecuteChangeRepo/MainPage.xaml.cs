using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using RaiseExecuteChangeRepo.ViewModel;
using System.Threading.Tasks;

namespace RaiseExecuteChangeRepo
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

        }

    }
}
