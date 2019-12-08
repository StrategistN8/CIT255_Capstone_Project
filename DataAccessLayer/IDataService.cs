using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    interface IDataService
    {
        // Retrieve all data:
        IEnumerable<FighterList> ReadAll();
        
        //Write all data: 
        void WriteAll(IEnumerable<FighterList> roster);


    }
}
