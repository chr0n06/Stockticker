using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DML.Model
{
    public class Pawn
    {
        //Variables
        public int id { get; }
        public string kind { get; set; }
        public int value { get; set; }

        //Constructor
        public Pawn(int id, string kind)
        {
            this.id = id;
            this.kind = kind;
            this.value = 1000;
        }
        //Methods
        public override string ToString()
        {
            return id + " " + kind + " " + value;
        }

    }
}
