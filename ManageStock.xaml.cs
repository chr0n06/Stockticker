using STOCKTICKER.BLL;
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
using System.Windows.Shapes;

namespace STOCKTICKER
{
    /// <summary>
    /// Logique d'interaction pour ManageStock.xaml
    /// </summary>
    public partial class ManageStock : Window
    {
        //Variables
        public int id { get; set; }
        public int tempMoney { get; set; }
        public int counterGold { get; set; }
        public int tempGold { get; set; }
        public int counterSilver { get; set; }
        public int tempSilver { get; set; }
        public int counterOil { get; set; }
        public int tempOil { get; set; }
        public int counterBonds { get; set; }
        public int tempBonds { get; set; }
        public int counterIndust { get; set; }
        public int tempIndust { get; set; }
        public int counterGrain { get; set; }
        public int tempGrain { get; set; }
        private MainWindow mw { get; set; }

        //Constructor
        public ManageStock(int id, MainWindow mw_)
        {
            InitializeComponent();
            this.id = id;
            this.mw = mw_;
            getPlayerBench(this.id);
        }    
          
        private void getPlayerBench(int id)
        {
            foreach (var x in Controller.fetchAllPlayer().Where(x => x.id == id))
            {
                tempMoney = x.money;
                tempGold = x.marketCard.amountGold;
                tempSilver = x.marketCard.amountSilver;
                tempOil = x.marketCard.amountOil;
                tempBonds = x.marketCard.amountBonds;
                tempIndust = x.marketCard.amountIndust;
                tempGrain = x.marketCard.amountGrain;
                updatePlayerBench(id);   
            }
        }
        private string checkVariation(int counter, TextBox variation)
        {
            if (counter > 0)
            {
                variation.Foreground= Brushes.Green;
                return "+" + Convert.ToString(counter);
            }
            if(counter == 0)
            {
                return "";
            }
            if (counter < 0)
            {
                variation.Foreground = Brushes.Red;
                return Convert.ToString(counter);
            }
            return null;
        }              
        private void updatePlayerBench(int id)
        {
            var x = Controller.findPlayerById(id);
            playerId.Text = x.name;
            money.Text = x.money.ToString();
            amountGold.Text = x.marketCard.amountGold.ToString();
            amountSilver.Text = x.marketCard.amountSilver.ToString();
            amountOil.Text = x.marketCard.amountOil.ToString();
            amountBonds.Text = x.marketCard.amountBonds.ToString();
            amountIndust.Text = x.marketCard.amountIndust.ToString();
            amountGrain.Text = x.marketCard.amountGrain.ToString();    
        }

        private void addGold_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("GOLD");
            if (tempMoney >= y.value)
            {
                tempGold += 1000;
                counterGold += 1000;
                tempMoney -= y.value;
                amountGoldVariation.Text = checkVariation(counterGold, amountGoldVariation);
                amountGold.Text = Convert.ToString(tempGold);
                money.Text = tempMoney.ToString();
            }    
        }
        private void removeGold_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("GOLD");
            if (tempGold > 0)
            {
                tempGold -= 1000;
                counterGold -= 1000;
                tempMoney += y.value;
                amountGoldVariation.Text = checkVariation(counterGold, amountGoldVariation);
                amountGold.Text = Convert.ToString(tempGold);
                money.Text = tempMoney.ToString();
            }  
        }
        private void addSilver_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("SILVER");
            if (tempMoney >= y.value)
            {
                tempSilver += 1000;
                counterSilver += 1000;
                tempMoney -= y.value;
                amountSilverVariation.Text = checkVariation(counterSilver, amountSilverVariation);
                amountSilver.Text = Convert.ToString(tempSilver);
                money.Text = tempMoney.ToString();
            }
        }
        private void removeSilver_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("SILVER");
            if (tempSilver > 0)
            {
                tempSilver -= 1000;
                counterSilver -= 1000;
                tempMoney += y.value;
                amountSilverVariation.Text = checkVariation(counterSilver, amountSilverVariation);
                amountSilver.Text = Convert.ToString(tempSilver);
                money.Text = tempMoney.ToString();
            }
        }
        private void addOil_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("OIL");
            if (tempMoney >= y.value)
            {
                tempOil += 1000;
                counterOil += 1000;
                tempMoney -= y.value;
                amountOilVariation.Text = checkVariation(counterOil, amountOilVariation);
                amountOil.Text = Convert.ToString(tempOil);
                money.Text = tempMoney.ToString();
            }
        }
        private void removeOil_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("OIL");
            if (tempOil > 0)
            {
                tempOil -= 1000;
                counterOil -= 1000;
                tempMoney += y.value;
                amountOilVariation.Text = checkVariation(counterOil, amountOilVariation);
                amountOil.Text = Convert.ToString(tempOil);
                money.Text = tempMoney.ToString();
            }
        }
        private void addBonds_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("BONDS");
            if (tempMoney >= y.value)
            {
                tempBonds += 1000;
                counterBonds += 1000;
                tempMoney -= y.value;
                amountBondsVariation.Text = checkVariation(counterBonds, amountBondsVariation);
                amountBonds.Text = Convert.ToString(tempBonds);
                money.Text = tempMoney.ToString();
            }
        }
        private void removeBonds_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("BONDS");
            if (tempBonds > 0)
            {
                tempBonds -= 1000;
                counterBonds -= 1000;
                tempMoney += y.value;
                amountBondsVariation.Text = checkVariation(counterBonds, amountBondsVariation);
                amountBonds.Text = Convert.ToString(tempBonds);
                money.Text = tempMoney.ToString();
            }
        }
        private void addIndust_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("IND.");
            if (tempMoney >= y.value)
            {
                tempIndust += 1000;
                counterIndust += 1000;
                tempMoney -= y.value;
                amountIndustVariation.Text = checkVariation(counterIndust, amountIndustVariation);
                amountIndust.Text = Convert.ToString(tempIndust);
                money.Text = tempMoney.ToString();
            }
        }
        private void removeIndust_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("IND.");
            if (tempIndust > 0)
            {
                tempIndust -= 1000;
                counterIndust -= 1000;
                tempMoney += y.value;
                amountIndustVariation.Text = checkVariation(counterIndust, amountIndustVariation);
                amountIndust.Text = Convert.ToString(tempIndust);
                money.Text = tempMoney.ToString();
            }
        }
        private void addGrain_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("GRAIN");
            if (tempMoney >= y.value)
            {
                tempGrain += 1000;
                counterGrain += 1000;
                tempMoney -= y.value;
                amountGrainVariation.Text = checkVariation(counterGrain, amountGrainVariation);
                amountGrain.Text = Convert.ToString(tempGrain);
                money.Text = tempMoney.ToString();
            }
        }
        private void removeGrain_Click(object sender, RoutedEventArgs e)
        {
            var y = Controller.findPawnByKind("GRAIN");
            if (tempGrain > 0)
            {
                tempGrain -= 1000;
                counterGrain -= 1000;
                tempMoney += y.value;
                amountGrainVariation.Text = checkVariation(counterGrain, amountGrainVariation);
                amountGrain.Text = Convert.ToString(tempGrain);
                money.Text = tempMoney.ToString();
            }
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            Controller.acceptManageStock(this.id, tempMoney, tempGold, tempSilver,
                tempOil, tempBonds, tempIndust, tempGrain);
            mw.updatePlayerBench();
            this.Close();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    
    }
}
