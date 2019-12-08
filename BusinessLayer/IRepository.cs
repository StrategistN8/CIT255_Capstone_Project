using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    interface IRepository
    {
        
        /// <summary>
        /// Reads data from persistence and creates list of army rosters.
        /// <returns></returns>
        List<FighterList> GetAll();

        /// <summary>
        /// Reads data from persistance based on id number.
        /// </summary>
        /// <returns></returns>
        FighterList GetByID(int id);

        /// <summary>
        /// Adds a new roster to the list.
        /// </summary>
        /// <param name="fighterList"></param>
        void CreateRoster(FighterList fighterList);

        /// <summary>
        /// Updates a roster by deleting existing one and replacing it with current values.
        /// </summary>
        /// <param name="fighterList"></param>
        void UpdateRoster(FighterList fighterList);

        /// <summary>
        /// Removes a roster from the list.
        /// </summary>
        /// <param name="id"></param>
        void DeleteRoster(int id);

    }


}
