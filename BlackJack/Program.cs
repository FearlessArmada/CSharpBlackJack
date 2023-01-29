using System;

namespace BlackJack
{
    internal class Program
    {
        // ;--------------------------------------------------
        // ; Main function, here we render the basic CLI and
        // ; generate the random numbers for the cards.
        // ;
        // ; Status; Finished.
        static void Main(string[] args)
        {
            Console.WriteLine("<------------------------->");
            Console.WriteLine("| Welcome to BlackJack!   |");
            Console.WriteLine("<------------------------->\n");

            int playerCard1, playerCard2, dealerCard1, dealerCard2;
            bool playerCard1IsAce, playerCard2IsAce, playerCard3IsAce, dealerCard1IsAce, dealerCard2IsAce, dealerCard3IsAce;

            // Generate random numbers from 2 to 11
            Random random = new Random();
            playerCard1 = random.Next(2, 12);
            playerCard2 = random.Next(2, 12);
            dealerCard1 = random.Next(2, 12);
            dealerCard2 = random.Next(2, 12);

            // Check for aces
            if (playerCard1 == 11) { playerCard1IsAce = true; } else { playerCard1IsAce = false; }
            if (playerCard2 == 11) { playerCard2IsAce = true; } else { playerCard2IsAce = false; }
            if (dealerCard1 == 11) { dealerCard1IsAce = true; } else { dealerCard1IsAce = false; }
            if (dealerCard2 == 11) { dealerCard2IsAce = true; } else { dealerCard2IsAce = false; }

            if (playerCard1 + playerCard2 > 21)
            {
                if (playerCard1IsAce == true)
                {
                    playerCard1 = 1;
                }
                else if (playerCard2IsAce == true)
                {
                    playerCard2 = 1;
                }
            }
            
            Console.Write("Your cards are: {0} and {1} ", playerCard1, playerCard2);
            Console.WriteLine("({0})", playerCard1 + playerCard2);
            Console.Write("The dealer has: {0} and X ", dealerCard1);
            Console.WriteLine("(?)\n");

            Console.WriteLine("Do you want to take another card? (Y/N)");
            string answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                int playerCard3 = random.Next(2, 12);
                Console.WriteLine("Your new card is: {0}", playerCard3);
                if (playerCard3 == 11) { playerCard3IsAce = true; } else { playerCard3IsAce = false; }
                if (playerCard1 + playerCard2 + playerCard3 > 21)
                {
                    if (playerCard1IsAce == true)
                    {
                        playerCard1 = 1;
                    }
                    else if (playerCard2IsAce == true)
                    {
                        playerCard2 = 1;
                    }
                    else if (playerCard3IsAce == true)
                    {
                        playerCard3 = 1;
                    }
                }
                Console.Write("Your cards are: {0}, {1} and {2} ", playerCard1, playerCard2, playerCard3);
                Console.WriteLine("({0})", playerCard1 + playerCard2 + playerCard3);

                if (playerCard1 + playerCard2 + playerCard3 > 21)
                {
                    Console.WriteLine("You lost!");
                }
                else
                {
                    Console.Write("The dealer has: {0} and {1} ", dealerCard1, dealerCard2);
                    Console.WriteLine("({0})", dealerCard1 + dealerCard2);
                    if (playerCard1 + playerCard2 + playerCard3 > dealerCard1 + dealerCard2)
                    {
                        Console.WriteLine("You won!");
                    }
                    else
                    {
                        Console.WriteLine("You lost!");
                    }
                }
            }
            else
            {
                Console.Write("The dealer has: {0} and {1}", dealerCard1, dealerCard2);
                Console.WriteLine("({0})", dealerCard1 + dealerCard2);

                if (dealerCard1 + dealerCard2 > 21)
                {
                    if (dealerCard1IsAce == true)
                    {
                        dealerCard1 = 1;
                    }
                    else if (dealerCard2IsAce == true)
                    {
                        dealerCard2 = 1;
                    }
                }
                if (dealerCard1 + dealerCard2 < playerCard1 + playerCard2 )
                {
                    Console.WriteLine("You won!");
                }
                else
                {
                    Console.WriteLine("You lost!");
                }
            }
            Console.ReadKey();
        }
    }
}