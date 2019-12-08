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


namespace CIT255_KT_list_builder.ViewModels
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
        private FighterList _currentRoster;
        private Fighter _currentFighter;
        private Fighter _displayFighter;
        private FighterWargear _selectedWargear;
        private ObservableCollection<FighterList> _availableRosters;
        private ObservableCollection<Fighter> _availableFighters;
        private ObservableCollection<FighterWargear> _availableWargear;
        private KTBusiness _ktBusiness;
        private ActiveOperation _currentOperation;    
        #endregion

        #region PROPERTIES
        public FighterList CurrentRoster
        {
            get { return _currentRoster; }
            set { _currentRoster = value; }
        }
        public Fighter CurrentFighter
        {
            get { return _currentFighter; }
            set { _currentFighter = value; }
        }
        public Fighter DisplayFighter
        {
            get { return _displayFighter; }
            set { _displayFighter = value; }
        }
        public FighterWargear SelectedWargear
        {
            get { return _selectedWargear; }
            set { _selectedWargear = value; }
        }
        public ObservableCollection<FighterList> AvailableRosters
        {
            get { return _availableRosters; }
            set { _availableRosters = value; }
        }
        public ObservableCollection<Fighter> AvailableFighters
        {
            get { return _availableFighters; }
            set { _availableFighters = value; }
        }
        public ObservableCollection<FighterWargear> AvailableWargear
        {
            get { return _availableWargear; }
            set { _availableWargear = value; }
        }
        public bool IsEditing { get; set; }
        public bool ShowNewButton { get; set; }
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
        #endregion

        #region COMMANDS
        // List Editing Commands:
        public ICommand SelectList { get; set; }
        public ICommand CreateNewList { get; set; }
        public ICommand DeleteList { get; set; }
        public ICommand SelectFighterFromList { get; set; }
        public ICommand CancelDeleteList { get; set; }
        public ICommand CancelCreateList { get; set; }

        // Fighter Editing Commands:
        public ICommand EditSelectedFighter { get; set; }
        public ICommand DeleteSelectedFighter { get; set; }
        public ICommand AddNewFighterToList { get; set; }
        public ICommand CancelDeleteFighter { get; set; }
        public ICommand CancelEditOrAddFighter { get; set; }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default Constructor: 
        /// </summary>
        public KTViewModel(KTBusiness kTBusiness)
        {
            _ktBusiness = kTBusiness;
            _availableRosters = new ObservableCollection<FighterList>();
            _availableFighters = new ObservableCollection<Fighter>();
            _availableWargear = new ObservableCollection<FighterWargear>();
            UpdateImagePath();

            // Add Icommand to call each related method.

        }
       
        #endregion

        #region METHODS

        /// <summary>
        /// Helper method that sources the image for the view:
        /// </summary>
        private void UpdateImagePath()
        {
            foreach (Fighter fighter in CurrentRoster.SelectedFighters)
            {
                fighter.ImageFilePath = DataConfig.ImagePath + character.ImageFileName;
            }

        }

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
                    //_ktBusiness.Delete()

                    //todo: make sure this works:
                    _currentRoster.SelectedFighters.Remove(CurrentFighter);
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
                //_operationStatus = ActiveOperation.EDIT;
                IsEditing = true;
                ShowNewButton = false;
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
            ShowNewButton = false;
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
            ShowNewButton = true;
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
            ShowNewButton = true;
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
