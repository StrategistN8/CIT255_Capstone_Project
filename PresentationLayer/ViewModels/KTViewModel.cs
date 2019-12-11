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
                OnPropertyChanged(nameof(CurrentFighter));
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

        #endregion

        #region COMMANDS

        public ICommand DeleteFighterFromRosterCommand
        {
            get { return new RelayCommand(new Action(DeleteFighter)); }
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
        /// Removes a fighter from the current roster. 
        /// </summary>
        private void DeleteFighter()
        {
            if (_currentFighter != null && _currentRoster != null)
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"Confirm removal of {CurrentFighter}? This cannot be undone.", "Delete", System.Windows.MessageBoxButton.OKCancel);

                if (messageBoxResult == MessageBoxResult.OK)
                {
                    CurrentRoster.SelectedFighters.Remove(CurrentRoster.SelectedFighters.FirstOrDefault(c => c.FighterID == _currentFighter.FighterID));

                    //_ktBusiness.UpdateRoster(CurrentRoster);
                    
                }
            }
        }

        /// <summary>
        /// Edits an existing fighter in the current roster.
        /// </summary>
        private void EditFighter()
        {
            if (_currentFighter != null && _currentRoster != null)
            {
                _currentOperation = ActiveOperation.UPDATE;
                IsEditing = true;
                ShowButton = false;
                // Method to update the temp character to persistance.
            }
        }
       
        /// <summary>
        /// Brings up the current configuration of a fighter from the list. 
        /// </summary>
        private void ViewFighterDetails()
        {
            if (_currentFighter != null && _currentRoster != null)
            {
                //_operationStatus = ActiveOperation.VIEW;
                IsEditing = false;
                // Method to update the temp character with data from persistance.
            }
        }

        /// <summary>
        /// Instantiates a new fighter and adds them to the list.
        /// </summary>
        private void AddNewFighter()
        {
            //ResetTempFighter
            IsEditing = true;
            ShowButton = false;
            //OperationStatus = ActiveOperation.ADD;
        }

        /// <summary>
        /// Method that completes operations after 
        /// </summary>
        private void SaveChanges()
        {
            switch (_currentOperation)
            {
                case ActiveOperation.NONE:
                    break;
                case ActiveOperation.VIEW:
                    break;
                case ActiveOperation.UPDATE:
                    Fighter fighterToUpdate = _currentRoster.SelectedFighters.FirstOrDefault(c => c.FighterID == CurrentFighter.FighterID);
                    if (_currentFighter != null && _currentRoster != null)
                    {
                        //_ktBusiness.UpdateFighter()
                        //_currentRoster.SelectedFighters.Remove();
                        //_currentRoster.SelectedFighters.Add();
                    }
                    break;
                case ActiveOperation.ADD:
                    if (_currentFighter != null && _currentRoster != null)
                    {
                        //_ktBusiness.AddFighter()
                        //_currentRoster.SelectedFighters.Add();
                    }
                    break;
                case ActiveOperation.DELETE:
                    break;
                default:
                    break;
            }

            // Method to reset the temp character.
            IsEditing = false;
            ShowButton = true;
            CurrentOperation = ActiveOperation.NONE;
        }
        
        /// <summary>
        /// Helper method that resets the app upon termination of an operation.
        /// </summary>
        private void OnCancelOperation()
        {
            //Method to reset temp character.
            _currentOperation = ActiveOperation.NONE;
            IsEditing = false;
            ShowButton = true;
        }
        
        /// <summary>
        /// Method that mirrors the selected character to the display character.
        /// </summary>
        private void UpdateDisplayFighterToSelectedFighter()
        {
            // Mirror currently selected fighter with the display fighter.
            _displayFighter = new Fighter(); 
            _displayFighter.FighterID = _currentFighter.FighterID;
            _displayFighter.FighterFaction = _currentFighter.FighterFaction;
            _displayFighter.FighterName = _currentFighter.FighterName;
            _displayFighter.FighterType = _currentFighter.FighterType;
            _displayFighter.FighterSpecialization = _currentFighter.FighterSpecialization;
            _displayFighter.FighterWargearOptions = _currentFighter.FighterWargearOptions;
            _displayFighter.ImgFile = _currentFighter.ImgFile;


        }

        /// <summary>
        /// Creates a blank character to work with.
        /// </summary>
        private void ResetDisplayFighter()
        {
            _displayFighter = new Fighter();
            _displayFighter.FighterFaction = "";
            _displayFighter.FighterName = "";
            _displayFighter.FighterType = "";
            _displayFighter.FighterSpecialization = Fighter.Specializations.NONE;
            _displayFighter.ImgFile = "";

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
            CurrentRoster.SelectedFighters = new List<Fighter>(CurrentRoster.SelectedFighters.OrderBy(c => c.TotalCost));
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
