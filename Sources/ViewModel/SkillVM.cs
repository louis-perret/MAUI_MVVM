using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
    /// <summary>
    /// ViewModèle représentant les Skill du modèle
    /// </summary>
	public class SkillVM : GenericBaseVM<Skill>
    {
        /// <summary>
        /// Toutes les classes que peut posséder un skill
        /// </summary>
        private static ObservableCollection<string> _allSkillType = new ObservableCollection<string>(Enum.GetValues<SkillType>().Select(s => s.ToString()).ToList());
        public ReadOnlyObservableCollection<string> AllSkillType { get; private set; } = new ReadOnlyObservableCollection<string>(_allSkillType);

        public string Type
        {
            get => Modele.Type.ToString();
            set
            {
                if (!Type.Equals(value))
                {
                    Modele.Type = Enum.GetValues<SkillType>().Where(t => t.ToString() == value).First();
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => Modele.Name;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Modele.Name = "_"; // car un skill ne peut pas avoir un nom vide
                }
                else
                {
                    Modele.Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Description
        {
            get => Modele.Description;
            set
            {
                Modele.Description = value;
                OnPropertyChanged();
            }
        }

        public SkillVM() : base(new Skill("Name", SkillType.Unknown))
        {
            
        }

        public SkillVM(Skill modele) : base(modele)
        {
            Modele = modele;
        }
    }
}

