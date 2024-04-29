using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
   
    public class DiceRolls
    {
       private Random myDie = new Random();
        public int D6()
        {
           return myDie.Next(1, 6 + 1);
        }
        public int D4()
        {
            return myDie.Next(1, 4 + 1);
        }
        public int D10()
        {
            return myDie.Next(1, 10 + 1);
        }
        public int D20()
        {
            return myDie.Next(1, 20 + 1);
        }
        public int D100()
        {
            return myDie.Next(1, 100 + 1);
        }
        public int TwoD6()
        {
            return myDie.Next(1, 6 + 1);
        }


    }
}
