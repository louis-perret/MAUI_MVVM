using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
	public class GenericBaseVM<T> : BaseVM
	{
        protected T _modele;

        virtual internal T Modele
        {
            get => _modele;
            set => _modele = value;
        }

        public GenericBaseVM(T modele)
		{
            Modele = modele;
		}

        
    }
}

