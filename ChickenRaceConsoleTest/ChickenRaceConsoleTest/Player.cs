using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    class Player
    {
        private int money, experience, level;
        private String name;
        public Player(String _name, int _money, int _level)
        {
            name = _name;
            money = _money;
            level = _level;
            experience = 0;
        }

        public int getMoney()
        {
            return money;
        }
        public void setMoney(int _money)
        {
            money = _money;
        }
        public void addMoney(int _money)
        {
            money += _money;
        }
    }
}
