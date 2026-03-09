using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Deck
    {
        Queue<string> numbers = new Queue<string>();
        Stack<string> letter = new Stack<string>();
        private List<Card> _deck = new List<Card>();


        public Deck()
        {
            this.CreateCards();
            //this._deck.Shuffle();
        }

        private void CreateCards()
        {
            for (int suitIndex = 0; suitIndex < 4; suitIndex++)
            {
                for (int rankIndex = 0; rankIndex < 13; rankIndex++)
                {
                    Card currentCard = new Card(rankIndex, suitIndex);
                    this._deck.Add(currentCard);
                }
            }
        }
        public Card Deal()
        {
            Card temp = this._deck.ElementAt(0);
            this._deck.RemoveAt(0);
            return temp;
        }
        public int CardsRemaining()
        {
            return this._deck.Count;
        }
    }
}
