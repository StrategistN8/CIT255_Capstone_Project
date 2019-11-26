using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models; // Not sure if this should be here. 

namespace CIT255_KT_list_builder.DataAccessLayer
{
    interface IRepository
    {


        #region FIGHTER CRUD METHODS

      
        /// <summary>
        /// Retrieves a fighter based on their id.
        /// </summary>
        /// <param name="id"></param>
        void GetFighterById(int id);

        /// <summary>
        /// Updates the fighter data 
        /// </summary>
        /// <param name="fighter"></param>
        void UpdateFighterData(Fighter fighter);

        /// <summary>
        /// Removes a fighter from the list
        /// </summary>
        /// <param name="fighter"></param>
        void DeleteFighter(Fighter fighter, List<Fighter> roster);

        /// <summary>
        /// Adds a fighter to the list.
        /// </summary>
        /// <param name="fighter"></param>
        /// <param name=""></param>
        /// <returns></returns>
        Fighter AddFighter(Fighter fighter, List<Fighter> roster);



        #endregion

        #region LIST CRUD METHODS

        /// <summary>
        /// Retrieves all fighter data.
        /// </summary>
        /// <returns></returns>
        List<Fighter> GetListOfFighters();
        
        /// <summary>
        /// Gets all of the fighters available by faction.
        /// </summary>
        /// <param name="faction"></param>
        /// <returns></returns>
        List<Fighter> GetListOfFightersByFaction(String faction);
        
        /// <summary>
        /// Gets a list of fighters that match a given cost.
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        List<Fighter> GetListOfFightersByCost(int cost);
      
        /// <summary>
        /// Gets a list of fighters within a price range.
        /// </summary>
        /// <param name="cost"></param>
        /// <returns></returns>
        List<Fighter> GetListOfFightersByRange(int minCost, int maxCost);

       
        #endregion



    }


}
