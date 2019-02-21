using System.Collections.Generic;
using PokerAzureDevops.Model;

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
            return null;
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
    }
}