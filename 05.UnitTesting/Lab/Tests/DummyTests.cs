using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class DummyTests
    {
        private IWeapon axe;
        private ITarget dummy;

        private const int DurabilityPoints = 15;
        private const int AttackPoints = 5;
        private const int DummyExperience = 20;

        [SetUp]
        public void DummyTest()
        {
            this.axe = new Axe(AttackPoints, DurabilityPoints);
        }

        public void CreateDummy(int dummyHealth)
        {
            this.dummy = new Dummy(dummyHealth, DummyExperience);
        }

        [Test]
        public void DummyLosesHealthAfterGettingAttacked()
        {
            int dummyHealth = 10;
            CreateDummy(dummyHealth);

            axe.Attack(dummy);

            Assert.That(dummy.Health, Is.EqualTo(5), "Dummy health doesn't change after getting attacked!");
        }

        [Test]
        public void AliveDummyCanGiveExperience()
        {
            int dummyHealth = 10;
            CreateDummy(dummyHealth);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            int dummyHealth = 0;
            CreateDummy(dummyHealth);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCannotGiveExperience()
        {
            int dummyHealth = 0;
            CreateDummy(dummyHealth);

            Assert.That(dummy.GiveExperience(), Is.EqualTo(20));
        }   
    }
}
