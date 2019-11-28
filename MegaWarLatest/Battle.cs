using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaWarLatest
{
    public class Battle
    {
        private List<Card> _bounty;
        private StringBuilder _sb;
        public Battle()
        {
            _bounty = new List<Card>();
            _sb = new StringBuilder();
        }

        public string PerformBattle(Player player1,Player player2)
        {
            Card card1 = GetCard(player1);
            Card card2 = GetCard(player2);
            EvaluatePerformance(player1, player2, card1, card2);
            return _sb.ToString();
        }

        private Card GetCard(Player player)
        {
            Card card = player.Cards.ElementAt(0);
            player.Cards.Remove(card);
            _bounty.Add(card);
            return card;

        }

        private void EvaluatePerformance(Player player1, Player player2, Card card1, Card card2)
        {
            displayBattleCards(card1, card2);
            if (card1.CardValue() == card2.CardValue())
                War(player1,player2);
            if (card1.CardValue() > card2.CardValue())
                awardWinner(player1);
            if (card1.CardValue() < card2.CardValue())
                awardWinner(player2);
            

        }

        private void awardWinner(Player player)
        {
            if (_bounty.Count == 0) return;
            player.Cards.AddRange(_bounty);
            displayBountyCards();
            _bounty.Clear();

            _sb.Append("<br/>");
            _sb.Append("<strong>");
            _sb.Append(player.Name);
            _sb.Append("</strong>");
            _sb.Append(" wins!<br/>");
        }

        private void War(Player player1,Player player2)
        {
            _sb.Append("<br/>");
            _sb.Append("**************WAR***********");

            GetCard(player1);
            Card warCard1 = GetCard(player1);
            GetCard(player1);

            GetCard(player2);
            Card warCard2 = GetCard(player2);
            GetCard(player2);

            EvaluatePerformance(player1, player2, warCard1, warCard2);
        }
        private void displayBountyCards()
        {
            _sb.Append("<br/> Bounty Cards are: ");
           
            foreach (var card in _bounty)
            {
                _sb.Append("<br/>");
                _sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;");               
                _sb.Append(card.Kind);
                _sb.Append(" of ");
                _sb.Append(card.Suit);
            }


        }

        private void displayBattleCards(Card card1, Card card2)
        {
            _sb.Append("<br/>");
            _sb.Append("Battle Cards are: ");
            _sb.Append(card1.Kind);
            _sb.Append(" of ");
            _sb.Append(card1.Suit);
            _sb.Append(" versus ");
            _sb.Append(card2.Kind);
            _sb.Append(" of ");
            _sb.Append(card2.Suit);

        }
    }
}