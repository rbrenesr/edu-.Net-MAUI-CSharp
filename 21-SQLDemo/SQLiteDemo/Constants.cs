using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo
{
    public class Constants
    {
       public const string BDFileName = "SQLiteDemo.db3";

        public const SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DataBasePath {
            get {
                return Path.Combine(FileSystem.AppDataDirectory, BDFileName);
            }
        }
    }
}
