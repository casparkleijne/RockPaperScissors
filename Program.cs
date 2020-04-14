using System;

namespace RockPaperScissors
{
    public enum Winner
    {
        Draw = 0,
        Computer = -1,
        Human = 1
    }

    public enum Gesture
    {
        Rock,
        Paper,
        Scissors,
    }

    public class Player
    {              
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private readonly Winner _winner;

        public Player(Winner winner) => _winner = winner;
        public Gesture Gesture { get; set; }
        public void RandomGesture() => Gesture = (Gesture)_random.Next(0, 3);
        public Winner Duel(Player other) => (Winner)((((int)Gesture - (int)other.Gesture + 4) % 3 - 1) * (int)_winner);
    }


    //TESTING
    class Program
    {

        static void Main(string[] args)
        {
            Player computer = new Player(Winner.Computer);
            Player human = new Player(Winner.Human);

            for(int i = 0; i < 100; i ++)
            {
                computer.RandomGesture();
                human.Gesture = Gesture.Paper;

                Console.WriteLine($"Computer does {computer.Gesture}, Human does {human.Gesture}");
               
                // following lines should show the same results
                Console.WriteLine($"Winner = {computer.Duel(human)}");
                Console.WriteLine($"Winner = {human.Duel(computer)}");

                Console.ReadLine();
            }
        }
    }
}
