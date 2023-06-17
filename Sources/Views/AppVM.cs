using System;
using System.Windows.Input;
using CommunityToolkit.Maui.Converters;
using ViewModel;
using Views.Pages;

namespace Views
{
    // VM Applicative
	public class AppVM
	{
		public ChampionManagerVM ManagerVM { get; set; }

		public INavigation Navigation { get; set; }

        public ICommand ShowAddChampionPageCommand { get; private set; }
        public ICommand ShowEditChampionPageCommand { get; private set; }
        public ICommand ShowDetailChampionPageCommand { get; private set; }
        public ICommand ShowFilePickerCommand { get; private set; }
        public ICommand AddChampionCommand { get; private set; }
        public ICommand CancelAddChampionCommand { get; private set; }
        public ICommand EditChampionCommand { get; private set; }
        public ICommand NavigateToBackCommand { get; private set; }

        public AppVM(ChampionManagerVM managerVM)
		{
			ManagerVM = managerVM;
            ManagerVM.PageNumber = 0;
            ShowAddChampionPageCommand = new Command(
                execute: () => ShowAddChampionPage());
            ShowEditChampionPageCommand = new Command(
                execute: (object arg) => ShowEditChampionPage(arg as ChampionVM));
            ShowDetailChampionPageCommand = new Command(
                execute: (object arg) => ShowDetailChampionPage((ChampionVM)arg));
            ShowFilePickerCommand = new Command(
               execute: (object arg) => LoadImageFile((string)arg));
            AddChampionCommand = new Command(
               execute: () => AddChampion());
            CancelAddChampionCommand = new Command(
               execute: () => CancelAddChampion());
            EditChampionCommand = new Command(
               execute: () => EditChampion());
            NavigateToBackCommand = new Command(
               execute: () => NavigateToBack());
        }

        private async void ShowDetailChampionPage(ChampionVM champion)
        {
            ManagerVM.CurrentChampionVM = champion;
            await Navigation.PushAsync(new CharacterPage(this));
        }

        private async void ShowAddChampionPage()
		{
            ManagerVM.IsNewChampion = true;
            await Navigation.PushAsync(new NewChampionPage(this));
        }

        private async void ShowEditChampionPage(ChampionVM? champion = null)
        {
            if(champion != null) // si == null => aucun champion n'a été affiché dans le Detail
            {
                ManagerVM.CurrentChampionVM = champion;
            }
            ManagerVM.CurrentChampionVM.IsEditing = true;
            await Navigation.PushAsync(new EditingChampionPage(this));
        }

        private async void LoadImageFile(string targetProperty)
        {
            var result = await FilePicker.PickAsync(new PickOptions { PickerTitle = "Pick Icon", FileTypes = FilePickerFileType.Images });
            if (result == null)
                return;

            byte[] bytes;
            using var stream = await result.OpenReadAsync();
            var image = ImageSource.FromStream(() => stream);
            var converter = new ByteArrayToImageSourceConverter();
            bytes = converter.ConvertBackTo(image);
            if (targetProperty.Equals("icon"))
            {
                ManagerVM.CurrentChampionVM.Icon = bytes;
            }
            else
            {
                ManagerVM.CurrentChampionVM.Image = bytes;
            }
        }

        private async void AddChampion()
        {
            ManagerVM.AddChampion();
            await Navigation.PopAsync();
        }

        private async void EditChampion()
        {
            ManagerVM.CurrentChampionVM.EditFromCopy();
            await Navigation.PopAsync();
        }

        private void CancelAddChampion()
        {
            ManagerVM.AddChampion(true);
            NavigateToBack();
        }

        private async void NavigateToBack()
        {
            ManagerVM.CurrentChampionVM = null;
            await Navigation.PopAsync();
        }

        public void DeleteChampion(ChampionVM champion, bool isCancelled)
        {
            if (!isCancelled)
            {
                ManagerVM.DeleteChampionCommand.Execute(champion);
            }
        }
    }
}

