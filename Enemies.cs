using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Enemies
    {
        public static List<string> Kobold()
        {

            int hitPointsPack = DiceRolls.TwoD6() -2;
            if(hitPointsPack < 0) { hitPointsPack = 1; }
            string hitPoints = Convert.ToString(hitPointsPack);
            
            string armorClass = "12";
            
            int weaponDamagePack = (DiceRolls.D4() + 2);
            string weaponDamage = Convert.ToString(weaponDamagePack);

            string gold = "30";
            string experience = "15";
            
         List<string> enemy = [hitPoints, armorClass, weaponDamage, gold, experience];

            

            return enemy;
        }
    }
}
