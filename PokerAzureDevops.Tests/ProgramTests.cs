using NUnit.Framework;
using PokerAzureDevops.Domain;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private PokerDomain pokerDomain;

        [SetUp]
        public void Setup()
        {
            pokerDomain = new PokerDomain();
        }

        [Test]
        public void ShouldReturnLetsPlayPokerString()
        {
            var str = pokerDomain.GetPokerString();
            Assert.AreEqual("Let's play poker!", str);
        }
    }
}