using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using STOCKTICKER.DML.Model;
using STOCKTICKER.BLL;
using STOCKTICKER.Preferences;

namespace STOCKTICKER
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int historic = 0 ;
        public MainWindow()
        {
            InitializeComponent();
            Controller.createObjects();
            initializeGame();      
        }
        private void initializeGame()
        {
            updatePlayerBench();           
            updateMarketValues();
            establishRank();
        }
        private void RollDices(object sender, RoutedEventArgs e)
        {
            string stock = "";
            string action = "";
            string number = "";
            foreach (var x in Controller.fetchAllDice().Where(x => x.id == 1))
            {
                stock = Controller.rollDice(x);
                stockShake1.Text = stock;
                switch(stock)
                {
                    case "GOLD":
                        stockShake2.Text = "SILVER";
                        stockShake3.Text = "OIL";
                        break;
                    case "SILVER":
                        stockShake2.Text = "OIL";
                        stockShake3.Text = "BONDS.";
                        break;
                    case "OIL":
                        stockShake2.Text = "BONDS";
                        stockShake3.Text = "IND.";
                        break;
                    case "BONDS":
                        stockShake2.Text = "IND.";
                        stockShake3.Text = "GRAIN";
                        break;
                    case "IND.":
                        stockShake2.Text = "GRAIN";
                        stockShake3.Text = "GOLD";
                        break;
                    case "GRAIN":
                        stockShake2.Text = "GOLD";
                        stockShake3.Text = "SIVLER";
                        break;
                }  
            }
            foreach (var x in Controller.fetchAllDice().Where(x => x.id == 2))
            {
                action = Controller.rollDice(x);
                actionShake1.Text = action;
                switch (action)
                {
                    case "UP":
                        actionShake2.Text = "DOWN";
                        actionShake3.Text = "DIV";
                        break;
                    case "DOWN":
                        actionShake2.Text = "DIV";
                        actionShake3.Text = "UP";
                        break;
                    case "DIV":
                        actionShake2.Text = "UP";
                        actionShake3.Text = "DOWN";
                        break;
                }
            }
            foreach (var x in Controller.fetchAllDice().Where(x => x.id == 3))
            {
                number = Controller.rollDice(x);
                numberShake1.Text = number;
                switch (number)
                {
                    case "5":
                        numberShake2.Text = "10";
                        numberShake3.Text = "20";
                        break;
                    case "10":
                        numberShake2.Text = "20";
                        numberShake3.Text = "5";

                        break;
                    case "20":
                        numberShake2.Text = "5";
                        numberShake3.Text = "10";
                        break;
                }
            }
            Controller.influenceOnMarket(stock, action, number);
            updateMarketValues();
            updatePlayerBench();
            establishRank();
            updateTextBox(stock, action, number);
        }
        private void updateMarketValues()
        {
            foreach (var x in Controller.fetchAllPawn())
            {
                if (x.kind.Equals("GOLD"))
                {
                    amountGold_master.Text = x.value.ToString();
                    barGold.Value = x.value;
                }
                if (x.kind.Equals("SILVER"))
                {
                    amountSilver_master.Text = x.value.ToString();
                    barSilver.Value = x.value;
                }
                if (x.kind.Equals("OIL"))
                {
                    amountOil_master.Text = x.value.ToString();
                    barOil.Value = x.value;
                }
                if (x.kind.Equals("BONDS"))
                {
                    amountBonds_master.Text = x.value.ToString();
                    barBonds.Value = x.value;
                }
                if (x.kind.Equals("IND."))
                {
                    amountIndust_master.Text = x.value.ToString();
                    barIndust.Value = x.value;
                }
                if (x.kind.Equals("GRAIN"))
                {
                    amountGrain_master.Text = x.value.ToString();
                    barGrain.Value = x.value;
                }  
            }    
        }
        public void updatePlayerBench()
        {
            foreach (var x in Controller.fetchAllPlayer())
            {
                switch(x.id)
                {
                    case 1:
                        playerId1.Text = x.name.ToString();
                        money1.Text = x.money.ToString();
                        amountGold1.Text = x.marketCard.amountGold.ToString();
                        amountSilver1.Text = x.marketCard.amountSilver.ToString();
                        amountOil1.Text = x.marketCard.amountOil.ToString();
                        amountBonds1.Text = x.marketCard.amountBonds.ToString();
                        amountIndust1.Text = x.marketCard.amountIndust.ToString();
                        amountGrain1.Text = x.marketCard.amountGrain.ToString();
                        break;
                    case 2:
                        playerId2.Text = x.name.ToString();
                        money2.Text = x.money.ToString();
                        amountGold2.Text = x.marketCard.amountGold.ToString();
                        amountSilver2.Text = x.marketCard.amountSilver.ToString();
                        amountOil2.Text = x.marketCard.amountOil.ToString();
                        amountBonds2.Text = x.marketCard.amountBonds.ToString();
                        amountIndust2.Text = x.marketCard.amountIndust.ToString();
                        amountGrain2.Text = x.marketCard.amountGrain.ToString();
                        break;
                    case 3:
                        playerId3.Text = x.name.ToString();
                        money3.Text = x.money.ToString();
                        amountGold3.Text = x.marketCard.amountGold.ToString();
                        amountSilver3.Text = x.marketCard.amountSilver.ToString();
                        amountOil3.Text = x.marketCard.amountOil.ToString();
                        amountBonds3.Text = x.marketCard.amountBonds.ToString();
                        amountIndust3.Text = x.marketCard.amountIndust.ToString();
                        amountGrain3.Text = x.marketCard.amountGrain.ToString();
                        break;
                    case 4:
                        playerId4.Text = x.name.ToString();
                        money4.Text = x.money.ToString();
                        amountGold4.Text = x.marketCard.amountGold.ToString();
                        amountSilver4.Text = x.marketCard.amountSilver.ToString();
                        amountOil4.Text = x.marketCard.amountOil.ToString();
                        amountBonds4.Text = x.marketCard.amountBonds.ToString();
                        amountIndust4.Text = x.marketCard.amountIndust.ToString();
                        amountGrain4.Text = x.marketCard.amountGrain.ToString();
                        break;

                }   
            }
        }    
        private void updateTextBox(string stock, string action, string number)
        {
            if (Controller.historicLoggerLimit(historic) == false){
                textBox.Text = Settings.getTime() + " : " + stock + " " +
                    action + " " + number + "\n";
                historic = 0;
            }
            else  {
                textBox.Text += Settings.getTime() + " : " + stock + " " +
                    action + " " + number + "\n";
                historic++;
            }
            textBox.ScrollToEnd();
        }
        private void establishRank()
        {
            Player[] playerRank = new Player[Controller.fetchAllPlayer().Count];

            Controller.calculatePts();
            playerRank = Controller.triRank(Controller.fetchAllPlayerTab(), Controller.fetchAllPlayer().Count);
            leaderBoard.Text = "";
            foreach (var x in playerRank)
            {
                leaderBoard.Text += x.name + ": " + x.pts + " $" + "\n";
            }
        }
        private void manageStock1_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manager1 = new ManageStock(1, this);
            manager1.Show();
        }
        private void manageStock2_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manager2 = new ManageStock(2, this);
            manager2.Show();
        }
        private void manageStock3_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manager3 = new ManageStock(3, this);
            manager3.Show();
        }
        private void manageStock4_Click(object sender, RoutedEventArgs e)
        {
            ManageStock manager4 = new ManageStock(4, this);
            manager4.Show();
        }
        

        //Actions that has not been implemented yet
        //How to play Stock Ticker?
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
           //How to play
        }

        
    }
}
