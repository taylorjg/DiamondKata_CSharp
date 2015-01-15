using DiamondLib;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    internal class UnitTests
    {
        [Test]
        public void A()
        {
            var actual = Diamond.GenerateLines('A');
            Assert.That(actual, Is.EqualTo(new[]
            {
                "A"
            }));
        }

        [Test]
        public void B()
        {
            var actual = Diamond.GenerateLines('B');
            Assert.That(actual, Is.EqualTo(new[]
            {
                " A ",
                "B B",
                " A "
            }));
        }

        [Test]
        public void C()
        {
            var actual = Diamond.GenerateLines('C');
            Assert.That(actual, Is.EqualTo(new[]
            {
                "  A  ",
                " B B ",
                "C   C",
                " B B ",
                "  A  "
            }));
        }
    }
}
