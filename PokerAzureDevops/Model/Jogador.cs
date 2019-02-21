using System.Collections.Generic;

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
    }
}