using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLITEDemo
{
    public static class Constants
    {
        public const string DBFileName = "SQLite.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {                
                return Path.Combine(FileSystem.AppDataDirectory, DBFileName);
            }
        }
    }
}
