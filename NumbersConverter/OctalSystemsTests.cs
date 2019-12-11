using System;
using NUnit.Framework;

namespace NumbersConverter
{
    [TestFixture]
    class OctalSystemsTests
    {
        [Test]
        public void Test1()
        {
            OctalSystems octalSystems = new OctalSystems("1");
            string result = octalSystems.octalToDecimal();
            Assert.That(result, Is.EqualTo("1"));
        }
        [Test]
        public void Test8()
        {
            OctalSystems octalSystems = new OctalSystems("10");
            string result = octalSystems.octalToDecimal();
            Assert.That(result, Is.EqualTo("8"));
        }
        [Test]
        public void Test14()
        {
            OctalSystems octalSystems = new OctalSystems("5,75");
            string result = octalSystems.octalToDecimal();
            Assert.That(result, Is.EqualTo("5,95"));
        }
    }
}
