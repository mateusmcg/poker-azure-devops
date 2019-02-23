using System.Collections.Generic;
using PokerAzureDevops.Model;
using System.Linq;
using PokerAzureDevops.Enums;
using System;

namespace PokerAzureDevops.Domain
{
    public class PokerDomain
    {
        private const int NUM_CARTAS = 5;
        public PokerDomain() { }

        /// <summary>
        /// Este método inicia uma partida de poker entre dois jogadores e retorna um vencedor
        /// </summary>
        public Jogador IniciarPartida(Jogador jogador1, Jogador jogador2)
        {
            jogador1.Cartas = DistribuirCartas();
            jogador2.Cartas = DistribuirCartas();
            return DefinirVencedor(jogador1, jogador2);
        }

        public List<Carta> DistribuirCartas()
        {
            var cartas = new List<Carta>();

            for (int i = 0; i < NUM_CARTAS; i++)
            {
                cartas.Add(Util.Util.GetCartaAleatoria());
            }

            return cartas;
        }

        public Jogador DefinirVencedor(Jogador jogador1, Jogador jogador2)
        {
            if (IsRoyalFlush(jogador1.Cartas) && !IsRoyalFlush(jogador2.Cartas))
            {
                return jogador1;
            }
            else if (!IsRoyalFlush(jogador1.Cartas) && IsRoyalFlush(jogador2.Cartas))
            {
                return jogador2;
            }
            else if (IsStraightFlush(jogador1.Cartas) && !IsStraightFlush(jogador2.Cartas))
            {
                return jogador1;
            }
            else if (!IsStraightFlush(jogador1.Cartas) && IsStraightFlush(jogador2.Cartas))
            {
                return jogador2;
            }
            else if (IsFlush(jogador1.Cartas) && !IsFlush(jogador2.Cartas))
            {
                return jogador1;
            }
            else if (!IsFlush(jogador1.Cartas) && IsFlush(jogador2.Cartas))
            {
                return jogador2;
            }
            else if (IsStraight(jogador1.Cartas) && !IsStraight(jogador2.Cartas))
            {
                return jogador1;
            }
            else if (!IsStraight(jogador1.Cartas) && IsStraight(jogador2.Cartas))
            {
                return jogador2;
            }
            else
            {
                System.Console.WriteLine(string.Format("Cartas Jogador1: {0} \nCartas Jogador2: {1} ", jogador1.ToString(), jogador2.ToString()));
                return null;
            }
        }

        public Jogador CheckHighCard(Jogador jogador1, Jogador jogador2)
        {
            var highCardJogador1 = jogador1.Cartas.OrderByDescending(carta => carta.NumCarta).First();
            var highCardJogador2 = jogador2.Cartas.OrderByDescending(carta => carta.NumCarta).First();

            if (highCardJogador1.NumCarta > highCardJogador2.NumCarta)
                return jogador1;
            else
                return jogador2;
        }

        public bool IsPair(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, Hands.Pair, 1);
        }

        public bool IsTwoPairs(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, Hands.Pair, 2);
        }

        public bool IsTrinca(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, Hands.Trinca, 1);
        }

        public bool IsStraight(List<Carta> cartas)
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

        public bool IsFlush(List<Carta> cartas)
        {
            return !cartas.Any(o => o.Naipe != cartas.First().Naipe);
        }

        public bool IsFullHouse(List<Carta> cartas)
        {
            return IsPair(cartas) && IsTrinca(cartas);
        }

        public bool IsQuadra(List<Carta> cartas)
        {
            return CheckHandAndQuantity(cartas, Hands.Quadra, 1);
        }

        public bool IsStraightFlush(List<Carta> cartas)
        {
            return IsFlush(cartas) && IsStraight(cartas) && !IsRoyalFlush(cartas);
        }

        public bool IsRoyalFlush(List<Carta> cartas)
        {
            return IsFlush(cartas) && IsRoyalStraight(cartas);
        }

        private bool IsRoyalStraight(List<Carta> cartas)
        {
            var cartasEmOrdem = cartas.OrderBy(carta => carta.NumCarta).ToList();
            return IsStraight(cartasEmOrdem) && cartasEmOrdem.First().NumCarta == NumCarta.Dez;
        }

        private bool CheckHandAndQuantity(List<Carta> cartas, Hands hand, int qtd)
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