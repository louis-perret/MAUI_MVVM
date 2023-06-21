using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Model;

namespace ViewModel
{
	/// <summary>
	/// ViewModel wrappant le manager  
	/// </summary>
	public class ChampionManagerVM : BaseVM
	{
		/// <summary>
		///  Champion actuellement sélectionné par l'utilisateur
		/// </summary>
		private ChampionVM _championVM;

		public ChampionVM CurrentChampionVM
		{
			get => _championVM;
			set
			{
				if(value != null)
				{
					_championVM = value;
					OnPropertyChanged();
				}
				else
				{
					_championVM = new ChampionVM(); // Dans le cas d'un ajout de champion, je set un nouveau champion
				}
			}
		}

		/// <summary>
		/// Liste des champions
		/// </summary>
		public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> _champions = new ObservableCollection<ChampionVM>();

		/// <summary>
		/// True si l'utilisateur est entrain d'ajouter un nouveau champion
		/// </summary>
		private bool _isNewChampion = false;

		public bool IsNewChampion
		{
			get => _isNewChampion;
			set
			{
				if (value)
				{
					CurrentChampionVM = null;
				}
				_isNewChampion = value;
			}
		}

		/// <summary>
		/// Data manager
		/// </summary>
		private IDataManager DataManager { get; set; }

		/// <summary>
		/// Index de la page courante
		/// </summary>
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

		/// <summary>
		/// Nombre de page maximum
		/// </summary>
		public int NbNumberMaxPage => _champions.Count / NbElementsMax;

		/// <summary>
		/// Nombre d'éléments max par page
		/// </summary>
        public int NbElementsMax => 5;

		/// <summary>
		/// Commande pour aller à la page suivante
		/// </summary>
		public ICommand SetNextPageCommand { get; private set; }

        /// <summary>
        /// Commande pour aller à la page précédente
        /// </summary>
        public ICommand SetPreviousPageCommand { get; private set; }

		/// <summary>
		/// Commande pour supprimer un champion
		/// </summary>
        public ICommand DeleteChampionCommand { get; private set; }

		
        public ChampionManagerVM(IDataManager dataManager)
		{
			DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
			SetNextPageCommand = new Command(
				execute: () => PageNumber += 1,
				canExecute: () => { return PageNumber < NbNumberMaxPage; });
            SetPreviousPageCommand = new Command(
                execute: () => PageNumber -= 1,
                canExecute: () => { return PageNumber > 0; });
           
            DeleteChampionCommand = new Command(
                execute: async (object arg) => await DeleteChampion(arg as ChampionVM));
        }

	
        protected override async void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
			if (propertyName.Equals(nameof(PageNumber)))
			{
				await LoadChampions();
                (SetNextPageCommand as Command).ChangeCanExecute();
                (SetPreviousPageCommand as Command).ChangeCanExecute();
            }
			base.OnPropertyChanged(propertyName);
        }

		/// <summary>
		/// Charge les champions avec système de pagination
		/// </summary>
		/// <returns></returns>
        private async Task LoadChampions()
		{
			_champions.Clear();
			foreach (var champion in await DataManager.ChampionsMgr.GetItems(PageNumber, NbElementsMax))
			{
				var c = new ChampionVM(champion);
                _champions.Add(c);
			}
        }

		/// <summary>
		/// Set la page courante
		/// </summary>
		/// <param name="number"></param>
		private void SetCurrentPage(int number)
		{
			PageNumber = PageNumber + Convert.ToInt32(number);
		}

		/// <summary>
		/// Ajoute un champion. Se base sur la propriété CurrentChampion
		/// </summary>
		/// <param name="isCanceled"></param>
		/// <returns></returns>
		public async Task AddChampion(bool isCanceled = false)
		{
			if (!isCanceled) 
				await DataManager.ChampionsMgr.AddItem(CurrentChampionVM.Modele);
			CurrentChampionVM = null;
            await LoadChampions();
        }

		/// <summary>
		/// Supprime un champion
		/// </summary>
		/// <param name="champion">Champion à supprimer</param>
		/// <returns></returns>
		private async Task DeleteChampion(ChampionVM champion)
		{
			if (champion != null)
			{
                await DataManager.ChampionsMgr.DeleteItem(champion.Modele);
				_champions.Remove(champion);
				await LoadChampions();
			}
		}
    }
}
