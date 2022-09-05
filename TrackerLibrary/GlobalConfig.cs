using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {

       public const string PrizeFile = "PrizeModel.csv";
       public const string PeopleFile = "PersonModel.csv";
        public const string TeamFile = "TeamModel.csv";
        public const string TournamentFile = "TournamentModel.csv";
        public const string MatchupFile = "MatchupModel.csv";
        public const string MatchupEntriesFile = "MatchupEntries.csv";
        public static  IDataConnection  Connections { get; private set; } 
        public static void InitailizeConnections(DatabaseType db)
        {
            if (db==DatabaseType.sql)
            {
                MySqlConnector MySqlcon = new MySqlConnector();
                Connections = MySqlcon;
            }
            if (db==DatabaseType.textFile)
            {
                TextFileConnection text = new TextFileConnection();
                Connections = text;
            }
            
        }

        public static string CnnString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
