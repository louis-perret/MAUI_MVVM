using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
	public class BaseVM : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseVM()
		{
		}

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

