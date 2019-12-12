using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    public class FighterList : ObservableObject
    {
        #region FIELDS       
        private string _listName;
        private string _listFaction;
        private int _listID;
        private int _numberOfSpecialists;
        private int _currentPoints;
        private int _maxPoints;
        private List<Fighter> _availableFighters;
        private List<Fighter> _selectedFighters;
        

       

        #endregion

        #region PROPERTIES
        public string ListName
        {
            get { return _listName; }
            set { _listName = value; }
        }
        public string ListFaction
        {
            get { return _listFaction; }
            set { _listFaction = value; }
        }
        public int ListID
        {
            get { return _listID; }
            set { _listID = value; }
        }
        public int NumberOfSpecialists
        {
            get { return _numberOfSpecialists; }
            set { _numberOfSpecialists = value; }
        }
        public int CurrentPoints
        {
            get { return _currentPoints; }
            set
            {
                _currentPoints = value;
                OnPropertyChanged(nameof(CurrentPoints));
            }
        }
        public int MaxPoints
        {
            get { return _maxPoints; }
            set { _maxPoints = value; }
        }
        public List<Fighter> AvailableFighters
        {
            get { return _availableFighters; }
            set
            {
                _availableFighters = value;
                OnPropertyChanged(nameof(CurrentPoints));
            }
        }
        public List<Fighter> SelectedFighters
        {
            get { return _selectedFighters; }
            set
            {
                _selectedFighters = value;
                OnPropertyChanged(nameof(CurrentPoints));
            }
        }

        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        /// <summary>
        /// Helper Method that determines the total points value of the list.
        /// </summary>
        private void CalculateListPoints()
        {
            CurrentPoints = 0;

            foreach (Fighter fighter in SelectedFighters)
            {
                CurrentPoints += fighter.FighterTotalCost;
            }
        }

        /// <summary>
        /// Method that calculates the total point value of the list.
        /// </summary>
        /// <returns></returns>
        public int GetListPoints()
        {
            CalculateListPoints();
            return CurrentPoints;
        }

        #endregion
        
    }
}