using STOCKTICKER.DML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.DAL
{
    public class InDB_DAO : IDAO
    {
        List<Player> playerList = new List<Player>();
        List<Pawn> pawnList = new List<Pawn>();
        List<Dice> diceList = new List<Dice>();

        public void createObjects()
        {
            addPlayer();
            addPawn();
            addDice();
        }
        private void addPlayer()
        {
            MarketCard mar1 = new MarketCard(1);
            Player pla1 = new Player(1,"Maxime", mar1);
            playerList.Add(pla1);
            MarketCard mar2 = new MarketCard(2);
            Player pla2 = new Player(2,"Cynthia", mar2);
            playerList.Add(pla2);
            MarketCard mar3 = new MarketCard(3);
            Player pla3 = new Player(3, "Marie", mar3);
            playerList.Add(pla3);
            MarketCard mar4 = new MarketCard(4);
            Player pla4 = new Player(4, "Guy", mar4);
            playerList.Add(pla4);
        }
        private void addPawn()
        {
            Pawn paw1 = new Pawn(1, "GOLD");
            pawnList.Add(paw1);
            Pawn paw2 = new Pawn(2, "SILVER");
            pawnList.Add(paw2);
            Pawn paw3 = new Pawn(3, "OIL");
            pawnList.Add(paw3);
            Pawn paw4 = new Pawn(4, "BONDS");
            pawnList.Add(paw4);
            Pawn paw5 = new Pawn(5, "IND.");
            pawnList.Add(paw5);
            Pawn paw6 = new Pawn(6, "GRAIN");
            pawnList.Add(paw6);
        }
        private void addDice()
        {
            Dice dic1 = new Dice(1);
            diceList.Add(dic1);
            Dice dic2 = new Dice(2);
            diceList.Add(dic2);
            Dice dic3 = new Dice(3);
            diceList.Add(dic3);
        }
        
        public List<Player> fetchAllPlayer()
        { return playerList; }
        public List<Pawn> fetchAllPawn()
        { return pawnList; }
        public List<Dice> fetchAllDice()
        { return diceList; }

    }
}
