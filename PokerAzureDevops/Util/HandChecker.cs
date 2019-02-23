using System.Collections.Generic;
using PokerAzureDevops.Model;
using System.Linq;
using PokerAzureDevops.Enums;

namespace PokerAzureDevops.Util
{
    public static class HandChecker
    {
        public static Jogador CheckHighCard(Jogador jogador1, Jogador jogador2)
        {
            var highCardJogador1 = jogador1.Cartas.OrderByDescending(carta => carta.NumCarta).First();
            var highCardJogador2 = jogador2.Cartas.OrderByDescending(carta => carta.NumCarta).First();

            if (highCardJogador1.NumCarta > highCardJogador2.NumCarta)
                return jogador1;
            else
                return jogador2;
        }

        public static bool IsPair(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, HandCheck.Pair, 1);
        }

        public static bool IsTwoPairs(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, HandCheck.Pair, 2);
        }

        public static bool IsTrinca(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, HandCheck.Trinca, 1);
        }

        public static bool IsStraight(List<Carta> cartas)
        {
            var cartasEmOrdem = cartas.OrderBy(carta => carta.NumCarta).ToList();
            var valorPrimeiraCarta = (int)cartasEmOrdem.First().NumCarta;
            for (int i = 1; i < cartasEmOrdem.Count; i++)
            {
                var valorCartaAtual = (int)cartasEmOrdem[i].NumCarta;
                if ((valorPrimeiraCarta + i) != valorCartaAtual)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsFlush(List<Carta> cartas)
        {
            return !cartas.Any(o => o.Naipe != cartas.First().Naipe);
        }

        public static bool IsFullHouse(List<Carta> cartas)
        {
            return IsPair(cartas) && IsTrinca(cartas);
        }

        public static bool IsQuadra(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, HandCheck.Quadra, 1);
        }

        public static bool IsStraightFlush(List<Carta> cartas)
        {
            return IsFlush(cartas) && IsStraight(cartas) && !IsRoyalFlush(cartas);
        }

        public static bool IsRoyalFlush(List<Carta> cartas)
        {
            return IsFlush(cartas) && IsRoyalStraight(cartas);
        }

        private static bool IsRoyalStraight(List<Carta> cartas)
        {
            var cartasEmOrdem = cartas.OrderBy(carta => carta.NumCarta).ToList();
            return IsStraight(cartasEmOrdem) && cartasEmOrdem.First().NumCarta == NumCarta.Dez;
        }

        private static bool CheckHandAndQuantity(List<Carta> cartas, HandCheck hand, int qtd)
        {
            var groups = cartas.GroupBy(carta => carta.NumCarta).ToList();
            var pairsCount = 0;
            groups.ForEach(group =>
            {
                if (group.Count() == (int)hand)
                {
                    pairsCount++;
                }
            });

            return pairsCount == qtd;
        }
    }
}