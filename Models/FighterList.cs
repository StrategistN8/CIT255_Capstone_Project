using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    public class FighterList 
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
            set { _currentPoints = value; }
        }
        public int MaxPoints
        {
            get { return _maxPoints; }
            set { _maxPoints = value; }
        }
        public List<Fighter> AvailableFighters
        {
            get { return _availableFighters; }
            set { _availableFighters = value; }
        }
        public List<Fighter> SelectedFighters
        {
            get { return _selectedFighters; }
            set { _selectedFighters = value; }
        }

        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion
        
    }
}