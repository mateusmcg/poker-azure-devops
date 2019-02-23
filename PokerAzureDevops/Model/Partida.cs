using PokerAzureDevops.Enums;

namespace PokerAzureDevops.Model
{
    public class Partida
    {
        public Jogador Vencedor { get; set; }
        public Hands MaoVencedora { get; set; }
    }
}