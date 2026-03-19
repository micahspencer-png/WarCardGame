using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame
{
    internal class Card
    {
       
        public int RankIndex
        {
            get;
        }
        public int SuitIndex
        {
            get;
        }

        public Card(int rankIndex, int suitIndex)
        {
            this.RankIndex = rankIndex;
            this.SuitIndex = suitIndex;
        }

        public string Suit()
        {
            string _suit = "";
            switch (this.SuitIndex)
            {
                case 0:
                    _suit = "Clubs";
                    break;
                case 1:
                    _suit = "Diamonds";
                    break;
                case 2:
                    _suit = "Hearts";
                    break;
                case 3:
                    _suit = "Spades";
                    break;
                default:
                    _suit = "Joker";
                    break;
            }
            return _suit;
        }
        public string Rank()
        {
            string _rank = "";
            switch (this.RankIndex)
            {
                case 0:
                    _rank = "King";
                    break;
                case 1:
                    _rank = "Ace";
                    break;
                case 11:
                    _rank = "Jack";
                    break;
                case 12:
                    _rank = "Queen";
                    break;
                default://2 through 10
                    _rank = this.RankIndex.ToString();
                    break;
            }

            return _rank;
        }

        public static implicit operator Card(T v)
        {
            throw new NotImplementedException();
        }
    }
}
