
using System;
using PokerAzureDevops.Enums;
using PokerAzureDevops.Model;

namespace PokerAzureDevops.Util
{
    public static class Util
    {
        public static Carta GetCartaAleatoria()
        {
            return new Carta
            {
                Naipe = GetNaipeAleatorio(),
                NumCarta = GetNumCartaAleatorio()
            };
        }

        private static Naipes GetNaipeAleatorio()
        {
            Array values = System.Enum.GetValues(typeof(Naipes));
            Random random = new Random();
            return (Naipes)values.GetValue(random.Next(values.Length));
        }

        private static NumCarta GetNumCartaAleatorio()
        {
            Array values = System.Enum.GetValues(typeof(NumCarta));
            Random random = new Random();
            return (NumCarta)values.GetValue(random.Next(values.Length));
        }
    }
}