using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace XamSQLite.Database
{
    public class Constants

    {
        public const string dbName = "Products.db3"; //Declare nom de la BDD

        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;


        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, dbName);
            }
        }

    }
}
