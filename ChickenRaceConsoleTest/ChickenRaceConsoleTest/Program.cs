using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChickenRaceConsoleTest
{
    static class Program
    {


        static public CommandController cc;
        static public Data data;
        static void Main(string[] args)
        {
            cc = new CommandController();        
            data = new Data();
            bool finished = false;
            data.newPlayer();
            Console.WriteLine("Type 'Start' to start");
            while (!finished)
            {
                cc.parseString(Console.ReadLine(),data);
            }
        }

        public static void Shuffle<T>(this IList<T> list)
        {

            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

    }
}
