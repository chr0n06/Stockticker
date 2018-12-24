using STOCKTICKER.DML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DAL
{
    public interface IDAO
    {
        void createObjects();
        List<Player> fetchAllPlayer();
        List<Pawn> fetchAllPawn();
        List<Dice> fetchAllDice();
    }
}
