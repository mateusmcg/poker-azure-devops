using System.Collections.Generic;
using NUnit.Framework;
using PokerAzureDevops.Domain;
using PokerAzureDevops.Enums;
using PokerAzureDevops.Model;
using PokerAzureDevops.Util;

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
        public void ShouldReturnFiveCardsAndDecreaseBaralhoCount()
        {
            var baralho = Util.GetBaralho();
            var cartasJogador1 = pokerDomain.DistribuirCartas(baralho);
            var cartasJogador2 = pokerDomain.DistribuirCartas(baralho);
            Assert.IsNotNull(cartasJogador1);
            Assert.IsNotNull(cartasJogador2);
            Assert.AreEqual(5, cartasJogador1.Count);
            Assert.AreEqual(5, cartasJogador2.Count);
            Assert.AreEqual(42, baralho.Count);
        }

        [Test]
        public void ShouldReturnAWinner()
        {
            var winner = pokerDomain.IniciarPartida(new Jogador("Jogador 1"), new Jogador("Jogador 2"));
            Assert.NotNull(winner);
        }
    }
}