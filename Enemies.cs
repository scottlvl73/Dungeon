using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Enemies(string _name, string _description, int _hitPoints, int _armorClass,
                   int _attackOneDamage, int _attackTwoDamage, string _attackOneDesc,
                   string _attackTwoDesc, int _gold, int _experience)
    {
        public string name = _name;
        public string description = _description;
        public int hitPoints = _hitPoints;
        public int armorClass = _armorClass;
        public int attackOneDamage = _attackOneDamage;
        public int attackTwoDamage = _attackTwoDamage;
        public string attackOneDesc = _attackOneDesc;
        public string attackTwoDesc = _attackTwoDesc;
        public int gold = _gold;
        public int experience = _experience;

        //Displays the current enemies parameters
    public void DisplayEnemyInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine($"Hit Points: {hitPoints}");
        Console.WriteLine($"Armor Class: {armorClass}");
        Console.WriteLine($"Attack 1: {attackOneDesc}, Damage: {attackOneDamage}");
        Console.WriteLine($"Attack 2: {attackTwoDesc}, Damage: {attackTwoDamage}");
      //  Console.WriteLine($"Gold: {gold}");
      //  Console.WriteLine($"Experience: {experience}");
        Console.ReadLine();
    }
    public class Goblin : Enemies
    {
        public Goblin() : base(
        " Goblin ", 
        "A sneaky green creature", 
        DiceRolls.D6() + DiceRolls.D6(), 
        15, 
        DiceRolls.D6() + 2, 
        DiceRolls.D6(), 
        "The goblin advances with his scimitar in hand - Quick Slice", 
        "The goblin steps back and fires an arrow from his shortbow", 
        50, 
        10)
    {
    }

    }

    public class Kobold : Enemies 
    {
        public Kobold() : base(
        "Kobold",
        "A humanoid creature with a large spear who lives in the dark",
        DiceRolls.D6() + DiceRolls.D6() - 2,
        12,
        DiceRolls.D4() + 2,
        DiceRolls.D4(),
        "The kobold rushed forward charging with his spear",
        "The kobold throws a rock from the ground",
        30,
        15)
    {

    }
    };
       
    public class Zombie : Enemies{
        public Zombie() : base(
        "Zombie Mage", 
        "A Necromancer prowling the catacombs",
        DiceRolls.D8() + DiceRolls.D8() + DiceRolls.D8() + 9,
        8,
        DiceRolls.D6() + 1,
        DiceRolls.D6(),
        "The necromancer smacks you in the head with his staff",
        "The necromancer summons a ghoul to attack, and it stumbles around before falling on you",
        200,
        45
    )
    {

    }
    };
    
    public class Bowman : Enemies{
        public Bowman() : base(
        "Bowman", 
        "A halfling bowman appears from the shadows",
        DiceRolls.D8() + DiceRolls.D8() + 2,
        12,
        DiceRolls.D6() + 2,
        DiceRolls.D6(),
        "The bowman leaps back and pulls an arrow from his quiver and set his sight on you",
        "The bowman advances forward and pulls a dagger from his cloak. He swings it toward you",
        50,
        20
    )
    {}
    };
  
    public static Enemies CreateGoblinEncounter()
    {
    // Create a new instance of Goblin
    // and its stats will be unique to this instance
    Goblin goblin = new();
    return goblin;
    }
    public static Enemies CreateBowmanEncounter()
    {
    // Create a new instance of Goblin
    // and its stats will be unique to this instance
    Bowman bowman = new();
    return bowman;
    }
    public static Enemies CreateZombieEncounter()
    {
    // Create a new instance of Goblin
    // and its stats will be unique to this instance
    Zombie zombie = new();
    return zombie;
    }
    public static Enemies CreateKoboldEncounter()
    {
    // Create a new instance of Goblin
    // and its stats will be unique to this instance
    Kobold kobold = new();
    return kobold;
    }
    }
}