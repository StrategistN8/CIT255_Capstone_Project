using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    public class Fighter
    {
        #region ENUMS
       public enum Specializations
        {
            NONE,
            LEADER,
            COMBAT,
            COMMS,
            DEMOLITIONS,
            HEAVY,
            MEDIC,
            SCOUT,
            SNIPER,
            VETERAN,
            ZEALOT

        }

        #endregion

        #region FIELDS

        private int _fighterID;
        private int _limit;
        private int _fighterCost;
        private int _totalCost;

        private string _fighterName;
        private string _fighterType;
        private string _fighterFaction;
        private string _imgFile;

        private bool _isSpecialist;
        private bool _isLimited;
              

        private Specializations _fighterSpecialization; // Default to NONE for most fighters
        private List<FighterWargear> _fighterEquipmentList; // This will list all the items equipped to the fighter.
        private List<FighterMeleeWeapons> _fighterMeleeWeaponsOptions; 
        private List<FighterRangedWeapons> _fighterRangedWeaponOptions;
        private List<FighterWargear> _fighterWargearOptions;
        private List<Specializations> _fighterSpecializationOptions;
        #endregion

        #region PROPERTIES
        public int Limit
        {
            get { return _limit; }
            set { _limit = value; }
        }
        public int FighterID
        {
            get { return _fighterID; }
            set { _fighterID = value; }
        }
        public int FighterCost
        {
            get { return _fighterCost; }
            set { _fighterCost = value; }
        }
        public int TotalCost
        {
            get { return _totalCost; }
            set { _totalCost = value; }
        }
        public string FighterName
        {
            get { return _fighterName; }
            set { _fighterName = value; }
        }
        public string FighterType
        {
            get { return _fighterType; }
            set { _fighterType = value; }
        }
        public string FighterFaction
        {
            get { return _fighterFaction; }
            set { _fighterFaction = value; }
        }
        public string ImgFile
        {
            get { return _imgFile; }
            set { _imgFile = value; }
        }
        public bool IsSpecialist
        {
            get { return _isSpecialist; }
            set { _isSpecialist = value; }
        }
        public bool IsLimited
        {
            get { return _isLimited; }
            set { _isLimited = value; }
        }
        public Specializations FighterSpecialization
        {
            get { return _fighterSpecialization; }
            set { _fighterSpecialization = value; }
        }
        public List<FighterWargear> FighterEquipmentList
        {
            get { return _fighterEquipmentList; }
            set { _fighterEquipmentList = value; }
        }
        public List<FighterMeleeWeapons> FighterMeleeWeaponOptions
        {
            get { return _fighterMeleeWeaponsOptions; }
            set { _fighterMeleeWeaponsOptions = value; }
        }
        public List<FighterRangedWeapons> FighterRangedWeaponOptions
        {
            get { return _fighterRangedWeaponOptions; }
            set { _fighterRangedWeaponOptions = value; }
        }
        public List<FighterWargear> FighterWargearOptions
        {
            get { return _fighterWargearOptions; }
            set { _fighterWargearOptions = value; }
        }
        public List<Specializations> FighterSpecializationOptions
        {
            get { return _fighterSpecializationOptions; }
            set { _fighterSpecializationOptions = value; }
        }


        #endregion

        #region CONSTRUCTOR

        public Fighter()
        {
            FighterEquipmentList = new List<FighterWargear>();
            FighterRangedWeaponOptions = new List<FighterRangedWeapons>();
            FighterMeleeWeaponOptions = new List<FighterMeleeWeapons>();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Helper method that calculates the total cost of the fighter based on their equipped gear.
        /// </summary>
        /// <param name="fighter"></param>
        /// <returns></returns>
        public int CalculateTotalFighterCost(Fighter fighter)
        {
            fighter.TotalCost = fighter.FighterCost;

            foreach (FighterWargear wargear in fighter.FighterEquipmentList)
            {
                fighter.TotalCost += wargear.ItemCost;
            }

            return fighter.TotalCost; 

        }
        #endregion

    }
}
