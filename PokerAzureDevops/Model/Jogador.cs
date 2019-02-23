using System.Collections.Generic;
using PokerAzureDevops.Enums;
using PokerAzureDevops.Util;

namespace PokerAzureDevops.Model
{
    public class Jogador
    {
        public Jogador(string nome)
        {
            this.Nome = nome;
        }

        public List<Carta> Cartas { get; set; }
        public string Nome { get; set; }

        public Hands GetHand()
        {
            if (HandChecker.IsRoyalFlush(this.Cartas))
                return Hands.RoyalFlush;
            if (HandChecker.IsStraightFlush(this.Cartas))
                return Hands.StraightFlush;
            if (HandChecker.IsQuadra(this.Cartas))
                return Hands.Quadra;
            if (HandChecker.IsFullHouse(this.Cartas))
                return Hands.FullHouse;
            if (HandChecker.IsFlush(this.Cartas))
                return Hands.Flush;
            if (HandChecker.IsStraight(this.Cartas))
                return Hands.Straight;
            if (HandChecker.IsTrinca(this.Cartas))
                return Hands.Trinca;
            if (HandChecker.IsTwoPairs(this.Cartas))
                return Hands.TwoPair;
            if (HandChecker.IsPair(this.Cartas))
                return Hands.Pair;

            return Hands.HighCard;
        }

        public override string ToString()
        {
            var result = "";
            foreach (var carta in this.Cartas)
            {
                var cartaStr = carta.NumCarta.ToString() + "(" + carta.Naipe.ToString() + ")";
                result = result + " / " + cartaStr;
            }
            return result;
        }
    }
}