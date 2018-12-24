using STOCKTICKER.DAL;
using STOCKTICKER.DML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STOCKTICKER.BLL
{
    public class Controller
    {       
        public static void createObjects()
        {
            Repository.createObjects();
        } 
        public static List<Player> fetchAllPlayer()
        {
            return Repository.fetchAllPlayer();
        }
        public static Player[] fetchAllPlayerTab()
        {
            Player[] playerRank = new Player[fetchAllPlayer().Count];
            int count = 0;

            foreach (var x in fetchAllPlayer())
            {
                playerRank[count] = x;
                count++;
            }
            return playerRank;
        }
        public static Player findPlayerById(int id)
        {
            foreach (var x in fetchAllPlayer().Where(x => x.id == id))
            {
                return x;
            }
            return null;
        }
        public static List<Pawn> fetchAllPawn()
        {
            return Repository.fetchAllPawn();
        }
        public static Pawn findPawnByKind(string kind)
        {
            foreach (var x in fetchAllPawn().Where(x => x.kind.Equals(kind)))
            {
                return x;
            }
            return null;
        }
        public static List<Dice> fetchAllDice()
        {
            return Repository.fetchAllDice();
        }
        public static string rollDice(Dice dic)
        { 
            string result;
            int roll = dic.rollDice();
            
            if (dic.id == 1)
            {
                result = stockShake(roll);
                return result;            
            }
            if (dic.id == 2)
            {
                result = actionShake(roll);
                return result;
            }
            else result = numberShake(roll);
            return result;
        }
        public static void influenceOnMarket(string stock, string action, string number)
        {
            foreach (var x in Controller.fetchAllPawn().Where(x => x.kind.Equals(stock)))
            {
                if (action.Equals("UP"))
                {
                    x.value += Convert.ToInt32(number) * 10;
                    x.value = checkIfTilt(x.value, stock);
                }
                if (action.Equals("DOWN"))
                {
                    x.value -= Convert.ToInt32(number) * 10;
                    x.value = checkIfTilt(x.value, stock);
                }
                if (action.Equals("DIV"))
                {
                    rewardPlayers(stock, number);
                }
            }
        }
        public static void calculatePts()
        {
            foreach (var x in Controller.fetchAllPlayer())
            {
                int money = x.money;
                int gold = x.marketCard.amountGold;
                int silver = x.marketCard.amountSilver;
                int oil = x.marketCard.amountOil;
                int bonds = x.marketCard.amountBonds;
                int indust = x.marketCard.amountIndust;
                int grain = x.marketCard.amountGrain;

                foreach (var y in Controller.fetchAllPawn())
                {
                    switch (y.kind)
                    {
                        case "GOLD":
                            money += ((gold / 1000) * y.value);
                            break;
                        case "SILVER":
                            money += ((silver / 1000) * y.value);
                            break;
                        case "OIL":
                            money += ((oil / 1000) * y.value);
                            break;
                        case "BONDS":
                            money += ((bonds / 1000) * y.value);
                            break;
                        case "IND.":
                            money += ((indust / 1000) * y.value);
                            break;
                        case "GRAIN":
                            money += ((grain / 1000) * y.value);
                            break;
                    }
                }
                x.pts = money;
            }
        }
        public static void acceptManageStock(int id, int money, int amountGold, int amountSilver,
            int amountOil, int amountBonds, int amountIndust, int amountGrain)
        {
            var x = findPlayerById(id);
            x.money = money;
            x.marketCard.amountGold = amountGold;
            x.marketCard.amountSilver = amountSilver;
            x.marketCard.amountOil = amountOil;
            x.marketCard.amountBonds = amountBonds;
            x.marketCard.amountIndust = amountIndust;
            x.marketCard.amountGrain = amountGrain;
        }
        public static Player[] triRank(Player[] tableau, int n)
        {
            int j;
            Player eltCourant;
            for (int i = 1; i < n; i++)
            {
                eltCourant = tableau[i];
                j = i;
                while ((j > 0) && (tableau[j - 1].pts < eltCourant.pts))
                {
                    tableau[j] = tableau[j - 1];
                    j = j - 1;
                }
                tableau[j] = eltCourant;
            }
            return tableau;
        }
        public static Boolean historicLoggerLimit(int historic)
        {
            if (historic == Preferences.Settings.MAXBACKLOGFILL){
                return false;
            } 
            else return true;
        }
        private static void rewardPlayers(string stock, string number)
        {
            foreach (var x in Controller.fetchAllPawn().Where(x => x.kind.Equals(stock)))
            {
                foreach (var y in Controller.fetchAllPlayer())
                {
                    if (x.value >= 1000)
                    {
                        if (stock.Equals("GOLD"))
                        {
                            y.money += ((y.marketCard.amountGold * Convert.ToInt32(number) / 100));
                        }
                        if (stock.Equals("SILVER"))
                        {
                            y.money += ((y.marketCard.amountSilver * Convert.ToInt32(number) / 100));
                        }
                        if (stock.Equals("OIL"))
                        {
                            y.money += ((y.marketCard.amountOil * Convert.ToInt32(number) / 100));
                        }
                        if (stock.Equals("BONDS"))
                        {
                            y.money += ((y.marketCard.amountBonds * Convert.ToInt32(number) / 100));
                        }
                        if (stock.Equals("IND."))
                        {
                            y.money += ((y.marketCard.amountIndust * Convert.ToInt32(number) / 100));
                        }
                        if (stock.Equals("GRAIN"))
                        {
                            y.money += ((y.marketCard.amountGrain * Convert.ToInt32(number) / 100));
                        }
                    }
                }
            }
        } 
        private static int checkIfTilt(int value, string stock)
        {
            if ((value == 2000) || (value > 2000))
            {
                split(stock);
                return value = 1000;               
            }
            if ((value == 0) || (value < 0))
            {
                bankrupt(stock);
                return value = 1000; 
            }
            return value;
        }
        private static void split(string stock)
        {
            foreach (var x in fetchAllPlayer())
            {
                switch (stock)
                {
                    case "GOLD" :
                        x.marketCard.amountGold = x.marketCard.amountGold * 2;
                        break;
                    case "SILVER":
                        x.marketCard.amountSilver = x.marketCard.amountSilver * 2;
                        break;
                    case "OIL":
                        x.marketCard.amountOil = x.marketCard.amountOil * 2;
                        break;
                    case "BONDS":
                        x.marketCard.amountBonds = x.marketCard.amountBonds * 2;
                        break;
                    case "IND.":
                        x.marketCard.amountIndust = x.marketCard.amountIndust * 2;
                        break;
                    case "GRAIN":
                        x.marketCard.amountGrain = x.marketCard.amountGrain * 2;
                        break;
                    default :
                        break;
                }
            }
        }
        private static void bankrupt(string stock)
        {
            foreach (var x in fetchAllPlayer())
            {
                switch (stock)
                {
                    case "GOLD":
                        x.marketCard.amountGold = 0;
                        break;
                    case "SILVER":
                        x.marketCard.amountSilver = 0;
                        break;
                    case "OIL":
                        x.marketCard.amountOil = 0;
                        break;
                    case "BONDS":
                        x.marketCard.amountBonds = 0;
                        break;
                    case "IND.":
                        x.marketCard.amountIndust = 0;
                        break;
                    case "GRAIN":
                        x.marketCard.amountGrain = 0;
                        break;
                    default:
                        break;
                }
            }
        }        
        private static string stockShake(int roll)
        {
            if (roll == 1)
            {
                return "GOLD";
            }
            if (roll == 2)
            {
                return "SILVER";
            }
            if (roll == 3)
            {
                return "OIL";
            }
            if (roll == 4)
            {
                return "BONDS";
            }
            if (roll == 5)
            {
                return "IND.";
            }
            else return "GRAIN";
        }
        private static string actionShake(int roll)
        {
            if ((roll == 1) || (roll == 4))
            {
                return "UP";
            }
            if ((roll == 2) || (roll == 5))
            {
                return "DOWN";
            }
            else return "DIV";
        }
        private static string numberShake(int roll)
        {
            if ((roll == 1) || (roll == 4))
            {
                return "5";
            }
            if ((roll == 2) || (roll == 5))
            {
                return "10";
            }
            else return "20";
        }   
    }
}
