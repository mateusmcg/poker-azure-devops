using System.Collections.Generic;
using PokerAzureDevops.Model;
using System.Linq;
using PokerAzureDevops.Enums;
using System;
using PokerAzureDevops.Util;

namespace PokerAzureDevops.Domain
{
    public class PokerDomain
    {
        private const int NUM_CARTAS = 5;
        public PokerDomain() { }

        /// <summary>
        /// Este método inicia uma partida de poker entre dois jogadores e retorna um vencedor
        /// </summary>
        public Partida IniciarPartida(Jogador jogador1, Jogador jogador2)
        {
            var baralho = Util.Util.GetBaralho();
            jogador1.Cartas = DistribuirCartas(baralho);
            jogador2.Cartas = DistribuirCartas(baralho);
            return DefinirVencedor(jogador1, jogador2);
        }

        public List<Carta> DistribuirCartas(List<Carta> baralho)
        {
            var cartas = new List<Carta>();

            for (int i = 0; i < NUM_CARTAS; i++)
            {
                var random = new Random().Next(0, baralho.Count - 1);
                var carta = baralho[random];
                cartas.Add(carta);
                baralho.Remove(carta);
            }

            return cartas;
        }

        private Partida DefinirVencedor(Jogador jogador1, Jogador jogador2)
        {
            var jogador1Hand = jogador1.GetHand();
            var jogador2Hand = jogador2.GetHand();

            if (jogador1Hand == Hands.HighCard && jogador2Hand == Hands.HighCard)
            {
                return DefinirVencedorHighCard(jogador1, jogador2);
            }
            else
            {
                if (jogador1Hand > jogador2Hand)
                {
                    return new Partida
                    {
                        Vencedor = jogador1,
                        MaoVencedora = jogador1Hand
                    };
                }
                else if (jogador1Hand < jogador2Hand)
                {
                    return new Partida
                    {
                        Vencedor = jogador2,
                        MaoVencedora = jogador2Hand
                    };
                }
                else
                    return DefinirVencedorHighCard(jogador1, jogador2);
            }
        }

        private Partida DefinirVencedorHighCard(Jogador jogador1, Jogador jogador2)
        {
            var jogador1HighCard = jogador1.Cartas.OrderByDescending(carta => carta.NumCarta).First();
            var jogador2HighCard = jogador2.Cartas.OrderByDescending(carta => carta.NumCarta).First();

            if (jogador1HighCard.NumCarta > jogador2HighCard.NumCarta)
            {
                return new Partida
                {
                    Vencedor = jogador1,
                    MaoVencedora = Hands.HighCard
                };
            }
            else if (jogador1HighCard.NumCarta < jogador2HighCard.NumCarta)
            {
                return new Partida
                {
                    Vencedor = jogador2,
                    MaoVencedora = Hands.HighCard
                };
            }
            else
                return null;
        }
    }
}