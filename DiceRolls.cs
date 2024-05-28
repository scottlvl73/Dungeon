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
            Random myDie = new Random();
            int roll = myDie.Next(1, 7);
            return roll;
        }
        public static int D4()
        {
            Random myDie = new Random();
            int roll = myDie.Next(1, 5);
            return roll;
        }
        public static int D8()
        {
            Random myDie = new Random();
            int roll = myDie.Next(1, 9);
            return roll;
        }
        public static int D10()
        {
            Random myDie = new Random();
            int roll = myDie.Next(1, 11);
            return roll;
        }
        public static int D20()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 21);
            return roll;
        }
        public static int D100()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 101);
            return roll;
        }

        public static int TwoD6()
        {
            Random myDie = new();
            int roll = myDie.Next(1, 7);
            int roll2 = myDie.Next(1, 7);
            int total = roll + roll2;
            return total;

        }
    }
}
