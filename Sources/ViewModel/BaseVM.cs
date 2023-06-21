using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    /// <summary>
    /// BaseVM de base avec seulement le INotifyPropertyChanged
    /// </summary>
	public class BaseVM : INotifyPropertyChanged
	{
        /// <summary>
        /// Event de changement
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseVM()
		{
		}

        /// <summary>
        /// Méthode appelée quand une propriété change
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

