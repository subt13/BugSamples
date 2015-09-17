using GalaSoft.MvvmLight;
using RaiseExecuteChangeRepo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiseExecuteChangeRepo.ViewModel
{
    public class AnotherVM : ViewModelBase
    {
        DataItem item;
        public AnotherVM(DataItem item)
        {
            this.item = item;
        }

        public string Title
        {
            get
            {
                return this.item.Title;
            }
            set
            {
                this.item.Title = value;
            }
        }
    }
}
