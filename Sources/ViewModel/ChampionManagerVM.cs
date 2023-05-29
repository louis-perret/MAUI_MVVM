﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
	public class ChampionManagerVM : INotifyPropertyChanged
	{

		public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> _champions = new ObservableCollection<ChampionVM>();

		private IDataManager DataManager { get; set; }

		private ChampionVM _selectedChampionVM;

		public ChampionVM SelectedChampionVM
		{
			get => _selectedChampionVM;
			set
			{
				if(value != null)
				{
					_selectedChampionVM = value;
					// OnPropertyChanged();
				}
			}
		}
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

		public int NbElementsMax => 5;

		public ChampionManagerVM(IDataManager dataManager)
		{
			DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
			
		}

        public event PropertyChangedEventHandler PropertyChanged;

        protected async virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
			if (propertyName.Equals(nameof(PageNumber))) await LoadChampions();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		public DeleguateNotifyChangementOfSelectedChampion NotifyChangementOfSelectedChampion { get; set; }
        public delegate void DeleguateNotifyChangementOfSelectedChampion();

        private async Task LoadChampions()
		{
			foreach (var champion in await DataManager.ChampionsMgr.GetItems(PageNumber, NbElementsMax))
			{
				var c = new ChampionVM(champion);
				c.SelectedChampion = SelectedChampionChanged;
                _champions.Add(c);
			}
        }

		public void SelectedChampionChanged(ChampionVM champion)
		{
			SelectedChampionVM = champion;
			NotifyChangementOfSelectedChampion();
		}
    }
}

