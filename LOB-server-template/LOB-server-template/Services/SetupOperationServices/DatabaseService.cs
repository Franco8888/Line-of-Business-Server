using LOB_server_template.Models;
using LOB_server_template.Services.SetupOperationServices;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// This Service connects to the DB and hold the collection names
namespace LOB_server_template.Services
{
    public interface IDataBaseService
    {
        IMongoDatabase Database { get; set; }

        IMongoCollection<UserAccount> UserAccount { get; set; }

        IMongoCollection<Admin> AdminCollection { get; set; }

        IMongoCollection<Customer> CustomerCollection { get; set; }

        IMongoCollection<Product> ProductCollection { get; set; }


    }

    public class DatabaseService: IDataBaseService
    {
        public IMongoDatabase Database { get; set; }

        public IMongoCollection<UserAccount> UserAccount { get; set; }

        public IMongoCollection<Admin> AdminCollection { get; set; }

        public IMongoCollection<Customer> CustomerCollection { get; set; }

        public IMongoCollection<Product> ProductCollection { get; set; }

        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //
        // CTOR
        // ------------------------------------------------------------------------------------------------------------------------------------------------------------ //

        public DatabaseService(ISettingsService settings)
        {
            /*var client = new MongoClient(settings.MongoDBConnectionString);

            Database = client.GetDatabase(settings.DataBaseName);

            // Get collections
            UserAccount = Database.GetCollection<UserAccount>("userAccount");
            AdminCollection = Database.GetCollection<Admin>("admin");
            CustomerCollection = Database.GetCollection<Customer>("customer");
            ProductCollection = Database.GetCollection<Product>("product");*/

        }
    }
}
