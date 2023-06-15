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
        public ICommand ShowDetailChampionPageCommand { get; private set; }
        public ICommand ShowFilePickerCommand { get; private set; }
        public ICommand AddChampionCommand { get; private set; }
        public ICommand CancelAddingAChampionCommand { get; private set; }

        public AppVM(ChampionManagerVM managerVM)
		{
			ManagerVM = managerVM;
            ManagerVM.PageNumber = 0;
            ShowAddChampionPageCommand = new Command(
                execute: () => ShowAddChampionPage());
            ShowDetailChampionPageCommand = new Command(
                execute: (object arg) => ShowDetailChampionPage((ChampionVM)arg));
            ShowFilePickerCommand = new Command(
               execute: (object arg) => LoadImageFile((string)arg));
            AddChampionCommand = new Command(
               execute: () => AddChampion());
            CancelAddingAChampionCommand = new Command(
               execute: () => CancelAddChampion());
        }

        private async void ShowDetailChampionPage(ChampionVM champion)
        {
            ManagerVM.CurrentChampionVM = champion;
            await Navigation.PushAsync(new CharacterPage(ManagerVM));
        }

        private async void ShowAddChampionPage()
		{
            ManagerVM.IsNewChampion = true;
            await Navigation.PushAsync(new NewChampionPage(this));
        }

        private void ShowEditingChampionPage()
        {
            /*ManagerVM.IsNewChampion = true;
            await Navigation.PushAsync(new NewChampionPage(ManagerVM));¨*/
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

        async void AddChampion()
        {
            ManagerVM.AddChampion();
            await Navigation.PopAsync();
        }

        async void CancelAddChampion()
        {
            ManagerVM.AddChampion(true);
            await Navigation.PopAsync();
        }
    }
}

