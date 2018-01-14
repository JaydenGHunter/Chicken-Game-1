using System;
using System.Collections.Generic;
using System.Text;

namespace ChickenRaceConsoleTest
{
    public class sorter
    {
        public static void SortBySpeed(List<Horse> list)
        {
            
            list.Sort(delegate (Horse x, Horse y)
              {
                  return y.speed.CompareTo(x.speed);
              });
        }
    }
}
