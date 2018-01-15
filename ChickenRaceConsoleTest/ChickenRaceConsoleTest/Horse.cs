using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    public class Horse
    {
        public String name;
        public float places, wins, races;
        private int money = 0;
        private int exp = 0;
        public int level = 1;
        private int expReq = 100;
        public int speed = 1;
        private int upgradeCost = 50;
        private float odds = 1;
        private List<int> positions = new List<int>();

        public Horse(String _name, int _wins, int _places, int _races)
        {
            name = _name;
            places = _places;
            wins = _wins;
            races = _races;
        }
        public float getWinPercentage()
        {
            if (wins > 0)
                return MathF.Round((wins / races) * 100 );
            else
                return 0;
        }
        public float getPlacePercentage()
        {
            if (places > 0)
                return MathF.Round((places / races) * 100);
            else
                return 0;
        }

        public void addExp(int i)
        {
            exp += i;
            checkExp();    
        }
        public void checkExp()
        {
            if (exp >= expReq)
            {
                exp -= expReq;
                levelUp();
            }
        }
        public void updateExpReq()
        {
            expReq = level * 2;
        }
        public void levelUp()
        {
            level++;
            updateExpReq();
        }
        public void upgrade()
        {
            while (money >= upgradeCost)
            {
                speed++;
                money -= upgradeCost;
                upgradeCost = speed * 2;
            }
            
        }
        public void setOdds(float o)
        {
            odds = o;
        }
        public float getOdds()
        {
            return odds;
        }
        public void addMoney(int i)
        {
            money += i;
            upgrade();
        }

        public void addPosition(int i )
        {
            positions.Add(i);
        }
       /* public int Money{ get; set;  }
        public float Places { get; set; }
        public float Races { get; set; }
        public float Wins { get; set; }*/
        public String print()
        {
            return name + " | Level  " + level + " | Speed: "+ speed + " | Races: " + races + " | Wins: " + wins + " | Places: " + places + " | Money " + money +
                    " | Win: " + getWinPercentage() + "% | Place: " + getPlacePercentage() + "%" + " | Odds: " + odds;
        }
    }
}
