using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CIT255_KT_list_builder.Models;
using CIT255_KT_list_builder;
using CIT255_KT_list_builder.BusinessLayer;
using CIT255_KT_list_builder.DataAccessLayer;
using CIT255_KT_list_builder.Data;
using CIT255_KT_list_builder.Commands;


namespace CIT255_KT_list_builder.PresentationLayer.ViewModels
{
   public class KTViewModel : ObservableObject 
    {
        #region ENUMS
        private enum ActiveOperation
        {
            NONE, 
            VIEW,
            UPDATE,
            ADD,
            DELETE

        }
        #endregion

        #region FIELDS
        private KTBusiness _ktBusiness;
        private ActiveOperation _currentOperation;
        private FighterList _currentRoster;
        private Fighter _currentFighter;
        private Fighter _displayFighter;
        private FighterWargear _selectedWargear;
       
        private ObservableCollection<FighterList> _availableRosters;
        private ObservableCollection<String> _availableRostersName;      
        private ObservableCollection<Fighter> _fighters;
        private ObservableCollection<FighterWargear> _fighterWargear;

        private bool _isEditing;
        private bool _showButton;       

        private string _currentFighterImageSource;
        private string _selectedRosterName;

      


        #endregion

        #region PROPERTIES
        public KTBusiness KtBusiness
        {
            get { return _ktBusiness; }
            set { _ktBusiness = value; }
        }
        private ActiveOperation CurrentOperation
        {
            get { return _currentOperation; }
            set { _currentOperation = value; }
        }
        public FighterList CurrentRoster
        {
            get { return _currentRoster; }
            set
            {
                _currentRoster = value;
                OnPropertyChanged(nameof(CurrentRoster));
            }
        }
        public Fighter CurrentFighter
        {
            get { return _currentFighter; }
            set
            {
                if (_currentFighter == value)
                {
                    return;
                }
                _currentFighter = value;
                _currentFighter.CompileFighterInventory();
                _currentRoster.GetListPoints();
                OnPropertyChanged(nameof(CurrentFighter));
                OnPropertyChanged(nameof(CurrentRoster));
            }
        }
        public Fighter DisplayFighter
        {
            get { return _displayFighter; }
            set
            {
                if (_displayFighter == value)
                {
                    return;
                }
                _displayFighter = value;
                OnPropertyChanged(nameof(DisplayFighter));
            }
        }
        public FighterWargear SelectedWargear
        {
            get { return _selectedWargear; }
            set
            {   if (_selectedWargear == value)
                {
                    return;
                }
                _selectedWargear = value;
                OnPropertyChanged(nameof(SelectedWargear));
            }
        }

        public ObservableCollection<FighterList> AvailableRosters
        {
            get { return _availableRosters; }
            set
            {
                _availableRosters = value;
                OnPropertyChanged(nameof(AvailableRosters));
            }
        }
        public ObservableCollection<String> AvailableRostersName
        {
            get { return _availableRostersName; }
            set
            {
                _availableRostersName = value;
                OnPropertyChanged(nameof(AvailableRostersName));

            }
        }
        public ObservableCollection<Fighter> Fighters
        {
            get { return _fighters; }
            set
            {
                _fighters = value;
                OnPropertyChanged(nameof(Fighters));
            }
        }
        public ObservableCollection<FighterWargear> FighterWargear
        {
            get { return _fighterWargear; }
            set
            {
                _fighterWargear = value;
                OnPropertyChanged(nameof(FighterWargear));
            }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set
            {
                _isEditing = value;
                OnPropertyChanged(nameof(IsEditing));
            }
        }
        public bool ShowButton
        {
            get { return _showButton; }
            set
            {
                _showButton = value;
                OnPropertyChanged(nameof(ShowButton));
            }
        }

        public string CurrentFighterImageSource
        {
            get { return _currentFighterImageSource; }
            set
            {
                _currentFighterImageSource = _currentFighter.ImgSource;
                OnPropertyChanged(nameof(CurrentFighterImageSource));
            }
        }
        public string SelectedRosterName
        {
            get { return _selectedRosterName; }
            set
            {
                _selectedRosterName = value;
                SetCurrentRosterByName();
            }
        }
        public string Errors { get; set; }

        #endregion

        #region COMMANDS

        /// <summary>
        /// Command to call the delete fighter from roster method.
        /// </summary>
        public ICommand DeleteFighterFromRosterCommand
        {
            get { return new RelayCommand(new Action(DeleteFighter)); }
        }

