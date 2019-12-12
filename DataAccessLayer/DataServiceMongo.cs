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
    public class DataServiceMongo : IDataService
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

        public IEnumerable<FighterList> ReadAll()
        {
            try
            {
                var collection = MongoDatabase.GetCollection<FighterList>("FighterLists");
                return collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void WriteAll(IEnumerable<FighterList> roster)
        {
            var collection = MongoDatabase.GetCollection<FighterList>("FighterLists");
            foreach (FighterList list in roster)
            {
                collection.InsertOne(list);
            }
        }
        #endregion

        #region METHODS


        #endregion
    }

}
