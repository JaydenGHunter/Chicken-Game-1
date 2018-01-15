using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    class Race
    {
        private sorter sorter = new sorter();
        private Random rng = new Random();
        private Data d;
        private Horse winner;
        private int numOfHorses;
        private List<Horse> listOfHorses = new List<Horse>();
        private List<Horse> winners = new List<Horse>();


        public Race(Data _d, int _numOfHorses)
        {
            d = _d;
            numOfHorses = _numOfHorses;
            startRace();
        }

        private void startRace()
        {
            d.horses.Shuffle();
            decideOrder();
            calculateOdds();
            updateHorses();
            d.checkBets(winners);
        }

        private void calculateOdds()
        {
            float totalWinPercentage = 0;
            foreach (Horse horse in winners)
            {
                totalWinPercentage += horse.getWinPercentage()/100;
                if (horse.getWinPercentage() <=11)
                {
                    totalWinPercentage += 11;
                }
            }
            foreach (Horse horse in winners)
            {
                float x = horse.getWinPercentage();
                float winTR = (horse.getWinPercentage()/100) / (totalWinPercentage);
                if (horse.getWinPercentage() <= 11)
                {
                   winTR = 2;
                }
            
                float newOdd = (((winTR / x)/winTR)*100)/1.1f;
                horse.setOdds(newOdd);
            }
        }

        private void decideOrder()
        {
            for (int i = 0; i < numOfHorses; i++)
            {

                listOfHorses.Add(d.horses[i]);
            }
            sorter.SortBySpeed(listOfHorses);
            for (int i = 0; i < numOfHorses; i++)
            {
                //Reset and Update speedTotal
                int speedTotal = 0;
                for (int k = 0; k < listOfHorses.Count; k++)
                {
                    speedTotal += d.horses[k].speed;
                }
                //Calculate percentage 
                int perCent = rng.Next(0, 100);
                if (listOfHorses.Count > 0)
                {
                    for (int j = 0; j < listOfHorses.Count; j++)
                    {
                        float chance = 0;
                        Horse[] temp = listOfHorses.GetRange(0, j+1).ToArray();
                        foreach (Horse temph in temp)
                        {
                            chance += temph.speed;
                        }
                        chance = chance * 100;                     
                        if (perCent < chance / speedTotal)
                        {
                            winners.Add(listOfHorses[j]);
                            listOfHorses.Remove(listOfHorses[j]);
                        }
                    }
                }
                
            }

        }
        private void updateHorses()
        {
            for(int i = 0; i < winners.Count; i++)
            {
                winners[i].races++;
                winners[i].addMoney(1 * winners[i].level);
                winners[i].addExp(2 + winners[i].level);
                winners[i].addPosition(i);
            }
            rewardWinner(winners[0]);
            if (winners.Count>1)
            rewardPlace(winners[1]);
            if (winners.Count > 2)
                rewardPlace(winners[2]);
        }
        private void rewardWinner(Horse h)
        {
            winner = h;
            h.wins++;
            h.places++;
            h.addMoney(50*h.level);
            h.addExp(50);
        }
        private void rewardPlace(Horse h)
        {
            h.places++;
            h.addMoney(25 * h.level);
            h.addExp(6);
        }
        private void printList()
        {
            foreach (Horse horse in d.horses)
            {
                Console.WriteLine(horse.print());
            }
        }
        public List<Horse> Horses { set; get; }

        public Horse getWinner()
        {
            return winner;
        }

        public void placements()
        {
            for (int i = 0; i < winners.Count; i++)
            {
                Console.WriteLine("Position " + (i + 1) + ": " + winners[i].name + " | Speed: " + winners[i].speed + " | Odds: " + winners[i].getOdds());
            }
        }

    }
}
