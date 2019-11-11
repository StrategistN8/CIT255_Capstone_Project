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
        private string _fighterName;
        private bool _isSpecialist;  
        private Specializations _fighterSpecialization; // Default to NONE for most fighters
        private List<FighterWargear> _fighterEquipmentList; // This will list all the items equipped to the fighter.
        private List<FighterMeleeWeapons> _fighterMeleeWeaponsOptions; 
        private List<FighterRangedWeapons> _fighterRangedWeaponOptions;
        private List<FighterWargear> _fighterWargearOptions;
        private List<Specializations> _fighterSpecializationOptions;
        #endregion

        #region PROPERTIES
        public int FighterID
        {
            get { return _fighterID; }
            set { _fighterID = value; }
        }
        public string FighterName
        {
            get { return _fighterName; }
            set { _fighterName = value; }
        }
        public bool IsSpecialist
        {
            get { return _isSpecialist; }
            set { _isSpecialist = value; }
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

        }

        #endregion

        #region METHODS

        #endregion

    }
}
