using STOCKTICKER.DML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DAL
{
    public class Repository
    {
        public static IDAO dao = new InDB_DAO();

        public static void createObjects()
        {
            dao.createObjects();
        }

        public static List<Player> fetchAllPlayer()
        {
            return dao.fetchAllPlayer();
        }
        public static List<Pawn> fetchAllPawn()
        {
            return dao.fetchAllPawn();
        }
        public static List<Dice> fetchAllDice()
        {
            return dao.fetchAllDice();
        }

    }
}
