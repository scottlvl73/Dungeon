using System.Numerics;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace Dungeon.Tests
{


    public class DiceRollTest(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper output = output;

        [Fact]
        public void D6_Test()
        {
            //Arrange
            int roll1;

            //Act
            roll1 = DiceRolls.D6();
            output.WriteLine("The die rolled " + roll1);

            //Assert
            Assert.InRange(roll1, 1, 6);
        }
        [Fact]
        public void D4_Test()
        {
            //Arrange
            int roll1;

            //Act
            roll1 = DiceRolls.D4();
            output.WriteLine("The die rolled " + roll1);

            //Assert
            Assert.InRange(roll1, 1, 4);
        }
        [Fact]
        public void D10_Test()
        {
            //Arrange
            int roll1;

            //Act
            roll1 = DiceRolls.D10();
            output.WriteLine("The die rolled " + roll1);

            //Assert
            Assert.InRange(roll1, 1, 10);
        }
        [Fact]
        public void D20_Test()
        {
            //Arrange
            int roll1;

            //Act
            roll1 = DiceRolls.D20();
            output.WriteLine("The die rolled " + roll1);

            //Assert
            Assert.InRange(roll1, 1, 20);
        }
        [Fact]
        public void D100_Test()
        {
            //Arrange
            int roll1;

            //Act
            roll1 = DiceRolls.D100();
            output.WriteLine("The die rolled " + roll1);

            //Assert
            Assert.InRange(roll1, 1, 100);
        }

        [Fact]
        public void TwoD6_Test()
        {
            //Arrange
            int roll1;
            int roll2;
            int total;
            //Act
            roll1 = DiceRolls.D6();
            roll2 = DiceRolls.D6();
            total = roll1 + roll2;

            output.WriteLine("The die rolled " + roll1 + " and " + roll2 + " " + "for a total of " + total);

            //Assert
            Assert.InRange(total, 2, 12);

        }
    }
    public class EnemiesTest(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper output = output;


        [Fact]
        public void Kobold_Test()
        {

            //Arrange
            List<string> list = [];
            list = Enemies.Kobold();
            

            //Act
            foreach (string item in list)
            {
                output.WriteLine(item);
                Convert.ToInt32(item);
                output.WriteLine(item);


            }


            //Assert

            Assert.True(list.Count != 0);
         
        }
    }
}