using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameWar
{
    public class Deck
    {
        private Card[] deck;
        private int currentCard;
        private const int TOTAL_CARDS = 52;
        private Random randomNumber;


        public Deck()
        {
            string[] faces = { "1","2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

            string[] suits = { "H", "D", "S", "C" };
            
            deck = new Card[TOTAL_CARDS];
            currentCard = 0;
            randomNumber = new Random();
            
            for (int count = 0; count < deck.Length; count++)
            {
                deck[count] = new Card(faces[count % 11], suits[count / 13]);
            }

        }

        public void Shuffle()
        {
            currentCard = 0;
            
            for (int first = 0; first < deck.Length; first++)
            {
                int second = randomNumber.Next(TOTAL_CARDS);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;

            }
        }

        public Card Deal()
        {
            if(currentCard< deck.Length)
            {
                return deck[currentCard++];
            }
            else{
                return null; 
            }
        }
    }  
}
