using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Deck
    {
        Queue<string> numbers = new Queue<string>();
        Stack<string> letter = new Stack<string>();
        private List<Card> _deck = new List<Card>();
        Card[] list;

        public Deck()
        {
            this.CreateCards();
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
            Shuffle(_deck);
            try
            {
                Card temp = this._deck.ElementAt(0);
                this._deck.RemoveAt(0);
                return temp;
            }
            catch 
            {
                return null;
            }
        }
        public int CardsRemaining()
        {
            return this._deck.Count;
        }

        public static void Shuffle<Card>(List<Card> _deck)
        {
            Random rand = new Random();
            for (int i = _deck.Count; i > 1;)
            {
                i--;
                int r = rand.Next(i + 1);
                (_deck[i], _deck[r]) = (_deck[r], _deck[i]);
            }

        }


    }

    internal class T
    {
        public static implicit operator T(Card v)
        {
            throw new NotImplementedException();
        }
    }
}
