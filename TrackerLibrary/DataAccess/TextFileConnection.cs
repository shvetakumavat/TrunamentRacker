using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextConnector;
namespace TrackerLibrary.DataAccess
{
    public class TextFileConnection : IDataConnection
    {
        private const string PrizeFile = "PrizeModel.csv";
        private const string PeopleFile = "PersonModel.csv";
        private const string TeamFile = "TeamModel.csv";
        public PersonModel CreatePersone(PersonModel model)
        {
            List<PersonModel> persone = PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
            int currentID = persone.Count > 0 ? persone.OrderByDescending(x => x.id).First().id + 1 : 1;
            model.id = currentID;
            persone.Add(model);
            persone.SaveToPersonModelFile(PeopleFile);
            return model;
        }

        public  PrizeModel CreatePrize(PrizeModel model)
        {
            List<PrizeModel> prizes = PrizeFile.FullFilePath().LoadFile().ConvertToPrizeModel();
            int currentId =prizes.Count>0? prizes.OrderByDescending(x => x.id).First().id + 1:1;
            model.id = currentId;
            prizes.Add(model);
            prizes.saveToPrizeFile(PrizeFile);
            return model;
        }

        public TeamModel CreateTeamModel(TeamModel model)
        {
           List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();
            int currentID = teams.Count > 0 ? teams.OrderByDescending(x => x.id).First().id + 1 : 1;
            model.id = currentID;
            teams.Add(model);
            teams.saveToCreateTeamsFile(TeamFile);
            return model;

        }

        public TournamentModel CreateTournament(TournamentModel model)
        {

            List<TournamentModel> tournaments = GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel();
            int currentId = tournaments.Count > 0 ? tournaments.OrderByDescending(x => x.id).First().id + 1 : 1;
            model.id = currentId;
            model.SaveRoundsToFile();
            tournaments.Add(model);
            tournaments.saveToCreateTournamentFile(GlobalConfig.TournamentFile);
            return model;
        }

        public List<PersonModel> GetAllPersone()
        {
            return PeopleFile.FullFilePath().LoadFile().ConvertToPersonModel();
        }

        public List<TeamModel> GetAllTeams()
        {
            return TeamFile.FullFilePath().LoadFile().ConvertToTeamModel();
        }

        public List<TournamentModel> GetAllTournaments()
        {
            return GlobalConfig.TournamentFile.FullFilePath().LoadFile().ConvertToTournamentModel();
        }
    }
}
