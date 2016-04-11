using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManager
{
    public class ViewModel : INotifyPropertyChanged
    {

        static ViewModel VM;

        public static ViewModel Get()
        {
            if (VM == null)
                VM = new ViewModel();
            return VM;
        }

        ViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropChanged([CallerMemberName] string n = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(n));
        }
    }
}
