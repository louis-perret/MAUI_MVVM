using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Model;

namespace ViewModel;

// All the code in this file is included in all platforms.
public class ChampionVM : INotifyPropertyChanged
{
    private Champion Modele { get; set; }

    public String Name
    {
        get => Modele.Name;
        private set
        {
            if(value != null && !Name.Equals(value))
            {
                // Modele.Name = value;
                OnPropertyChanged();
            }
        }
    }

    public byte[] Image
    {
        get => Convert.FromBase64String(Modele.Image.Base64);
        set
        {
            if(value != null && value.Count() > 0)
            {
                Modele.Image.Base64 = Convert.ToBase64String(value);
                OnPropertyChanged();
            }
        }
    }

    public byte[] Icon
    {
        get => Convert.FromBase64String(Modele.Icon);
        set
        {
            if (value != null && value.Count() > 0)
            {
                Modele.Icon = Convert.ToBase64String(value);
                OnPropertyChanged();
            }
        }
    }

    public ChampionClass Class
    {
        get => Modele.Class;
        set
        {
            if(Class.Equals(value))
            {
                Modele.Class = value;
                OnPropertyChanged();
            }
        }
    }

    public string Bio
    {
        get => Modele.Bio;
        set
        {
            if(!string.IsNullOrWhiteSpace(value) && !Bio.Equals(value))
            {
                Modele.Bio = value;
                OnPropertyChanged();
            }
        }
    }

    public SetSelectedChampion SelectedChampion { get; set; }

    public delegate void SetSelectedChampion(ChampionVM value);

    public ChampionVM(Champion modele)
    {
        Modele = modele;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public ICommand ShowCharacterDetail => new Command(ShowCharacterDetailEvent);

    private void ShowCharacterDetailEvent()
    {
        SelectedChampion(this);
    }
}

