using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int numberOfRounds;
            string player;
            int playerThrow;
            int computerThrow;

            string playAgain;


            while (true)
            {
                int winCount = 0;
                int loseCount = 0;
                int tieCount = 0;
                Console.WriteLine("Let's play Rock, Paper, Scissors. How many rounds should we play? ");
                input = Console.ReadLine();

                int.TryParse(input, out numberOfRounds);

                if (numberOfRounds > 10 || numberOfRounds < 1)
                {
                    Console.WriteLine("That not what I said. You're not a good listener and I don't want to play with you anymore.");
                    Console.ReadLine();
                    continue;
                }


                for (int i = 1; i <= numberOfRounds; i++)
                {
                    do
                    {
                        Console.WriteLine("Choose 1 for rock, 2 for paper, and 3 for scissors: ");
                        player = Console.ReadLine();
                        var x = int.TryParse(player, out playerThrow);
                        Random rnd = new Random();
                        computerThrow = rnd.Next(1, 4);

                        if (playerThrow > 3 || playerThrow < 1)
                        {
                            Console.WriteLine("You must enter a NUMBER between 1-3.");
                            numberOfRounds++;
                            break;
                        }




                        else if (computerThrow == playerThrow)
                        {
                            Console.WriteLine("It's a tie!");
                            tieCount++;
                        }
                        else if (computerThrow == 1 && playerThrow == 3 || playerThrow < computerThrow)
                        {
                            Console.WriteLine("You lose!");
                            loseCount++;
                        }
                        else if (playerThrow == 1 && computerThrow == 3 || playerThrow > computerThrow)
                        {
                            Console.WriteLine("You win!");
                            winCount++;
                        }



                    }
                    while (int.TryParse(player, out playerThrow) == false);

                }

                Console.WriteLine("You won " + winCount + " times. You lost " + loseCount + " times. It was a draw " + tieCount + " times.");
                if (winCount == loseCount)
                {
                    Console.WriteLine("Overall, it was a tie. So congrats to us both!");
                }
                else if (winCount > loseCount)
                {
                    Console.WriteLine("Overall, you won! Congrats!");
                }
                else
                {
                    Console.WriteLine("Overall, you lost! Sorry about that.");
                }
                Console.WriteLine("Would you like to play again: y/n");
                playAgain = Console.ReadLine();

                if (playAgain == "n")
                {
                    Console.WriteLine("Thanks for playing!");
                    break;
                }
                if (playAgain == "y")
                {
                    continue;
                }
            }
        }
    }
}
