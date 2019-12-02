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
        IEnumerable<Fighter> GetFighters();
        void WriteAll(IEnumerable<Fighter> fighters);


    }
}
