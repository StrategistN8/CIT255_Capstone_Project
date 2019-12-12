using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;
using CIT255_KT_list_builder.DataAccessLayer;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    class TeamRosterRepository : IRepository, IDisposable
    {

        #region FIELDS
        private IDataService _dataService; 
        private List<FighterList> _fighterRosters;
        #endregion

        #region PROPERTIES
        public IDataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }
        public List<FighterList> FighterLists
        {
            get { return _fighterRosters; }
            set { _fighterRosters = value; }
        }
        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default constructor
        /// </summary>
        public TeamRosterRepository()
        {
            _dataService = SetDataService();
            try
            {
                _fighterRosters = _dataService.ReadAll() as List<FighterList>;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Establishes the correct data service.
        /// </summary>
        /// <returns></returns>
        private IDataService SetDataService()
        {
            switch (DataConfig.dataType)
            {
                //case DataType.SEED:
                //    break;
                //case DataType.XML:
                //    break;
                case DataType.JSON:
                    return new DataServiceJSON();
                case DataType.BSON:
                    return new DataServiceMongo(DataConfig.MongoDBName);
                //case DataType.SQL:
                //    break;
                default:
                    throw new Exception();
            }

        }

        /// <summary>
        /// Reads data from persistence and creates list of army rosters.
        /// <returns></returns>
        public List<FighterList> GetAll()
        {
            return _fighterRosters;
        }

        /// <summary>
        /// Reads data from persistance based on id number.
        /// </summary>
        /// <returns></returns>
        public FighterList GetByID(int id)
        {
            return _fighterRosters.FirstOrDefault(c => c.ListID == id);    
        }
        
        /// <summary>
        /// Adds a new roster to the list.
        /// </summary>
        /// <param name="fighterList"></param>
        public void CreateRoster(FighterList fighterList)
        {
            try
            {
                fighterList.ListID = NextID();
                _fighterRosters.Add(fighterList);
                _dataService.WriteAll(_fighterRosters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates a roster by deleting existing one and replacing it with current values.
        /// </summary>
        /// <param name="fighterList"></param>
        public void UpdateRoster(FighterList fighterList)
        {
            try
            {
                _fighterRosters.Remove(_fighterRosters.FirstOrDefault(c => c.ListID == fighterList.ListID));
                _fighterRosters.Add(fighterList);
                _fighterRosters.OrderByDescending(c => c.ListID);
                _dataService.WriteAll(_fighterRosters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Removes a roster from the list.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteRoster(int id)
        {
            try
            {
                _fighterRosters.Remove(_fighterRosters.FirstOrDefault(c => c.ListID == id));
                _dataService.WriteAll(_fighterRosters);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region HELPER METHODS

        /// <summary>
        /// Helper method needed to close the access channel to the persistance.
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Helper method that grabs the next interger value for the id and returns the value.
        /// </summary>
        /// <returns></returns>
        private int NextID()
        {
            return ++_fighterRosters.OrderByDescending(c => c.ListID).First().ListID;

        }

        #endregion
    }
}
