using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using ViewModel;
using Views.ContentViews;

namespace Views.Pages;

/// <summary>
/// Page d'édition d'un champion
/// </summary>
public partial class EditingChampionPage : ContentPage
{
    /// <summary>
    /// VM applicative
    /// </summary>
    public AppVM AppVM { get; private set; }

    /// <summary>
    /// Command pour afficher la pop up pour ajouter les skills. Doit être géré dans cette fenêtre et non par la VM applicative.
    /// </summary>
    public ICommand ShowPopSkillCommand { get; private set; }

    public EditingChampionPage(AppVM appVM)
	{
        this.AppVM = appVM;
        BindingContext = AppVM.ManagerVM.CurrentChampionVM.CopyForEdition;
        ShowPopSkillCommand = new Command(
            execute: async () => await ShowPopSkill());
        InitializeComponent();
    }

    /// <summary>
    /// Affiche et récupère le résultat de la pop up
    /// </summary>
    /// <returns></returns>
    async Task ShowPopSkill()
    {
        var popup = new AddSkill();

        var result = await this.ShowPopupAsync(popup);

        if (result is SkillVM && result != null)
        {
            AppVM.ManagerVM.CurrentChampionVM.CopyForEdition.AddSkillCommand.Execute(result);
        }
    }
}
