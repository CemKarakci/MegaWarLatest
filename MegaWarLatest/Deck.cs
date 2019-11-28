using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaWarLatest
{
    public class Deck
    {
        private Random _random;
        private StringBuilder _sb;
        private List<Card> _deck;

        public Deck()
        {
            _random = new Random();
            _sb = new StringBuilder();
            _deck = new List<Card>();

            string[] suits = new string[] { "Diamond", "Spade", "Heart", "Club" };
            string[] kinds = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (var suit in suits)
            {
                foreach (var kind in kinds)
                {
                    _deck.Add(new Card { Suit = suit, Kind = kind });
                }

            }
            
        }

       
        public string Deal(Player player1, Player player2)
        {
            while (_deck.Count > 0)
            {
                dealCard(player1);
                dealCard(player2);
            }

            return _sb.ToString();
        }

        private void dealCard(Player player)
        {
            Card card = _deck.ElementAt(_random.Next(_deck.Count));
            player.Cards.Add(card);
            _deck.Remove(card);

            _sb.Append("<br/>");
            _sb.Append(player.Name);
            _sb.Append(" is dealt ");
            _sb.Append(card.Kind);
            _sb.Append(" of ");
            _sb.Append(card.Suit);

        }

    }
}