
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace Lottery
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayLottery();

        }

        private static void PlayLottery()
        {
            var gameIsActive = true;
            while (gameIsActive)
            {


                int[] lotteryNumber = new int[6];
                Console.WriteLine("\n**********************************************");
                string userInput = UserInput();

                userInput = CheckUserInput(userInput);

                int[] lotteryBet = userInput.Select(x => (int)char.GetNumericValue(x)).ToArray();
                Console.Write("\tLottozahl: \t\t");
                lotteryNumber = CreateRandomNumber();
                Console.WriteLine("\n");
                int counter = 0;
                Console.Write("\tTreffer: \t\t");

                for (int i = 0; i < lotteryNumber.Length; i++)
                {
                    if (lotteryNumber[i] == lotteryBet[i])
                    {
                        counter++;
                        Console.Write(lotteryBet[i]);
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine("\n\n***********   Du hast " + counter + " Treffer!   ***********\n");
                Console.WriteLine("\tErneut spielen [Y / N]?");
                var playAgain = Console.ReadLine();

                switch (playAgain.ToLower())
                {
                    case "y":
                        gameIsActive = true;
                        break;
                    case "n":
                        gameIsActive = false;
                        break;

                    default:
                        Console.WriteLine("\nUngültige Eingabe. Spiel wird abgebrochen");
                        gameIsActive = false;
                        break;
                }

                //if ((playAgain.ToLower() != "y"))
                // {
                //     gameIsActive = false;
                // }

            }
        }

        private static string UserInput()
        {

            Console.WriteLine("\n\tGib eine 6 stellige Zahl ein:");
            Console.Write("\n\tDeine Zahl: \t\t");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static string CheckUserInput(string userInput)
        {
            int number = 0;

            while (userInput.Length != 6 ||
            !int.TryParse(userInput, out number) ||
            number < 100000)
            {
                Console.WriteLine("\n\tUngültige Eingabe!\n");
                Console.WriteLine("*********************************************\n");

                Console.Write("\tGib eine 6 stellige Zahl ein: \n\n\tDeine Zahl: \t\t");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private static int[] CreateRandomNumber()
        {
            var random = new Random();
            int[] lotteryNumber = new int[6];
            for (int i = 0; i < 6; i++)
            {
                lotteryNumber[i] = random.Next(0, 9);
                Console.Write(lotteryNumber[i]);
            }
            return lotteryNumber;
        }
    }
}