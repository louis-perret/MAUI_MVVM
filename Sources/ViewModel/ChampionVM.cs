using System.ComponentModel;
using System.Runtime.CompilerServices;
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

    public String Image
    {
        get => Modele.Image.Base64;
        set
        {
            if(!string.IsNullOrWhiteSpace(value) && !Image.Equals(value))
            {
                Modele.Image.Base64 = value;
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

    public ChampionVM(Champion modele)
    {
        Modele = modele;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

