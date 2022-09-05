using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
  public static  class TournamentLogic
    {
        public static void CreateRound(TournamentModel model)
        {
            List<TeamModel> randomizeTeams = RandomizeTeamOrders(model.EnteredTeams);
            int round = FindNumberOfRounds(randomizeTeams.Count);
            int byes = NumberOfByes(round, randomizeTeams.Count);
            model.Rounds.Add(CreateFristRound(byes, randomizeTeams));
            CreateOtherRounds(model, round);

        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> priviousRound = model.Rounds[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchUp = new MatchupModel();
            while (round <= rounds)
            {
                foreach (MatchupModel m in priviousRound)
                {
                    currMatchUp.Entries.Add(new MatchupEntryModel { PerentMatchup = m });
                    if (currMatchUp.Entries.Count > 1)
                    {
                        currMatchUp.MatchupRound = round;
                        currRound.Add(currMatchUp);
                        currMatchUp = new MatchupModel();
                    }
                }
                model.Rounds.Add(currRound);
                priviousRound = currRound;
                currRound = new List<MatchupModel>();
                round++;
            }

        }

        private static List<MatchupModel> CreateFristRound(int byes, List<TeamModel> randomizeTeams)
        {
            List<MatchupModel> output = new List<MatchupModel>();
            MatchupModel cur = new MatchupModel();
            foreach (TeamModel t in randomizeTeams)
            {
                cur.Entries.Add(new MatchupEntryModel { TeamCompeting = t });
                if (byes > 0 || cur.Entries.Count > 1)
                {
                    cur.MatchupRound = 1;
                    output.Add(cur);
                    cur = new MatchupModel();
                    if (byes > 0)
                    {
                        byes -= 1;

                    }
                }
            }
            return output;
        }

        private static int NumberOfByes(int round, int count)
        {
            int output = 0;
            int totalTeams= 1;
            for (int i = 1; i <= round; i++)
            {
                totalTeams *= 2;
            }
            output = totalTeams - count;
            return output;
        }

        private static List<TeamModel> RandomizeTeamOrders(List<TeamModel> enteredTeams)
        {
            return enteredTeams.OrderBy(x => Guid.NewGuid()).ToList();
        }

        private static int FindNumberOfRounds(int count)
        {
            int output = 1;
            int val = 2;
            while (val < count)
            {
                output++;
                val *= 2;
            }
            return output;

        }
    }
}
