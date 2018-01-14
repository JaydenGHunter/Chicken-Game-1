using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    class Bet
    {
        int amount;
        Player player;
        Horse horse;
        int times;
        Data d;

        public Bet(int _amount, Player _player, Horse _horse, int _times, Data _d)
        {
            amount = _amount;
            player = _player;
            horse = _horse;
            times = _times;
            d = _d;
            player.addMoney(-amount * times);
            Console.WriteLine("Bet Created! You will be alerted if your bet pays off. You have $" + player.getMoney() +" left in your wallet");
        }

        public void checkBet(Horse _horse, float odd,bool win)
        {
            if (times > 0)
            {
                if (horse == _horse && win)
                    payoutBet(odd);
                else
                    if (horse == _horse && !win)
                {
                    loseBet();
                }
            }
            else if (times == 0)
                removeBet();
        }
        private void loseBet()
        {
            times--;
            Console.WriteLine("You lost $" + amount + " You now have: $" + (amount * times) + " left on the bet");
        }
        private void payoutBet(float odd)
        {

                int newAmount = (int)(odd * amount);
                player.addMoney(newAmount);
                times--;
                Console.WriteLine("You're bet has paid out $" + newAmount + " You now have: $" + player.getMoney() + " remaining, and $" + (amount * times) + " left on the bet");

        }

        private void removeBet()
        {
            //d.bets.RemoveAt(d.bets.FindIndex(this.Equals));
            times = -1;
            Console.WriteLine("Bet has expired and has been removed");
        }
    }
}
