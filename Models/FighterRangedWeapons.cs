using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
    public class FighterRangedWeapons : FighterWargear
    {
        #region ENUMS


        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTOR
        public FighterRangedWeapons(int id, int cost, string name, string description)
            : base (id, cost, name, description)
        {
            ItemID = id;
            ItemCost = cost;
            ItemDescription = description;
            ItemName = name;
        }
        #endregion

        #region METHODS

        #endregion
    }
}
