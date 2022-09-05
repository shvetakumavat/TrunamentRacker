using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess
{
    public class MySqlConnector : IDataConnection
    {
        const string db = "Tournaments";
        public PersonModel CreatePersone(PersonModel model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("_FirstName", model.FirstName);
                p.Add("_LastName", model.LastName);
                p.Add("_CellPhoneNumber", model.CellPhoneNumber);
                p.Add("_EmailAddress", model.EmailAddress);
                p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spPersonInsert", p, commandType: CommandType.StoredProcedure);
                model.id = p.Get<Int32>("_id");
                return model;
             }

        }

        /// <summary>
        /// Saves the new prize to database
        /// </summary>
        /// <param name="model">prize information</param>
        /// <returns>return prize information including id</returns>
        /// 
        public PrizeModel CreatePrize(PrizeModel model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))

            {
                var p = new DynamicParameters();
                p.Add("_PlaceNumber", model.PlaceNumber);
                p.Add("_PlaceName", model.PlaceName);
                p.Add("_PrizeAmount", model.PrizeAmount);
                p.Add("_PrizePercentage", model.PrizePercentage);
                p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spPrizesInsert", p, commandType: CommandType.StoredProcedure);
                model.id = p.Get<Int32>("_id");
                return model;
            }

        }

        public TeamModel CreateTeamModel(TeamModel model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("_TeamName", model.TeamName);
              p.Add("_id", 10, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spTeamInsert", p, commandType: CommandType.StoredProcedure);
                model.id = p.Get<Int32>("_id"); 
                foreach (PersonModel tm in model.TeamMembers)
                {
                    
                    p = new DynamicParameters();
                    p.Add("_TeamId", model.id);
                    p.Add("_PersonId", tm.id);
                    p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("spTeamMembersInsert", p, commandType: CommandType.StoredProcedure);
                }
            }
                return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                SaveTournament(connection, model,p);
                SaveTournamentPrizes(connection,model,p);
                SaveTournametEntries(connection, model, p);
                saveTpurnamentRound(connection, model, p);
            }
                return model;
        }

        private void saveTpurnamentRound(IDbConnection connection, TournamentModel model, DynamicParameters p)
        {
            foreach (List<MatchupModel> tm in model.Rounds)
            {
                foreach (MatchupModel matchup in tm)
                {

                    p.Add("_TournamentId", model.id);
                    p.Add("_MatchupRound", matchup.MatchupRound);
                    p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("spMatchUp_Insert", p, commandType: CommandType.StoredProcedure);
                    matchup.id = p.Get<Int32>("_id");
                    foreach (MatchupEntryModel entry in matchup.Entries)
                    {

                        p.Add("_MatchupId",matchup.id);
                        if(entry.PerentMatchup==null)
                            p.Add("_ParentMatchupId", null);
                        else
                            p.Add("_ParentMatchupId", entry.PerentMatchup.id);

                        if (entry.TeamCompeting==null)
                            p.Add("_TeamCompetingId", null);
                        else
                            p.Add("_TeamCompetingId", entry.TeamCompeting.id);

                        p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                        connection.Execute("spMatchupEntries_Insert", p, commandType: CommandType.StoredProcedure);

                    }
                }
              
            }


        }

        private void SaveTournametEntries(IDbConnection connection, TournamentModel model, DynamicParameters p)
        {
            foreach (TeamModel tm in model.EnteredTeams)
            {
                p.Add("_TournamentId", model.id);
                p.Add("_TeamId", tm.id);
                p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spTournamentEntries_Insert", p, commandType: CommandType.StoredProcedure);
            }
            
        }

        private void SaveTournamentPrizes(IDbConnection connection, TournamentModel model, DynamicParameters p)
        {
            foreach (PrizeModel tm in model.Prizes)
            {
                p.Add("_TournamentId", model.id);
                p.Add("_PrizeId", tm.id);
                p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("spTournamentPrize_Insert", p, commandType: CommandType.StoredProcedure);
            }
        }

        private void SaveTournament(IDbConnection connection, TournamentModel model, DynamicParameters p)
        {
            p.Add("_TournamentName", model.TournamentName);
            p.Add("_EntryFee", model.EntryFee);
           p.Add("_id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Execute("spTournaments_Insert", p, commandType: CommandType.StoredProcedure);
            model.id = p.Get<Int32>("_id");
        }

        public List<PersonModel> GetAllPersone()
        {
            List<PersonModel> output;
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                output = connection.Query<PersonModel>("spGetAllPeople").ToList();
                
            }
            return output;

        }

        public List<TeamModel> GetAllTeams()
        {
            List<TeamModel> output;
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                output = connection.Query<TeamModel>("spTeam_GetAll", p).ToList();
                foreach(TeamModel team in output)
                {
                    p = new DynamicParameters();
                    p.Add("_TeamId", team.id);
                    team.TeamMembers = connection.Query<PersonModel>("spTeamMember_GetByTeamId", p, commandType: CommandType.StoredProcedure).ToList();
                }

            }
                return output;
        }

        public List<TournamentModel> GetAllTournaments()
        {
        //     public int id { get; set; }
        //public string TournamentName { get; set; }
        //public decimal EntryFee { get; set; }
        //public List<TeamModel> EnteredTeams { get; set; } = new List<TeamModel>();
        //public List<PrizeModel> Prizes { get; set; } = new List<PrizeModel>();
        //public List<List<MatchupModel>> Rounds { get; set; } = new List<List<MatchupModel>>();
        List<TournamentModel> output = new List<TournamentModel>();

            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                output = connection.Query<TournamentModel>("spTournament_GetAll", p).ToList();
                foreach (TournamentModel tournament in output)
                {
                    p = new DynamicParameters();
                    p.Add("_tournamentid", tournament.id);
                    tournament.Prizes = connection.Query<PrizeModel>("spPrizes_GetAllByTournametID", p, commandType: CommandType.StoredProcedure).ToList();
                    tournament.EnteredTeams= connection.Query<TeamModel>("spTeam_GetAllByTournametID", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (TeamModel tm in tournament.EnteredTeams)
                    {
                        p = new DynamicParameters();
                        p.Add("_TeamId", tm.id);
                        tm.TeamMembers = connection.Query<PersonModel>("spTeamMember_GetByTeamId", p, commandType: CommandType.StoredProcedure).ToList();

                    }

                    p = new DynamicParameters();
                    p.Add("_tournamentid", tournament.id);
                    List <MatchupModel>matchups= connection.Query<MatchupModel>("spMatchup_GetByTournamentID", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (MatchupModel m in matchups)
                    {
                        p = new DynamicParameters();
                        p.Add("_Matchupid", m.id);
                        m.Entries = connection.Query<MatchupEntryModel>("spMatchupEntries_GetByTournamentID", p, commandType: CommandType.StoredProcedure).ToList();

                        List<TeamModel> team = GetAllTeams();
                        if (m.WinnerId > 0)
                            m.winner = team.Where(x => x.id == m.WinnerId).First();
                        foreach(MatchupEntryModel e in m.Entries)
                        {
                            if (e.TeamCompetingId > 0)
                            {
                                e.TeamCompeting = team.Where(x => x.id == e.TeamCompetingId).First();
                            }
                            if (e.ParentMatchupId > 0)
                            {
                                e.PerentMatchup = matchups.Where(x => x.id == e.ParentMatchupId).First();
                            }
                        }
                       
                    }

                    //List<List<MatchupModel>>Round
                    List<MatchupModel> curMatchup = new List<MatchupModel>();
                    int curRound = 1;
                    foreach (MatchupModel m in matchups)
                    {
                        if (m.MatchupRound > curRound)
                        {
                            tournament.Rounds.Add(curMatchup);
                            curRound++;
                            curMatchup = new List<MatchupModel>();
                        }
                        curMatchup.Add(m);
                    }
                    tournament.Rounds.Add(curMatchup);
                }

            }
            return output;
        }
    }
}
