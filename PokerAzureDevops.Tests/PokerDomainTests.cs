using System.Collections.Generic;
using NUnit.Framework;
using PokerAzureDevops.Domain;
using PokerAzureDevops.Enums;
using PokerAzureDevops.Model;

namespace Tests
{
    [TestFixture]
    public class PokerDomainTests
    {
        private PokerDomain pokerDomain;

        [SetUp]
        public void Setup()
        {
            pokerDomain = new PokerDomain();
        }

        [Test]
        public void ShouldReturnFiveCards()
        {
            var cartas = pokerDomain.DistribuirCartas();
            Assert.IsNotNull(cartas);
            Assert.AreEqual(5, cartas.Count);
        }

        [Test]
        public void ShouldCheckIfThereIsNotAFlush()
        {
            var cartas = new List<Carta>
            {
                new Carta() { Naipe = Naipes.Espadas},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa}
            };

            var cartasIguais = pokerDomain.IsFlush(cartas);
            Assert.IsFalse(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsAFlush()
        {
            var cartas = new List<Carta>
            {
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa},
                new Carta() { Naipe = Naipes.Copa}
            };

            var cartasIguais = pokerDomain.IsFlush(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsAStraight()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.Nove},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Dama},
            };

            var cartasIguais = pokerDomain.IsStraight(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAStraight()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.Nove},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Dama},
            };

            var cartasIguais = pokerDomain.IsStraight(cartas);
            Assert.False(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsARoyalFlush()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Dez, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Valete, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Dama, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Rei, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.As, Naipe = Naipes.Ouro},
            };

            var cartasIguais = pokerDomain.IsRoyalFlush(cartas);
            Assert.True(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAARoyalFlushByNaipes()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Dez, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Valete, Naipe = Naipes.Espadas},
                new Carta() { NumCarta = NumCarta.Dama, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Rei, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.As, Naipe = Naipes.Ouro},
            };

            var cartasIguais = pokerDomain.IsRoyalFlush(cartas);
            Assert.False(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAARoyalFlushByNumCard()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Dez, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Cinco, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Dama, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Rei, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.As, Naipe = Naipes.Ouro},
            };

            var cartasIguais = pokerDomain.IsRoyalFlush(cartas);
            Assert.False(cartasIguais);
        }
    }
}