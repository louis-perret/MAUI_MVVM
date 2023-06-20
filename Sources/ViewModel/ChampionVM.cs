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
public class ChampionVM : GenericBaseVM<Champion>
{
    private static ObservableCollection<string> _allChampionClass = new ObservableCollection<string>(Enum.GetValues(typeof(ChampionClass)).Cast<ChampionClass>().ToList().Select(c => c.ToString()).ToList());
    public ReadOnlyObservableCollection<string> AllChampionClass { get; private set; } = new ReadOnlyObservableCollection<string>(_allChampionClass);

    override internal Champion Modele
    {
        get => _modele;
        set
        {
            if (_modele != value)
            {
                _modele = value;
                InitObservableleCollections();
                // OnPropertyChanged();
            }
        }
    }

    public String Name
    {
        get => Modele.Name;
        set
        {
            if (value != null && !Name.Equals(value))
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
            if (value != null && value.Count() > 0)
            {
                /* byte[] test = new byte[value.Count()];
                 foreach(var element in value)
                 {
                     test.Append(element);
                 }*/
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
            if (!Class.Equals(value))
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
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private string _value = "0";

    public string ValueCharacteristics
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();
        }
    }

    public ReadOnlyObservableCollection<KeyValuePair<string, int>> Characteristics { get; private set; }

    private ObservableCollection<KeyValuePair<string, int>> _characteristics;

    public ReadOnlyObservableCollection<SkillVM> Skills { get; private set; }

    private ObservableCollection<SkillVM> _skills;

    public ChampionVM? CopyForEdition { get; private set; }

    private bool _isEditing = false;
    public bool IsEditing
    {
        get => _isEditing;
        set
        {
            if (value) CopyForEdition = CreateCopy();
            else CopyForEdition = null;
        }
    }

    public ICommand AddCharacteristicsCommand { get; private set; }
    public ICommand RemoveCharacteristicsCommand { get; private set; }
    public ICommand EditChampionCommand { get; private set; }
    public ICommand SetChampionClassCommmand { get; private set; }
    public ICommand AddSkillCommand { get; private set; }
    public ICommand RemoveSkillCommand { get; private set; }

    public ChampionVM(Champion modele = null) : base(modele)
    {
       
        
        if (modele == null) Modele = new Champion("Name");
        else
        {
            Modele = modele;
        }

        AddCharacteristicsCommand = new Command(
                execute: () => AddCharacteristics(),
                canExecute: () =>
                {
                    try
                    {
                        Convert.ToInt32(ValueCharacteristics);
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });

        RemoveCharacteristicsCommand = new Command(
                execute: (object arg) => RemoveCharacteristics(arg as string));
        EditChampionCommand = new Command(
                execute: () => EditFromCopy());
        SetChampionClassCommmand = new Command(
            execute: (object arg) => Class = arg as string);
        AddSkillCommand = new Command(
            execute: (object arg) => AddSkill(arg as SkillVM));
        RemoveSkillCommand = new Command(
            execute: (object arg) => RemoveSkill(arg as SkillVM));
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        if (propertyName.Equals(nameof(ValueCharacteristics)))
        {
            (AddCharacteristicsCommand as Command).ChangeCanExecute();
        }
        base.OnPropertyChanged(propertyName);
    }

    private void AddCharacteristics()
    {
        if (!Modele.Characteristics.ContainsKey(NameCharacteristics))
        {
            Modele.AddCharacteristics(new Tuple<string, int>[] { new Tuple<string, int>(NameCharacteristics, Convert.ToInt32(ValueCharacteristics)) });
            _characteristics.Add(new KeyValuePair<string, int>(NameCharacteristics, Convert.ToInt32(ValueCharacteristics)));
            NameCharacteristics = string.Empty;
            ValueCharacteristics = "0";
        }
    }

    private void RemoveCharacteristics(string name)
    {
        if (Modele.Characteristics.ContainsKey(name))
        {
            Modele.RemoveCharacteristics(name);
            var element = _characteristics.Where(c => c.Key.Equals(name)).FirstOrDefault();
            _characteristics.Remove(element);
        }
    }

    private void AddSkill(SkillVM skill)
    {
        if(skill != null)
        {
            Modele.AddSkill(skill.Modele);
            _skills.Add(skill);
        }
    }

    private void RemoveSkill(SkillVM skill)
    {
        if(skill != null)
        {
            Modele.RemoveSkill(skill.Modele);
            _skills.Remove(skill);
        }
    }

    private ChampionVM CreateCopy()
    {
        Champion copy = new Champion(Modele.Name , Modele.Class, Modele.Icon, Modele.Image.Base64, Modele.Bio);
        foreach(var characteristic in this.Characteristics)
        {
            copy.AddCharacteristics(new Tuple<string, int>(characteristic.Key, characteristic.Value));
        }
        foreach (var skill in this.Skills)
        {
            copy.AddSkill(skill.Modele);
        }
        return new ChampionVM(copy);
    }

    public void EditFromCopy()
    {
        Name = CopyForEdition.Name;
        Image = CopyForEdition.Image;
        Icon = CopyForEdition.Icon;
        Class = CopyForEdition.Class;
        Bio = CopyForEdition.Bio;
        foreach(var c in _characteristics)
        {
            Modele.RemoveCharacteristics(c.Key);
        }
        _characteristics.Clear();
        foreach(var c in CopyForEdition.Characteristics)
        {

            NameCharacteristics = c.Key;
            ValueCharacteristics = Convert.ToString(c.Value);
            AddCharacteristics();
        }
        foreach (var s in Modele.Skills)
        {
            Modele.RemoveSkill(s);
        }
        _skills.Clear();
        foreach (var s in CopyForEdition.Skills)
        {
            AddSkill(s);
        }
        IsEditing = false;
    }

    private void InitObservableleCollections()
    {
        if (_characteristics == null)
        {
            _characteristics = new ObservableCollection<KeyValuePair<string, int>>();
            Characteristics = new ReadOnlyObservableCollection<KeyValuePair<string, int>>(_characteristics);
        }
        else
        {
            _characteristics.Clear();
        }

        foreach (var c in Modele.Characteristics)
        {
            _characteristics.Add(c);
        }

        if (_skills == null)
        {
            _skills = new ObservableCollection<SkillVM>();
            Skills = new ReadOnlyObservableCollection<SkillVM>(_skills);
        }
        else
        {
            _skills.Clear();
        }

        foreach (var skill in Modele.Skills)
        {
            _skills.Add(new SkillVM(skill));
        }
    }


    public override bool Equals(object obj)
    {
        return obj is ChampionVM vm && this.Modele.Equals(vm.Modele);
    }
}

