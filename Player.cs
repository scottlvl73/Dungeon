using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Player
    {
        public string? playerName = "";
        public int playerHealth = 10;
        public int playerLevel = 1;
        public int playerDamage = DiceRolls.D4() + 13;
        public int armorClass = 16;
        public int gold;
        public int experience;
    }
   
}
