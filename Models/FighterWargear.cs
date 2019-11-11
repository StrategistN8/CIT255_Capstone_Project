using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIT255_KT_list_builder.Models
{
   public class FighterWargear 
    {
        #region ENUMS


        #endregion

        #region FIELDS

        private int _itemID;
        private int _itemCost;
        private string _itemDescription;

        #endregion

        #region PROPERTIES
        public int ItemID
        {
            get { return _itemID; }
            set { _itemID = value; }
        }
        public int ItemCost
        {
            get { return _itemCost; }
            set { _itemCost = value; }
        }
        public string itemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }

        #endregion

        #region CONSTRUCTOR
        #endregion

        #region METHODS

        #endregion
    }
}
