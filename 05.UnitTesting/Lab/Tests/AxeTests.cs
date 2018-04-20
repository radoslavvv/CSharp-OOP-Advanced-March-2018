using NUnit.Framework;
using System;

namespace Tests
{
    public class AxeTests
    {
        private Axe axe;
        private Dummy dummy;

        private const int AttackPoints = 5;
        private const int DurabilityPoints = 15;

        private const int DummyHealth = 10;
        private const int DummyExperience = 20;

        [SetUp]
        public void AxeTest()
        {
            this.axe = new Axe(AttackPoints, DurabilityPoints);
            this.dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLoosesDurabilityAfterAttack()
        {
            this.axe.Attack(dummy);

            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(14), "Axe durability doesn't change after attack is made!");
        }
    }
}
