using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.Preferences
{
    public class Settings
    {
        //Variables
        public static int AMOUNTQUANTITYSTART { get; set; }
        public static int MAXBACKLOGFILL = 9;

    public static DateTime getTime()
        {
            DateTime date = DateTime.Now;
            return date;
        }

    }
}
