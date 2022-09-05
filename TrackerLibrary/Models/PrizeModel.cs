using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
   public class PrizeModel
    {
        public int id { get; set; }
        public int PlaceNumber { get; set; }
        public string PlaceName { get; set; }
        public decimal PrizeAmount { get; set; }
        public double PrizePercentage { get; set; }

        public PrizeModel()
        { 
        }
        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentege)
        {
            PlaceName = placeName;
            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;
            double prizePercentageVlaue = 0;
            double.TryParse(prizePercentege, out prizePercentageVlaue);
            PrizePercentage = prizePercentageVlaue;
            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;


        }

    }
}
