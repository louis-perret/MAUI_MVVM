﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;

namespace ViewModel
{
	public class ChampionManagerVM : INotifyPropertyChanged
	{

		public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> _champions = new ObservableCollection<ChampionVM>();

		private IDataManager DataManager { get; set; }

		private int _pageNumber = 0;

		public int PageNumber
		{
			get => _pageNumber;
			set
			{
				if (value < 0) _pageNumber = 0;
				var nbMax = _champions.Count / NbElementsMax;
				if (value > nbMax) _pageNumber = nbMax;
				_pageNumber = value;
				OnPropertyChanged();
            }
		}

		public int NbNumberMaxPage => _champions.Count / NbElementsMax;

        public int NbElementsMax => 5;

		public ICommand SetCurrentPageCommand { get; private set; }

		public ChampionManagerVM(IDataManager dataManager)
		{
			DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
			SetCurrentPageCommand = new Command(
				execute: (object arg) => SetCurrentPage((string)arg));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected async virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
			if (propertyName.Equals(nameof(PageNumber))) await LoadChampions();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadChampions()
		{
			_champions.Clear();
			foreach (var champion in await DataManager.ChampionsMgr.GetItems(PageNumber, NbElementsMax))
			{
				var c = new ChampionVM(champion);
                _champions.Add(c);
			}
        }

		private void SetCurrentPage(string number)
		{
			PageNumber = PageNumber + Convert.ToInt32(number);
		}
    }
}
