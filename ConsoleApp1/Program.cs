using BowlingGameScoring;
using System;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            BowlingGame game = new BowlingGame();

            var frames = 1;
            var tries = 1;


            if (frames < 10)
            {
                StartGame();
            }
            else
            {
                Console.WriteLine("Game Complete!");
                Console.ReadKey();
            }

            void StartGame()
            {
                Console.WriteLine("Please enter the number of pins knocked down.");
                var pins = Int32.Parse(Console.ReadLine());
                game.Try(pins);
                Console.WriteLine($"This is Frame{frames} and Roll{tries}. Your score is currently {game.Score()}");
                Console.ReadKey();
                if (pins < 10 && tries == 1)
                {
                    StartGame();
                    tries++;
                } else if (pins < 10 && tries == 2)
                {
                    StartGame();
                    frames++;
                    tries = 1;
                }
                else if (pins == 10){
                    StartGame();
                    frames++;
                }
            }
        }
    }
}
