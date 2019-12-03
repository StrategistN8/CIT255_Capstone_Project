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
        public IEnumerable<Fighter> GetFighters()
        {
            return null;   
        }

        public void WriteAll(IEnumerable<Fighter> fighters)
        {
            
        }
    }
}
