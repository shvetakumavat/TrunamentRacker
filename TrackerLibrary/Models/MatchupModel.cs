using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TrackerLibrary.Models
{
   public class MatchupModel
    {
        public int id { get; set; }
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();
        public int WinnerId { get; set; }
        public TeamModel winner { get; set; }
        public int MatchupRound { get; set; }

        public string DisplayName {
            get {
                string output = "";
                foreach (MatchupEntryModel e in Entries)
                {
                    if (e.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {

                            output = e.TeamCompeting.TeamName;
                        }
                        else {

                            output += $" vs { e.TeamCompeting.TeamName }";
                        }
                    }
                    else
                    {
                        output = "Not Determined";
                        break;
                    }

                }
               
                return output;
            }
        }

       
        
    }
}
