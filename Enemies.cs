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
        public static int[] Kobold(int[] kobold)
        {
            int hitPointsPack = (DiceRolls.TwoD6() -2);
            int armorClassPack = 12;
            int weaponDamagePack = (DiceRolls.D4() + 2);
            
            int[] koboldPack = new int[3] { hitPointsPack, armorClassPack, weaponDamagePack };
            

            return koboldPack;
        }
    }
}
