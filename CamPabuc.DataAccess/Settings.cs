using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CamPabuc.DataAccess
{
    public class Settings
    {
        private static Settings instance;
        private Settings()
        {
        }

        public static Settings Instance
        {
            get
            {
                instance ??= new Settings();
                return instance;
            }
        }

        public int ID { get; set; }
        public int BarcodeWidth { get; set; }
        public int BarcodeHeight { get; set; }
        public string ChildSizeRange { get; set; }
        public string WomenSizeRange { get; set; }
        public string MenSizeRange { get; set; }
        public string DoubleQtySizeList { get; set; }

        public static void SyncSettings()
        {
            instance = DbExecutor.GetById<Settings>("AppSettings", 1);
        }
        public static void UpdateSettings()
        {
            DbExecutor.Update("AppSettings", instance);
        }

        public static void CheckAndInitializeDb()
        {
            string appDirectory = Directory.GetCurrentDirectory();
            string dbDirectory = Path.Join(appDirectory, "Data");
            string dbPath = Path.Join(dbDirectory, "campabuc.db");

            if (!Directory.Exists(dbDirectory))
            {
                Directory.CreateDirectory(dbDirectory);
            }

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
                SeedInitialData();
            }

        }

        private static void SeedInitialData()
        {
            using Stream s = typeof(Settings).Assembly.GetManifestResourceStream("CamPabuc.DataAccess.campabuc.db.sql");
            using StreamReader sr = new StreamReader(s);

            DbExecutor.Execute(sr.ReadToEnd());
        }
    }
}

