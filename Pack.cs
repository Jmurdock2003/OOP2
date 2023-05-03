using CMP1903M_A01_2223;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    // Define the Pack class
    class Pack
    {
        // Define the operator and number of the cards
        private string[] operators = { "+", "-", "*", "/" };
        private Random rand = new Random();
        public List<Card> cards = new List<Card>();

        // Define the constructor for the Pack class
        public Pack()
        {
            // Loop through and create 100 cards with random numbers and operators
            for (int i = 0; i < 100; i++)
            {
                int num = rand.Next(1, 101);
                string op = operators[rand.Next(0, 4)];
                cards.Add(new Card(num.ToString(), op));
            }
        }
    



    // Define the deal method to remove and return the top card from the pack
        public Card deal_number(List<Card> cards)
        {
            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;

        }


        // Define the fisherYatesShuffle method to shuffle the pack using the Fisher-Yates shuffle technique
        public void fisherYatesShuffle(List<Card> cards)
        {
            // Create a new random object and get the number of cards in the pack
            Random rand = new Random();
            int n = cards.Count;

            // Loop through the cards in the pack in reverse order
            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(0, i + 1);
                Card temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }
    

    }

}





