using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    class Data
    {
        public List<Horse> horses = new List<Horse>();
        public List<Race> races = new List<Race>();
        public List<Player> players = new List<Player>();
        public List<Bet> bets = new List<Bet>();

        public void newRace()
        {
            if (races.Count > 10)
            {
                races.RemoveAt(10);
            }
            races.Insert(0,new Race(this,5));

        }
        public void newPlayer()
        {
            players.Add(new Player("Jayden",100,1));
        }
        public void newBet(int money, Player player, Horse horse, int times)
        {
            bets.Add(new Bet(money, player, horse, times,this));
        }

        public void checkBets(List<Horse> horses)
        {
            if (bets.Count > 0)
            {
                    foreach (Bet bet in bets)
                    {
                        if (bets.Count > 0)
                        bet.checkBet(horses[0], horses[0].getOdds(),true);
                    }
                for(int i = 1; i< horses.Count;i++)
                {
                    if (bets.Count > 0)
                    {
                        foreach (Bet bet in bets)
                        {
                            if (bets.Count > 0)
                            bet.checkBet(horses[i], horses[i].getOdds(), false);
                        }
                    }
                }
            }

        }

        public void printWinner()
        {
            foreach(Race r in races)
            {
                Console.WriteLine(r.getWinner().name);
            }
        }
    }
}
