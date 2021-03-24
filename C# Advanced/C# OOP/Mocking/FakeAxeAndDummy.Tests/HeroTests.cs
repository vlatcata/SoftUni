using FakeAxeAndDummy;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void WhenTargetDies_ShouldReciveExperience()
    {
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(x => x.IsDead()).Returns(true);
        fakeTarget.Setup(x => x.GiveExperience()).Returns(20);

        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();

        Hero hero = new Hero("Pepi", fakeWeapon.Object);
        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(hero.Experience, fakeTarget.Object.GiveExperience());
    }
}