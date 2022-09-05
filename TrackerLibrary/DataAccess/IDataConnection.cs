using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary.DataAccess

{
   public interface IDataConnection
    {
        PrizeModel CreatePrize(PrizeModel model);

        PersonModel CreatePersone(PersonModel model);
        TeamModel CreateTeamModel(TeamModel model);
        TournamentModel CreateTournament(TournamentModel model);
        List<PersonModel> GetAllPersone();
        List<TeamModel> GetAllTeams();
        List<TournamentModel> GetAllTournaments();

    }
}
