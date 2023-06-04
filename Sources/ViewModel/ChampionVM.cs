using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        set
        {
            if(value != null && !Name.Equals(value))
            {
                Modele.Name = value;
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

    public string Class
    {
        get => Modele.Class.ToString();
        set
        {
            if(Class.Equals(value))
            {
                Modele.Class = Enum.GetValues(typeof(ChampionClass)).Cast<ChampionClass>().ToList().Where(c => c.ToString() == value).First();
                OnPropertyChanged();
            }
        }
    }

    public string Bio
    {
        get => Modele.Bio;
        set
        {
            if (!string.IsNullOrWhiteSpace(value) && !Bio.Equals(value))
            {
                Modele.Bio = value;
                OnPropertyChanged();
            }
        }
    }

    private string _name = "";

    public string NameCharacteristics
    {
        get => _name;
        set => _name = value;
    }

    private string _value = "0";

    public string ValueCharacteristics
    {
        get => _value;
        set => _value = value;
    }


    public ReadOnlyObservableCollection<KeyValuePair<string, int>> Characteristics { get; private set; }

    private ObservableCollection<KeyValuePair<string, int>> _characteristics;

    public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }

    private ObservableCollection<SkillVM> _skills;

    public ICommand AddCharacteristicsCommand { get; private set; }

    public ChampionVM(Champion modele = null)
    {
        _characteristics = new ObservableCollection<KeyValuePair<string, int>>();
        Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(_characteristics);
        _skills = new ObservableCollection<SkillVM>();
        Skills = new ReadOnlyObservableCollection<SkillVM>(_skills);
        if (modele == null) Modele = new Champion("Name");
        else
        {
            Modele = modele;
            foreach (var c in Modele.Characteristics)
            {
                _characteristics.Add(c);
            }
           
            foreach (var skill in Modele.Skills)
            {
                _skills.Add(new SkillVM(skill));
            }
        }

        AddCharacteristicsCommand = new Command(
                execute: () => AddCharacteristics());
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AddCharacteristics()
    {
        if (!Modele.Characteristics.ContainsKey(NameCharacteristics))
        {
            Modele.AddCharacteristics(new Tuple<string, int>[] { new Tuple<string, int>(NameCharacteristics, Convert.ToInt32(ValueCharacteristics))});
            _characteristics.Add(new KeyValuePair<string, int>(NameCharacteristics, Convert.ToInt32(ValueCharacteristics)));
        }
    }
}

