using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    // todo:  Heavy refactoring to remove unused code and do a general cleanup. This class is especially bloated...
    public class Fighter : ObservableObject
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

        // Int variables:
        private int _fighterID;
        private int _limit;
        private int _fighterCost;
        private int _fighterTotalCost;

        // String variables
        private string _fighterName;
        private string _fighterType;
        private string _fighterFaction;
        private string _imgFile;
        private string _imgSource;      

        // Bool variables
        private bool _isSpecialist;
        private bool _isLimited;

        // Misc. 
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
            set
            {
                _fighterCost = value;
                CalculateTotalFighterCost();
                OnPropertyChanged(nameof(FighterCost));
            }
        }
        public int FighterTotalCost
        {
            get { return _fighterTotalCost; }
            set
            {
                _fighterTotalCost = value;
                OnPropertyChanged(nameof(FighterTotalCost));
            }
        }
        public string FighterName
        {
            get { return _fighterName; }
            set
            {
                _fighterName = value;
                OnPropertyChanged(nameof(FighterName));
            }
        }
        public string FighterType
        {
            get { return _fighterType; }
            set
            {
                _fighterType = value;
                OnPropertyChanged(nameof(FighterType));
            }
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
        public string ImgSource
        {
            get { return _imgSource; }
            set { _imgSource = value; }
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
            set
            {
                _fighterEquipmentList = value;
                CalculateTotalFighterCost();
            }
        }
        public List<FighterMeleeWeapons> FighterMeleeWeaponOptions
        {
            get { return _fighterMeleeWeaponsOptions; }
            set
            {
                _fighterMeleeWeaponsOptions = value;
                CalculateTotalFighterCost();
                OnPropertyChanged(nameof(FighterMeleeWeaponOptions));
            }
        }
        public List<FighterRangedWeapons> FighterRangedWeaponOptions
        {
            get { return _fighterRangedWeaponOptions; }
            set
            {
                _fighterRangedWeaponOptions = value;
                CalculateTotalFighterCost();
                OnPropertyChanged(nameof(FighterRangedWeaponOptions));
            }
        }
        public List<FighterWargear> FighterWargearOptions
        {
            get { return _fighterWargearOptions; }
            set
            {
                _fighterWargearOptions = value;
                CalculateTotalFighterCost();
                OnPropertyChanged(nameof(FighterWargearOptions));
            }
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
            
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Method that takes all information from the wargear lists and compiles them into a single equipment list.
        /// </summary>
        public void CompileFighterInventory()
        {
            if (FighterEquipmentList != null)
            {
                FighterEquipmentList.Clear();

                if (FighterRangedWeaponOptions != null)
                {
                    foreach (FighterRangedWeapons rangedWeapon in FighterRangedWeaponOptions)
                    {
                        FighterEquipmentList.Add(rangedWeapon as FighterWargear);
                    }
                }

                if (FighterMeleeWeaponOptions != null)
                {
                    foreach (FighterMeleeWeapons meleeWeapon in FighterMeleeWeaponOptions)
                    {
                        FighterEquipmentList.Add(meleeWeapon as FighterWargear);
                    }
                }
                if (FighterWargearOptions != null)
                {
                    foreach (FighterWargear wargear in FighterWargearOptions)
                    {
                        FighterEquipmentList.Add(wargear);
                    }
                }
            }
           

            CalculateTotalFighterCost();

        }

        /// <summary>
        /// Helper method that calculates the total cost of the fighter based on their equipped gear.
        /// </summary>
        /// <param name="fighter"></param>
        /// <returns></returns>
        private void CalculateTotalFighterCost()
        {
            FighterTotalCost = FighterCost;

            if (FighterEquipmentList != null)
            {
                foreach (FighterWargear wargear in FighterEquipmentList)
                {
                    FighterTotalCost += wargear.ItemCost;
                }
            }
            
        }
        
        /// <summary>
        /// Helper method used to create a list of Specializations in string form.  Used to 
        /// populate a generic fighter with all enum options. To be replaced with a stored enum eventually.
        /// </summary>
        /// <returns></returns>
        public List<string> GenerateListOfSpecializationString()
        {
            List<string> templist = Enum.GetNames(typeof(Specializations)).ToList();

            return templist;
        }
        
        /// <summary>
        /// A (rather inefficent) helper method to create a list of all specializations.
        /// </summary>
        /// <returns></returns>
        public List<Specializations> GenerateListofSpecializations()
        {
            List<Specializations> enumList = new List<Specializations>();

            List<string> templist = Enum.GetNames(typeof(Specializations)).ToList();

            foreach (string value in templist)
            {
                Enum.TryParse(value, out Specializations specialization);
                enumList.Add(specialization);
            }

            return enumList;
        }
        #endregion


    }
}
