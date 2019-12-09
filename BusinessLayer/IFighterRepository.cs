using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    interface FighterRepository : IRepository
    {
        IEnumerable<FighterList> ReadAll();
        FighterList GetById(int id);
        void Add(FighterList roster);
        void Update(FighterList roster);
        void Delete(int id);

    }
}
