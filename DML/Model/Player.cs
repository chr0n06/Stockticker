using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DML.Model
{
    public class Player
    {
        //Variables
        public int id { get; }
        public string name { get; set; }
        public int money { get; set; }
        public int pts { get; set; }
        public MarketCard marketCard { get; set; }
        
        //Constructor
        public Player(int id, string name, MarketCard marketCard)
        {
            this.id = id;
            this.name = name;
            this.money = 15000;
            this.pts = 0;
            this.marketCard = marketCard;
        }
        //Methods
        public override string ToString()
        {
            return id + " " + " " + money + " " + marketCard;
        }
    }
}
