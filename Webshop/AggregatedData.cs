using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop
{
    class AggregatedData
    {
        // We will use dapper in this class for the sake of variation

        private static string dbHost = "newtonwebshop.database.windows.net";
        private static string dbName = "webshop";
        private static string dbUsername = "webshopAdmin";
        private static string dbPassword = "very%secure%password%for%a%database00";

        private static string connString { get => $"Server=tcp:{dbHost},1433;Initial Catalog={dbName};Persist Security Info=False;User ID={dbUsername};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; }

        
    }
}
