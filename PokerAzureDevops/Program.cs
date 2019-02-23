using System;
using PokerAzureDevops.Domain;
using PokerAzureDevops.Model;

namespace PokerAzureDevops
{
    public class Program
    {
        static void Main(string[] args)
        {
            var domain = new PokerDomain();

            Console.WriteLine("Gerando jogadores!");

            Console.WriteLine("Iniciando Partida!");

            var jogador1 = new Jogador("Jogador 1");
            var jogador2 = new Jogador("Jogador 2");

            var partida = domain.IniciarPartida(jogador1, jogador2);

            if (partida == null)
            {
                System.Console.WriteLine("\nHouve um empate de High Card! Cartas:\n");
                System.Console.WriteLine(string.Format("Jogador1: {0} \nJogador2: {1} ", jogador1.ToString(), jogador2.ToString()));
                return;
            }

            Console.WriteLine(string.Format("\nO vencedor é: {0} ({1})", partida.Vencedor.Nome, partida.MaoVencedora.ToString()));
            System.Console.WriteLine(string.Format("\nCartas Jogador1: {0} \nCartas Jogador2: {1} ", jogador1.ToString(), jogador2.ToString()));

            Console.ReadKey();
        }
    }
}
