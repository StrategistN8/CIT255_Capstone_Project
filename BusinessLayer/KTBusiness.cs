using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;
using CIT255_KT_list_builder.DataAccessLayer;
using CIT255_KT_list_builder.Data;

namespace CIT255_KT_list_builder.BusinessLayer
{
    public class KTBusiness 
    {
        #region ENUMS

        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES
        public FileIoMessage FileIoStatus { get; set; }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default Constructor: 
        /// </summary>
        public KTBusiness()
        {
            

        }
        #endregion

        #region INTERNAL METHODS

        /// <summary>
        /// Retrives all rosters through the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<FighterList> GetAllRosters()
        {
            List<FighterList> tempRoster = new List<FighterList>();
            FileIoStatus = FileIoMessage.None;

            try
            {
                using (TeamRosterRepository tRR = new TeamRosterRepository())
                {
                    tempRoster = tRR.GetAll() as List<FighterList>;
                };

                if (tempRoster != null)
                {
                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.NoRecordsFound;
                }


            }
            catch (Exception)
            {

                FileIoStatus = FileIoMessage.FileAccessError;
            }

            return tempRoster;
        }

        /// <summary>
        /// Retrives a specific roster using the repository.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private FighterList GetRosterByID(int id)
        {
            FighterList tempRoster = null;
            FileIoStatus = FileIoMessage.None;

            try
            {
                using (TeamRosterRepository tRR = new TeamRosterRepository())
                {
                    tempRoster = tRR.GetByID(id);
                };

                if (tempRoster != null)
                {
                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.NoRecordsFound;
                }


            }
            catch (Exception)
            {

                FileIoStatus = FileIoMessage.FileAccessError;
            }

            return tempRoster;
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Public access method for getting all rosters.
        /// </summary>
        /// <returns></returns>
        public List<FighterList> AllRosters()
        {
            return GetAllRosters() as List<FighterList>;
        }

        /// <summary>
        /// Public access method for getting roster by ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FighterList RosterByID(int id)
        {
            return GetRosterByID(id);
        }

        /// <summary>
        /// Method that adds a roster to persistance through the repository.
        /// </summary>
        /// <param name="fighterList"></param>
        public void AddRosterToPersistance(FighterList newRoster)
        {

            try
            {
                if (newRoster != null)
                {
                    using (TeamRosterRepository tRR = new TeamRosterRepository())
                    {
                        tRR.CreateRoster(newRoster);
                    }

                    FileIoStatus = FileIoMessage.Complete;
                }
            }
            catch (Exception)
            {
                FileIoStatus = FileIoMessage.FileAccessError;
            }
            
        }

        /// <summary>
        /// Removes a roster from persistance.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRosterFromPersistance(int id)
        {
            try
            {
                if (GetRosterByID(id) != null)
                {
                    using (TeamRosterRepository tRR = new TeamRosterRepository())
                    {
                        tRR.DeleteRoster(id);
                    }

                    FileIoStatus = FileIoMessage.Complete;
                    
                }
                else
                {
                    FileIoStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {

                FileIoStatus = FileIoMessage.FileAccessError;
            }
        }
       
        /// <summary>
        /// Update an item in persistance.
        /// </summary>
        /// <param name="updateList"></param>
        public void UpdateRoster(FighterList updateList)
        {
            try
            {
                if (GetRosterByID(updateList.ListID) != null)
                {
                    using (TeamRosterRepository tRR = new TeamRosterRepository())
                    {
                        tRR.UpdateRoster(updateList);
                    }

                    FileIoStatus = FileIoMessage.Complete;
                }
                else
                {
                    FileIoStatus = FileIoMessage.RecordNotFound;
                }
            }
            catch (Exception)
            {

                FileIoStatus = FileIoMessage.FileAccessError;
            }
        }
        
        #endregion
    }
}
