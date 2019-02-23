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
        public void ShouldCheckIfIsHighCard()
        {
            var cartasJogador1 = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.Dama},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Seis},
            };

            var cartasJogador2 = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.Tres},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Cinco},
            };

            var jogador1 = new Jogador("Fulano")
            {
                Cartas = cartasJogador1
            };

            var jogador2 = new Jogador("Fulano 2")
            {
                Cartas = cartasJogador2
            };

            var jogadorHighCard = pokerDomain.CheckHighCard(jogador1, jogador2);
            Assert.AreEqual(jogadorHighCard, jogador1);
        }

        [Test]
        public void ShouldCheckIfIsAPair()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Oito},
            };

            var cartasIguais = pokerDomain.IsPair(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAPair()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.Valete},
                new Carta() { NumCarta = NumCarta.Nove},
            };

            var cartasIguais = pokerDomain.IsPair(cartas);
            Assert.IsFalse(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsTwoPairs()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dez},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Oito},
            };

            var cartasIguais = pokerDomain.IsTwoPairs(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotTwoPairs()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Oito},
            };

            var cartasIguais = pokerDomain.IsTwoPairs(cartas);
            Assert.IsFalse(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsATrinca()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Oito},
            };

            var cartasIguais = pokerDomain.IsTrinca(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotATrinca()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Oito},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Tres},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Oito},
            };

            var cartasIguais = pokerDomain.IsTrinca(cartas);
            Assert.IsFalse(cartasIguais);
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
        public void ShouldCheckIfItIsNotAFlush()
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
        public void ShouldCheckIfIsAFullHouse()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dama},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dama},
            };

            var cartasIguais = pokerDomain.IsFullHouse(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAFullHouse()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dama},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dois},
                new Carta() { NumCarta = NumCarta.Dama},
            };

            var cartasIguais = pokerDomain.IsFullHouse(cartas);
            Assert.IsFalse(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsAQuadra()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.Dama},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
            };

            var cartasIguais = pokerDomain.IsQuadra(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAQuadra()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
                new Carta() { NumCarta = NumCarta.As},
            };

            var cartasIguais = pokerDomain.IsQuadra(cartas);
            Assert.IsFalse(cartasIguais);
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

        [Test]
        public void ShouldCheckIfIsAStraightFlush()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Dois, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Tres, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Quatro, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Cinco, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Seis, Naipe = Naipes.Ouro},
            };

            var cartasIguais = pokerDomain.IsStraightFlush(cartas);
            Assert.IsTrue(cartasIguais);
        }

        [Test]
        public void ShouldCheckIfIsNotAStraightFlush()
        {
            var cartas = new List<Carta>
            {
                new Carta() { NumCarta = NumCarta.Dez, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Valete, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Dama, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.Rei, Naipe = Naipes.Ouro},
                new Carta() { NumCarta = NumCarta.As, Naipe = Naipes.Ouro},
            };

            var cartasIguais = pokerDomain.IsStraightFlush(cartas);
            Assert.IsFalse(cartasIguais);
        }
    }
}