using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentModule
{
    public class MongoDBHelper<T>
        where T : MongoDBEntity
    {
        private static string connectionString = "mongodb://127.0.0.1:27017";
        private static IMongoDatabase database = new MongoClient(connectionString).GetDatabase("ModernDatabases");
        private readonly IMongoCollection<T> items;

        public MongoDBHelper()
        {
            items = database.GetCollection<T>(typeof(T).Name);
        }

        public void Insert(T item)
        {
            items.InsertOne(item);
        }
    }
}
