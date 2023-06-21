using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel
{
    /// <summary>
    /// Représente une VM wrappant un type du modèle générique
    /// </summary>
    /// <typeparam name="T">Type du modèle wrappé</typeparam>
	public class GenericBaseVM<T> : BaseVM
	{
        protected T _modele;

        virtual protected internal T Modele
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

