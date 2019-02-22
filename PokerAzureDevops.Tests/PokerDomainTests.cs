using NUnit.Framework;
using PokerAzureDevops.Domain;

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
            Assert.AreEqual(5, cartas.Count);
        }
    }
}