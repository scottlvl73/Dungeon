using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Maps
    {

        public static void CatacombsMap(Player player, bool[] roomArray, int playerPosition, string[] commands)
        {
            string[] stringArray = new string[19];
            //for the length of the room array convert a string
            for (int i = 0; i < roomArray.Length; i++)
            {
                if (i == playerPosition)
                    //mark the players location with P
                    stringArray[i] = "p";
                else if (roomArray[i] == true)
                    stringArray[i] = " ";
                else
                    stringArray[i] = "x";
                
            }
            
            Console.Clear();
            Console.WriteLine($"********** Catacombs Level 1 **********************");
            Console.WriteLine($"***************************************************");
            Console.WriteLine($"*******************|{stringArray[10]}|x|x|x|x|{stringArray[15]}|*******************");
            Console.WriteLine($"*******************|{stringArray[9]}|{stringArray[6]}|{stringArray[3]}|{stringArray[4]}|{stringArray[13]}|{stringArray[14]}|*******************");
            Console.WriteLine($"*******************|{stringArray[7]}|{stringArray[5]}|{stringArray[2]}|{stringArray[11]}|{stringArray[12]}|x|*******************");
            Console.WriteLine($"*******************|{stringArray[8]}|x|{stringArray[1]}|x|{stringArray[16]}|{stringArray[17]}|*******************");
            Console.WriteLine($"*******************|x|x|{stringArray[0]}|x|x|{stringArray[18]}|*******************");
            Console.WriteLine($"******************HitPoints: " + player.playerHealth + " *******************");
            Console.WriteLine($"***Available Commands: {commands[0]} || {commands[1]} || {commands[2]} || {commands[3]}******");
        }


    }
}