        public ICommand AddNewFighterToRosterCommand
        {
            get { return new RelayCommand(new Action(AddFighter)); }
        }

        
        //public ICommand CreateNewRosterCommand
        //{
        //    get { return new RelayCommand(new Action())};
        //}
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default Constructor: 
        /// </summary>
        public KTViewModel(KTBusiness kTBusiness)
        {   
            // Initialize business logic:
            _ktBusiness = kTBusiness;
            
            //Initialize collections:
            _availableRosters = new ObservableCollection<FighterList>(SeedData.GenerateRoster());
            //  _availableRosters = new ObservableCollection<FighterList>(kTBusiness.AllRosters());
            _availableRostersName = new ObservableCollection<string>();

            // Misc.
            CreateRosterSelectList();
            UpdateImagePath();
            _currentRoster = _availableRosters.FirstOrDefault(r => r.ListID > 0);
            _selectedRosterName = _currentRoster.ListName;
            _currentFighter = _currentRoster.SelectedFighters.FirstOrDefault( f => f.FighterID > 0);
            
                   
        }
       
        #endregion

        #region METHODS

     

        #endregion

        #region ROSTER METHODS

        /// <summary>
        /// Helper method that creates a list of names for the view to consume.
        /// </summary>
        private void CreateRosterSelectList()
        {
            foreach (FighterList roster in AvailableRosters)
            {
                AvailableRostersName.Add(roster.ListName);
            }
        }

        /// <summary>
        /// Creates an empty roster for the user.
        /// </summary>
        private void CreateNewRoster ()
        {
            FighterList newList = new FighterList();
            AvailableRosters.Add(newList);

        }

        #endregion

        #region FIGHTER METHODS

        /// <summary>
        /// Creates a new blank fighter and adds it to the current roster.
        /// </summary>
        private void AddFighter()
        {
            if (_currentRoster != null)
            {
                Fighter newFighter = new Fighter()
                {
                    FighterName = "New Fighter",
                    FighterType = "Type ?",
                    FighterCost = 0,
                    FighterEquipmentList = new List<FighterWargear>(),
                    FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>(),
                    FighterRangedWeaponOptions = new List<FighterRangedWeapons>(),
                    FighterSpecialization = Fighter.Specializations.NONE                   

                };
                newFighter.FighterSpecializationOptions = newFighter.GenerateListofSpecializations();
                CurrentRoster.SelectedFighters.Add(newFighter);
                CurrentFighter = newFighter;
                //_ktBusiness.UpdateRoster(CurrentRoster);
                
            }

            else
            {
                Errors = "No roster selected.";
            }
        }

        /// <summary>
        /// Removes a fighter from the current roster. 
        /// </summary>
        private void DeleteFighter()
        {
            if (_currentFighter != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Confirm removal of {CurrentFighter.FighterName}? This cannot be undone.", "Delete", System.Windows.MessageBoxButton.OKCancel);

                if (messageBoxResult == MessageBoxResult.OK)
                {
                    CurrentRoster.SelectedFighters.Remove(CurrentRoster.SelectedFighters.FirstOrDefault(c => c.FighterID == _currentFighter.FighterID));

                    //_ktBusiness.UpdateRoster(CurrentRoster);

                }
            }
        }

   
        #endregion

        #region HELPER METHODS
        
        /// <summary>
        /// Helper method that sources the image for the view:
        /// </summary>
        private void UpdateImagePath()
        {
            foreach (FighterList roster in AvailableRosters)
            {
                foreach (Fighter fighter in roster.SelectedFighters)
                {
                    fighter.ImgSource = DataConfig.ImagePath.ToString() + fighter.ImgFile.ToString();
                }
            }

           
        }

        /// <summary>
        /// Helper method that takes the selected Roster Name and uses it to set the active fighterlist object.
        /// </summary>
        private void SetCurrentRosterByName()
        {
            CurrentRoster = AvailableRosters.FirstOrDefault(r => r.ListName == SelectedRosterName);
        }

        /// <summary>
        /// Calls a method to shut down the application. 
        /// </summary>
        private void ExitApplication()
        {
            System.Environment.Exit(1);
        }

        /// <summary>
        /// Sorts the list by the total fighter cost.
        /// </summary>
        private void SortListByCost()
        {
            CurrentRoster.SelectedFighters = new List<Fighter>(CurrentRoster.SelectedFighters.OrderBy(c => c.FighterTotalCost));
        }

        /// <summary>
        /// Sorts the list by the fighter names.
        /// </summary>
        private void SortListByFighterName()
        {
            CurrentRoster.SelectedFighters = new List<Fighter>(CurrentRoster.SelectedFighters.OrderBy(c => c.FighterName));
        }

        /// <summary>
        /// Sorts the list by the fighter types.
        /// </summary>
        private void SortListByFighterType()
        {
            CurrentRoster.SelectedFighters = new List<Fighter>(CurrentRoster.SelectedFighters.OrderBy(c => c.FighterType));
        }

        #endregion


    }
}
