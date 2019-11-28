using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaWarLatest
{
    public class Game
    {
        private Player _player1;
        private Player _player2;
        private StringBuilder _sb;
       

        public Game(string player1Name, string player2Name)
        {
            _player1 = new Player() { Name = player1Name };
            _player2 = new Player() { Name = player2Name };
            _sb = new StringBuilder();
            
        }
       

        public string Play()
        {

            Deck deck = new Deck();
            string result = "<br/><h3>Dealing Cards...</h3>";
            result += deck.Deal(_player1, _player2);

            result += "<br/><h3>Battle Starts</h3>";

            int round = 0;
            while (_player1.Cards.Count != 0 && _player2.Cards.Count != 0)
            {
                Battle battle = new Battle();               
                result += battle.PerformBattle(_player1,_player2);
                round++;
                if (round > 20)
                    break;
            }

            result += determineWinner();
            return result;
        }

        private string determineWinner()
        {
            string result = "";
            if (_player1.Cards.Count > _player2.Cards.Count)
                result +="<br/>"+"<span style = 'color:red; font-weight:bolder'>" + _player1.Name +"</span>"+ " wins! As usual ";
            if (_player2.Cards.Count > _player1.Cards.Count)
                result+= "<br/>" + "<span style = 'color:blue; font-weight:bolder'>" + _player2.Name + "</span>" + " are you cheating or what? ";

            result += "<br/>" + "<span style = 'color:red; font-weight:bolder'>" + _player1.Name +"</span>" + " has " + _player1.Cards.Count + " cards ";
            result += "<br/>" + "<span style = 'color:blue; font-weight:bolder'>" + _player2.Name +"</span>" + " has " + _player2.Cards.Count + " cards ";

            return result;
        }

       
    }
}