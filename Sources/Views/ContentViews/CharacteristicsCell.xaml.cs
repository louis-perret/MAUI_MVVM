using System.Collections.ObjectModel;
using ViewModel;

namespace Views.ContentViews;

public partial class CharacteristicsCell : ContentView
{

    public static readonly BindableProperty ChampionProperty = BindableProperty.Create(nameof(Champion), typeof(ChampionVM), typeof(CharacteristicsCell), null);

    public ChampionVM Champion
    {
        get => (ChampionVM)GetValue(ChampionProperty);
        set => SetValue(ChampionProperty, value);
    }
    /*
    public static readonly BindableProperty KeyProperty = BindableProperty.Create(nameof(Key), typeof(string), typeof(CharacteristicsCell), string.Empty);

    public string Key
    {
        get => (string)GetValue(KeyProperty);
        set => SetValue(KeyProperty, value);
    }

    public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(int), typeof(CharacteristicsCell), 0);

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }*/

    public CharacteristicsCell()
	{
		InitializeComponent();
	}
}
