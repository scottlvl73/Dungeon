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

        public static int D6()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 6 + 1);
            return roll;
        }
        public static int D4()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 4 + 1);
            return roll;
        }
        public static int D10()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 10 + 1);
            return roll;
        }
        public static int D20()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 20 + 1);
            return roll;
        }
        public static int D100()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 100 + 1);
            return roll;
        }

        public static int TwoD6()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 6 + 1);
            int roll2 = myDie.Next(1, 6 + 1);
            int total = roll + roll2;
            return total;

        }
    }
}
