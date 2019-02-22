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
            
            var vencedor = domain.IniciarPartida(new Jogador("Jogador 1"), new Jogador("Jogador 2"));

            Console.WriteLine(string.Format("O vencedo é: {0}", vencedor.Nome));
        }
    }
}
