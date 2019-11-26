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
        private string _itemName;

       


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
        public string ItemDescription
        {
            get { return _itemDescription; }
            set { _itemDescription = value; }
        }
        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }
        #endregion

        #region CONSTRUCTOR

        public FighterWargear(int id, int cost, string name, string description)
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
