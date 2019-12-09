using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    /// <summary>
    /// I was provided the following tutorial by PJ to help with this section: 
    /// https://www.youtube.com/watch?v=69WBy4MHYUw
    /// </summary>
    public class DataServiceMongo : FighterRepository
    {
        #region FIELDS
        private string _connectionString;
        private IMongoDatabase _mongoDatabase;   
        private MongoClient _client;
        #endregion

        #region PROPERTIES
        public IMongoDatabase MongoDatabase
        {
            get { return _mongoDatabase; }
            set { _mongoDatabase = value; }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataServiceMongo(string database)
        {
            _connectionString = DataConfig.DataPathMongo;
            _client = new MongoClient(_connectionString);
            _mongoDatabase = _client.GetDatabase(database); 
        }
        #endregion

        #region METHODS
        
        public void Add(FighterList roster)
        {
            throw new NotImplementedException();
        }

        public void CreateRoster(FighterList fighterList)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRoster(int id)
        {
            throw new NotImplementedException();
        }

        public List<FighterList> GetAll()
        {
            //Temp: 
            string table = "";

            try
            {
                var collection = MongoDatabase.GetCollection<FighterList>(table);
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FighterList GetById(int id)
        {
            throw new NotImplementedException();
        }

        public FighterList GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FighterList> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(FighterList roster)
        {
            throw new NotImplementedException();
        }

        public void UpdateRoster(FighterList fighterList)
        {
            throw new NotImplementedException();
        }


        #endregion
    }

}
