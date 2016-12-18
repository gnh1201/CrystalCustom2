using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalCustoms2.common
{
    class DBUnit
    {
        public static string connectionString = "";

        // init
        public static void init()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            connectionString = @"Data Source=|DataDirectory|\mysettledb.sqlite;Version=3;FailIfMissing=True;Foreign Keys=True;";
        }

        public static SQLiteConnection conn()
        {
            // run init
            init();

            return new SQLiteConnection(connectionString);
        }
    }
}
