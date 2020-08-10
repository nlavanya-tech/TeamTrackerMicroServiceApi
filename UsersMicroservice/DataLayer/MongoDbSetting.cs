using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsersMicroservice.DataLayer
{
    public class MongoDbSetting
    {
        //creating mongodb connection properties
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
