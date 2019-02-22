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

            if (vencedor == null)
            {
                Console.WriteLine(string.Format("Não teve vencedor..."));
                return;
            }

            Console.WriteLine(string.Format("O vencedor é: {0}", vencedor.Nome));

            Console.ReadKey();
        }
    }
}
