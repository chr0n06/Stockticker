using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DML.Model
{
    public class Dice
    {
        //Variables
        public int id { get; }
        public int faces { get; set; }
        private static Random rdm = new Random();
        public int roll { get; set; }

        //Constructeur
        public Dice(int id)
        {
            this.id = id;
            this.faces = 6;
        }

        //Méthodes
        public int rollDice()
        {
            roll = rdm.Next(1, faces + 1);
            return roll;        
        }
    }
}
