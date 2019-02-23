using NUnit.Framework;
using PokerAzureDevops.Enums;
using System.Linq;

namespace PokerAzureDevops.Tests
{
    [TestFixture]
    public class UtilTests
    {
        [Test]
        public void ShouldReturnADeckWith52Cards()
        {
            var baralho = Util.Util.GetBaralho();
            Assert.IsNotNull(baralho);
            Assert.AreEqual(52, baralho.Count);
        }

        [Test]
        public void ShouldReturnADeckWith13CopaCards()
        {
            var baralho = Util.Util.GetBaralho();
            var copas = baralho.Where(carta => carta.Naipe == Naipes.Copa);
            Assert.IsNotNull(copas);
            Assert.AreEqual(13, copas.Count());
        }

        [Test]
        public void ShouldReturnADeckWith13EspadasCards()
        {
            var baralho = Util.Util.GetBaralho();
            var espadas = baralho.Where(carta => carta.Naipe == Naipes.Espadas);
            Assert.IsNotNull(espadas);
            Assert.AreEqual(13, espadas.Count());
        }

        [Test]
        public void ShouldReturnADeckWith13OuroCards()
        {
            var baralho = Util.Util.GetBaralho();
            var ouro = baralho.Where(carta => carta.Naipe == Naipes.Ouro);
            Assert.IsNotNull(ouro);
            Assert.AreEqual(13, ouro.Count());
        }

        [Test]
        public void ShouldReturnADeckWith13PausCards()
        {
            var baralho = Util.Util.GetBaralho();
            var paus = baralho.Where(carta => carta.Naipe == Naipes.Paus);
            Assert.IsNotNull(paus);
            Assert.AreEqual(13, paus.Count());
        }
    }
}