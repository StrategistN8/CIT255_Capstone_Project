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
    class DataServiceJSON : IDataService
    {
        /// <summary>
        /// Reads all data from a JSON file and loads the rosters.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FighterList> GetAll()
        {
            List<FighterList> rosters;

            try
            {
                using (StreamReader sr = new StreamReader(DataConfig.DataPathJson))
                {
                    string jSONString = sr.ReadToEnd();

                    rosters = JsonConvert.DeserializeObject<List<FighterList>>(jSONString);
                }
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
    }
}
