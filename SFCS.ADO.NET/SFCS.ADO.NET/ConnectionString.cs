using System;
using System.Collections.Generic;
using System.Text;

namespace SFCS.ADO.NET
{
    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Server=PC-SPB-546\MSSQLSERVER01;Database=testing;Trusted_Connection=true;TrustServerCertificate=True";
    }
}
