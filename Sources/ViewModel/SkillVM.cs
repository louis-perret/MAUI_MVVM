using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
	public class SkillVM : INotifyPropertyChanged
    {

		private Skill Modele { get; set; }

        public string Type
        {
            get => Modele.Type.ToString();
            set
            {
                if (Type.Equals(value))
                {
                    Modele.Type = Enum.GetValues(typeof(SkillType)).Cast<SkillType>().ToList().Where(t => t.ToString() == value).First();
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => Modele.Name;
            set 
            {
                Modele.Name = value;
                OnPropertyChanged();
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

        public SkillVM(Skill modele)
        {
            Modele = modele;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

