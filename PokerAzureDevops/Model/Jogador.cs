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