using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DML.Model
{
    public class MarketCard
    {
        //Variables
        public int id { get; }
        public int amountGold { get; set; }
        public int amountSilver { get; set; }
        public int amountOil { get; set; }
        public int amountBonds { get; set; }
        public int amountIndust { get; set; }
        public int amountGrain { get; set; }

        //Contructor
        public MarketCard(int id)
        {
            this.id = id;
            this.amountGold = 0;
            this.amountSilver = 0;
            this.amountOil = 0;
            this.amountBonds = 0;
            this.amountIndust = 0;
            this.amountGrain = 0;
        }
        //Methods
        public override string ToString()
        {
            return id + " " + amountGold + " " + amountSilver + " " + amountOil + " " +
                amountBonds + " " + amountIndust + " " + amountGrain;
        }

    }
}
