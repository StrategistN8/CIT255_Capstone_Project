using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT255_KT_list_builder.Models;

namespace CIT255_KT_list_builder.DataAccessLayer
{
    class DataConfig
    {
        #region PROPERTIES

        //public static DataType dataType = DataType.SEED;
        //public static DataType dataType = DataType.XML;
        public static DataType dataType = DataType.JSON;
        //public static DataType dataType = DataType.BSON;
        //public static DataType dataType = DataType.SQL;
        public static string DataPathJson => @"\CIT255_KT_list_builder\DataAccessLayer\Data\Rosters.json";
        public static string DataPathMongo = @"mongodb+srv://lyons41:CIT255DEMO@nmcprojectdatabase-gxp1k.azure.mongodb.net/test?retryWrites=true&w=majority";
        public static string ImagePath => @"\CIT255_KT_list_builder\Images\";

        #endregion


    }
}
