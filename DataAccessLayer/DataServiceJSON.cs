using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using CIT255_KT_list_builder.Data;
using CIT255_KT_list_builder.DataAccessLayer;
using Newtonsoft;
using Newtonsoft.Json;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.DataAccessLayer 
{
    // todo:  Figure out what the stream reader doesn't like about my access string... 
    class DataServiceJSON : IDataService
    {

        #region FIELDS

        private string _dataPath;
        #endregion

        #region PROPERTIES
        public string DataPath
        {
            get { return _dataPath; }
            set { _dataPath = value; }
        }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DataServiceJSON()
        {
            // DataPath = DataConfig.DataPathJson;
            DataPath = @"\DataAccessLayer\Data\Rosters.json";
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Reads all data from a JSON file and loads the rosters.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FighterList> ReadAll()
        {
            List<FighterList> rosters;

            try
            {
                using (StreamReader streamReader = new StreamReader(DataPath))
                {
                    string jsonString = streamReader.ReadToEnd();
                    rosters = JsonConvert.DeserializeObject<List<FighterList>>(jsonString);
                };

            }
            catch (System.Exception)
            {
                throw;
            }
            return rosters;
        }

        /// <summary>
        /// Writes current data to the JSON data file.
        /// </summary>
        /// <param name="roster"></param>
        public void WriteAll(IEnumerable<FighterList> roster)
        {
            string jSONString = JsonConvert.SerializeObject(roster, Formatting.Indented);

        }
        #endregion
    }
}
