using System;
using System.Collections.Generic;
using System.Text;

namespace TinyNotes.DataLayer
{
    public class DbFactory
    {
        public static IDbManager GetInstance(string dbName)
        {
            switch (dbName)
            {
                case "inmemory":
                    return InMemoryManager.GetInstance();
                case "mongo":
                    return MongoDbManager.GetInstance();
                default:
                    throw new Exception("Invalid Database");
            }

        }
    }
}
