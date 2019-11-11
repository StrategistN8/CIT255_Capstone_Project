﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    class FighterList 
    {
        #region FIELDS       
        private int _listID;
        private int _numberOfSpecialists;
        readonly int _maxNumberOfSpecialists = 4; // Game rules do not allow for more than 4 specialists in a list.
        private int _currentPoints;
        private int _maxPoints;
        private List<Fighter> _fighters;
        #endregion

        #region PROPERTIES
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

        public List<Fighter> Fighters
        {
            get { return _fighters; }
            set { _fighters = value; }
        }

        #endregion

        #region CONSTRUCTOR

        #endregion

        #region METHODS

        #endregion


    }
}