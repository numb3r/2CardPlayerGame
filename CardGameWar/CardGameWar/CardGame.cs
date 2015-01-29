using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; 

namespace CardGameWar
{
    public class CardGame
    {
        static void Main(string[] args)
        {
            String[] player1 = new String[26];
            String[] player2 = new String[26];
            Deck deck = new Deck();
            deck.Shuffle();

            PlayerDeal(player1, player2, deck);
            int count = WinCount(player1, player2);
            if (count > 0)
            {
                Console.WriteLine( "\nWINNER IS player1");
            }
            else if (count < 0)
            {
                Console.WriteLine("\nWINNER IS player2");

            }
            else
            {
                Console.WriteLine("\nBummer its tie, let's go for new war !!");

            }
            Console.ReadLine();
        }

        private static int WinCount(String[] player1, String[] player2)
        {
            int count  = 0 ;
            for (int i = 0; i < 26; i++)
            {
                var p1 = player1[i].Split(' ');
                var value1 =  Int32.Parse(p1.First());
                
                var p2 = player2[i].Split(' ');
                var value2 = Int32.Parse(p2.First());

                if (value1 > value2)
                {
                    count = count + 1;
                    Console.WriteLine("Player 1 wins !! ");
                }
                else if (value1 < value2)
                {
                    count = count - 1;
                    Console.WriteLine("Player 2 wins !! ");
                }

            }

           

            return count; 

        }

        private static void PlayerDeal(String[] player1, String[] player2, Deck deck)
        {
            string newCard;
            int current;
            for (int i = 0; i < 52; i++)
            {
                newCard = deck.Deal().ToString();

                if ((i + 1) % 2 == 0)
                {
                    if (i == 1)
                    {
                        current = 0;
                    }
                    else
                    {
                        current = (i - 1) / 2;
                    }
                    player1[current] = newCard;

                }
                else
                {
                    if (i == 0)
                    {
                        current = 0;
                    }
                    else
                    {
                        current = (i / 2);
                    }
                    player2[current] = newCard;
                }

            }

            Console.WriteLine("Player1 \t Player2");
            for (int i = 0; i < 26; i++)
            {
                Console.WriteLine(player2[i] + "\t\t" + player1[i]);
            }
        }
    }

}

