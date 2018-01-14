using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ChickenRaceConsoleTest
{
    class CommandController
    {
        Stopwatch sw = new Stopwatch();

        public object TextPool { get; private set; }

        public void parseString(String s, Data d)
        {
            Console.Clear();
            sw.Restart();
            switch(s)
            {
                case "start":
                    populateHorses(d.horses);
                    break;
                case "sort":
                    sort(d);
                    break;
                case "horses":
                    getHorses(d);
                    break;
                case "race":
                    race(d);
                    break;
                case "tb8":
                    topbot8(d);
                    break;
                case "winner":
                    d.printWinner();
                    break;
                case "placements":
                    d.races[0].placements();
                    break;
                case "bet":
                    startBet(d);
                    break;

            }
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.ElapsedMilliseconds + " ms");
        }

        private void startBet(Data d)
        {
            Console.WriteLine("What horse would you like to bet on?");
            bool horseFound = false;
            Horse horse; ;
            while (!horseFound)
            {
                String name = Console.ReadLine();
                 horse = d.horses.Find(delegate (Horse x) { return x.name == name; });
                if (horse != null)
                    horseFound = true;
                else
                    return;
                Console.WriteLine("How much would you like to bet? You currently have $" + d.players[0].getMoney());
                int amount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("How many times would you like to bet? Max amount: " + d.players[0].getMoney() / amount);
                int times = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Very nice, attempting to create bet now.");
                d.newBet(amount, d.players[0], horse, times);
            }
            

        }
        //Gets top 8 horses and bottom 8 horses
        private void topbot8(Data d)
        {
            
            for(int i = 0; i <8;i++)
            {
                Console.WriteLine(d.horses[i].print());
            }
            for (int i = 8; i > 0; i--)
            {
                Console.WriteLine(d.horses[d.horses.Count-i].print());
            }
        }

        private void sort(Data d)
        {
            
            Console.Clear();
            d.horses.Sort(delegate (Horse x, Horse y)
            {
                return (x.wins/x.races).CompareTo(y.wins/y.races);
            });
            Console.WriteLine("Sorting finsihed, type 'horses' to print horses");
        }
        private void race(Data d)
        {
            Console.Clear();
            Console.WriteLine("How many races?");
            float x = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            for (float i = 0; i < x; i++)
            {
                Console.Write("\r{0}   ", "Races " + MathF.Round(((i+1) /x)*100)+ "% " + "   ("+(i+1)+"/"+x+")");
                newRace(d);
            }
            Console.WriteLine("Finished " + x + " Race(s)");
        }

        private void getHorses(Data d)
        {
            foreach(Horse horse in d.horses)
            {
                Console.WriteLine(horse.print());
            }
        }

        private void populateHorses(List<Horse> _h)
        {
            Console.Clear();
            Console.WriteLine("How many Horses do you want?");
            int amount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                String newName = "Horse" + (i + 1);
                _h.Add(new Horse(newName, 0, 0, 0));
            }
            Console.WriteLine("Horses list has been populated");
            Console.WriteLine("Type 'horses' to print list of horses");
        }

        private void newRace(Data d)
        {
            d.newRace();

        }
    }
}
