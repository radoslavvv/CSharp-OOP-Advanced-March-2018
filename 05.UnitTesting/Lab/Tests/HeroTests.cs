using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class HeroTests
    {
        [Test]
        public void HeroGainsExperienceWhenTargetDies()
        {
            Mock<ITarget> target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(0);
            target.Setup(t => t.GiveExperience()).Returns(15);
            target.Setup(t => t.IsDead()).Returns(true);

            Mock<IWeapon> weapon = new Mock<IWeapon>();
            weapon.Setup(w => w.AttackPoints).Returns(25);
            weapon.Setup(w => w.DurabilityPoints).Returns(10);

            Hero hero = new Hero("Pesho", weapon.Object);

            hero.Attack(target.Object);

            Assert.That(hero.Experience, Is.EqualTo(15));
        }
    }
}
