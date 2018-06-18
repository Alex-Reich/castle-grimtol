using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var playing = true;
            var game = new Game();

            game.Setup();
            while (playing)
            {
                Console.WriteLine("You win... until the DLC comes out and you find out it was all a dream!");
                System.Console.WriteLine("Start over? y/n");
                if (Console.Read() == 'n') { playing = false;};
            }

        }
    }
}
