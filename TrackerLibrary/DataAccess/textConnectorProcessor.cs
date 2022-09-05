using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess.TextConnector
{
    public static class textConnectorProcessor
    {
        //-------------------------------methods for generating file path and loding files ----------------------------
        /// <summary>
        /// Generats file path it is extention methode use for save data in text file 
        /// common for all string file name in clases which use textConnector 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{ConfigurationManager.AppSettings["filePath"]}\\{fileName}";
        }

        public static List<String> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }
            return File.ReadAllLines(file).ToList();
        }



        ////-----------------------------------------methods for converting list of strings into models --------------------------
        /// <summary>
        /// convert List of strings in text file into prize Model
        /// reference - create prize form
        /// </summary>
        /// <param name="Lines">list of strings in text file</param>
        /// <returns></returns>
        public static List<PrizeModel> ConvertToPrizeModel(this List<string> Lines)
        {
            List<PrizeModel> output = new List<PrizeModel>();
            foreach (string Line in Lines)
            {
                string[] cols = Line.Split(',');
                PrizeModel p = new PrizeModel();
                p.id = int.Parse(cols[0]);
                p.PlaceName = cols[2];
                p.PlaceNumber = int.Parse(cols[1]);
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);

            }
            return output;

        }
        

        public static List<PersonModel> ConvertToPersonModel(this List<string> Lines)
        {
            List<PersonModel> output = new List<PersonModel>();
            foreach (string line in Lines)
            {
                string[] cols = line.Split(',');
                PersonModel p = new PersonModel();
                p.id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.LastName = cols[2];
                p.CellPhoneNumber = cols[3];
                p.EmailAddress = cols[4];
                output.Add(p);
            }
            return output;
        }

        public static List<TeamModel> ConvertToTeamModel(this List<string> Lines) {

            List<TeamModel> output = new List<TeamModel>();
            List<PersonModel> people = GlobalConfig.PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
            foreach (string line in Lines)
            {
                string[] col = line.Split(',');
                TeamModel t = new TeamModel();
                t.id = int.Parse(col[0]);
                t.TeamName = col[1];
                string[] personId= col[2].Split('|');
                foreach (string id in personId)
                {
                    t.TeamMembers.Add(people.Where(x => x.id == int.Parse(id)).First());

                }
                output.Add(t);
            }
            return output;
        }


        public static List<TournamentModel> ConvertToTournamentModel(this List<string> Lines)
        {
            List<TournamentModel> output = new List<TournamentModel>();
            List<TeamModel> teams = GlobalConfig.TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();
            List<PrizeModel> Prizes = GlobalConfig.PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModel();
            List<MatchupModel> matchup = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();
            foreach (string l in Lines)
            {
                string[] col = l.Split(",");
                TournamentModel tm = new TournamentModel();
                tm.id = int.Parse(col[0]);
                tm.TournamentName = col[1];
                tm.EntryFee = decimal.Parse(col[2]);
                string[] teamid = col[3].Split('|');
                foreach (string id in teamid)
                {
                    tm.EnteredTeams.Add(teams.Where(x => x.id == int.Parse(id)).First());
                }
                if (col[4].Length>0)
                {

                    string[] prizesid = col[4].Split('|');

                    foreach (string id in prizesid)
                    {
                        tm.Prizes.Add(Prizes.Where(x => x.id == int.Parse(id)).First());
                    } 
                }
                
                string[] rounds = col[5].Split('|');
                foreach (string round in rounds)
                {
                    string[] mtchup = round.Split('^');
                    List<MatchupModel> m = new List<MatchupModel>();
                    foreach (string id in mtchup)
                    {
                        m.Add(matchup.Where(x => x.id == int.Parse(id)).First());
                    }
                    tm.Rounds.Add(m);
                }
                output.Add(tm);
            }
            return output;

        }



        public static List<MatchupModel> ConvertToMatchupModel(this List<string> Lines)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            foreach (string line in Lines)
            {
                string[] cols = line.Split(',');
                MatchupModel p = new MatchupModel();
                p.id = int.Parse(cols[0]);
                p.Entries = CnvertStringtoMatchupEntryModel(cols[1]);
                if (cols[2].Length == 0)
                    p.winner = null;
                else
                     p.winner = LookupByTeamId(int.Parse(cols[2]));
                p.MatchupRound =int.Parse( cols[3]);
                output.Add(p);
            }
            return output;
        }

        private static TeamModel LookupByTeamId(int v)
        {
            List<string> Team = GlobalConfig.TeamFile.FullFilePath().LoadFile();
            foreach (string team in Team)
            {
                string[] col = team.Split(',');
                if (col[0] == v.ToString())
                {
                    List<string> l = new List<string>();
                    l.Add(team);
                    return l.ConvertToTeamModel().First();
                }

            }
            return null;
        }

        public static List<MatchupEntryModel> ConvertToMatchupEntryModel(this List<string> Line)
        {
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            foreach (string line in Line)
            {
                string[] cols = line.Split(',');
                MatchupEntryModel p = new MatchupEntryModel();
                p.id = int.Parse(cols[0]);
                if (cols[1].Length == 0)
                    p.TeamCompeting = null;
                else
                     p.TeamCompeting = LookupByTeamId(int.Parse(cols[1]));
                p.score = double.Parse(cols[2]);
                int perentid = 0;
                if (int.TryParse(cols[3], out perentid))
                    p.PerentMatchup =LookupMtchupByID(perentid);
                else
                    p.PerentMatchup = null;
                output.Add(p);
            }
            return output;
        }

        private static MatchupModel LookupMtchupByID(int perentid)
        {
            List<string> Matchup = GlobalConfig.MatchupFile.FullFilePath().LoadFile();

            foreach (string m in Matchup)
            {
                string[] col = m.Split(',');
                if (col[0] == perentid.ToString())
                {
                    List<string> l = new List<string>();
                    l.Add(m);
                    return l.ConvertToMatchupModel().First();
                }

            }
            return null;
        }

        private static List<MatchupEntryModel> CnvertStringtoMatchupEntryModel(string v)
        {
            string []idstring= v.Split('|');
            List<MatchupEntryModel> output = new List<MatchupEntryModel>();
            List<string> entries = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile();
            List<string> MatchinEntries = new List<string>();
            foreach (string id in idstring)
            {
                foreach (string entry in entries)
                {
                    string[] cols = entry.Split(',');
                    if (cols[0] == id)
                    {
                        MatchinEntries.Add(entry);
                    }

                }
                output = MatchinEntries.ConvertToMatchupEntryModel();

            }
            return output;
        }

        ///--------------------------------------------Methods for save data in text file ---------------------------------
        /// <summary>
        /// save  prize model into text file
        /// </summary>
        /// <param name="model"></param>
        /// <param name="fileName"></param>
        public static void saveToPrizeFile(this List<PrizeModel> model, string fileName)
        {
            List<string> line = new List<string>();
            foreach (PrizeModel p in model)
            {
                line.Add($"{p.id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }
            File.WriteAllLines(fileName.FullFilePath(), line);

        }

        public static void SaveToPersonModelFile(this List<PersonModel> person, string fileName)
        {
            List<string> line = new List<string>();
            foreach (PersonModel p in person)
            {
                line.Add($"{p.id},{p.FirstName},{p.LastName},{p.CellPhoneNumber},{p.EmailAddress}");
            }
            File.WriteAllLines(fileName.FullFilePath(), line);
        }

        public static void saveToCreateTeamsFile(this List<TeamModel> teams, string fileName)
        {
            List<string> line = new List<string>();
            foreach (TeamModel t in teams)
            {
                line.Add($"{t.id},{t.TeamName},{ConvertPeopelListToString(t.TeamMembers)}");

            }

            File.WriteAllLines(fileName.FullFilePath(), line);
        }

        public static void saveToCreateTournamentFile(this List<TournamentModel> tournament, string fileName)
        {
            List<string> line = new List<string>();
            foreach (TournamentModel t in tournament)
            {
                line.Add($"{t.id},{t.TournamentName},{t.EntryFee},{ConvertTeamListTostring(t.EnteredTeams)},{ConvertPrizeListToString(t.Prizes)},{ConvertRoundListToString(t.Rounds)}");
            }

            File.WriteAllLines(fileName.FullFilePath(), line);
        }


        public static void SaveRoundsToFile(this TournamentModel model)
        {
            foreach (List<MatchupModel> round in model.Rounds)
            {
                foreach (MatchupModel matchup in round)
                {
                    matchup.SavetoMatchupFile();
                }
            }
        }

        public static void SavetoMatchupFile(this MatchupModel m)
        {
            //       public int id { get; set; }
            //public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
            //public TeamModel winner { get; set; }
            //public int MatchupRound { get; set; }
            //id,entries(id|id|id),winner,matchur
            List<MatchupModel> matchup = GlobalConfig.MatchupFile.FullFilePath().LoadFile().ConvertToMatchupModel();

            int currentId = matchup.Count > 0 ? matchup.OrderByDescending(x => x.id).First().id + 1 : 1;
            m.id= currentId;
            matchup.Add(m);
            foreach (MatchupEntryModel entry in m.Entries)
            {
                entry.SaveToEntryFile();
            }
            List<string> line = new List<string>();
            foreach (MatchupModel mt in matchup)
            {
                line.Add($@"{mt.id},{ConvertMatchupEntryListToString(mt.Entries)},{mt.winner},{mt.MatchupRound}");
            }

            File.WriteAllLines(GlobalConfig.MatchupFile.FullFilePath(), line);
        }

        public static void SaveToEntryFile(this MatchupEntryModel e)
        {
            List<MatchupEntryModel> entrys = GlobalConfig.MatchupEntriesFile.FullFilePath().LoadFile().ConvertToMatchupEntryModel();
            int currentId = entrys.Count > 0 ? entrys.OrderByDescending(x => x.id).First().id + 1 : 1;
            e.id = currentId;
            entrys.Add(e);
            List<string> line = new List<string>();
            foreach (MatchupEntryModel m in entrys)
            {
                string perentid = "";
                if (m.PerentMatchup != null)
                    perentid = m.PerentMatchup.id.ToString();
                string teamcompetingid = "";
                if (m.TeamCompeting != null)
                {
                    teamcompetingid = m.TeamCompeting.id.ToString();
                }
                line.Add($"{m.id},{teamcompetingid},{m.score},{perentid}");
            }
            File.WriteAllLines(GlobalConfig.MatchupEntriesFile.FullFilePath(), line);


        }

        private static object ConvertMatchupEntryListToString(List<MatchupEntryModel> entries)
        {
            string output = "";
            if (entries.Count == 0)
            {
                return "";
            }
            foreach (MatchupEntryModel m in entries)
            {
                output += $"{m.id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static string ConvertRoundListToString(List<List<MatchupModel>> rounds)
        {
            string output = "";
            if (rounds.Count == 0)
            {
                return "";
            }
            foreach (List<MatchupModel> p in rounds)
            {
                output += $"{ConvertMatchupModelToString(p)}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static object ConvertMatchupModelToString(List<MatchupModel>m)
        {
            string output = "";
            if (m.Count == 0)
            {
                return "";
            }
            foreach (MatchupModel p in m)
            {
                output += $"{p.id}^";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

        private static object ConvertPrizeListToString(List<PrizeModel> prizes)
        {
            string output = "";
            if (prizes.Count == 0)
            {
                return "";
            }
            foreach (PrizeModel p in prizes)
            {
                output += $"{p.id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    

        private static object ConvertTeamListTostring(List<TeamModel> enteredTeams)
        {
            string output = "";
            if (enteredTeams.Count == 0)
            {
                return "";
            }
            foreach (TeamModel t in enteredTeams)
            {
                output += $"{t.id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }

    

        private static string ConvertPeopelListToString(List<PersonModel> teamMembers)
        {
            string output="";
            if (teamMembers.Count == 0)
            {
                return "";
            }
            foreach (PersonModel p in teamMembers)
            {
                output += $"{p.id}|";
            }
            output = output.Substring(0, output.Length - 1);
            return output;
        }
    }
}


