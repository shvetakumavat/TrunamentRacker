using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        /// <summary>
        /// represents the one tean in matchup
        /// </summary>
        public int id { get; set; }

        //properties only use for get data from sql database
       public int MatchupId { get; set; }
        public int ParentMatchupId { get; set; }
       public int TeamCompetingId {get;set;}
        /// <summary>
        /// Represents the score for the particular team
        /// </summary>
        public double score { get; set; }
        /// <summary>
        /// Represents matchup that this team came
        /// 
        /// </summary>

        public TeamModel TeamCompeting { get; set; }
        public MatchupModel PerentMatchup { get; set; }
        
        
    }
}
