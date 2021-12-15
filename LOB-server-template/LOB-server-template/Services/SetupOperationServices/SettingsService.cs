using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

// This service fetches data from our configuration file
namespace LOB_server_template.Services.SetupOperationServices
{
    public interface ISettingsService
    {
        string MongoDBConnectionString { get => ConfigurationManager.AppSettings["DBConnectionString"]; }

        string DataBaseName { get => ConfigurationManager.AppSettings["DBName"]; }

        public string AuthKey { get => ConfigurationManager.AppSettings["AuthKey"]; }

    }

    public class SettingsService: ISettingsService
    {
        public string MongoDBConnectionString { get => ConfigurationManager.AppSettings["DBConnectionString"]; }

        public string DataBaseName { get => ConfigurationManager.AppSettings["DBName"]; }

        public string AuthKey { get => ConfigurationManager.AppSettings["AuthKey"]; }

    }
}
