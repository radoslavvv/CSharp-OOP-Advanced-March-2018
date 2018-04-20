using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class HeroInventoryTests
{
    private HeroInventory sut;

    [SetUp]
    public void TestUnit()
    {
        this.sut = new HeroInventory();
    }

    [Test]
    public void AddCommonItem()
    {
        var commonItem = new CommonItem("item", 0, 0, 0, 0, 0);

        this.sut.AddCommonItem(commonItem);

        Type classType = typeof(HeroInventory);

        var field = classType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void AddRecipeItem()
    {
        var recipeItem = new RecipeItem("item", 0, 0, 0, 0, 0, new List<string>());

        this.sut.AddRecipeItem(recipeItem);

        Type classType = typeof(HeroInventory);

        var field = classType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);
        //var field = classType.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public );
        //Assert.AreEqual(1, (ICollection)((Dictionary<string, IRecipe>)field.GetValue(this.sut)).Count;
        var collection = (Dictionary<string, IItem>)field.GetValue(this.sut);

        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void StrengthBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 10, 0, 0, 0, 0);

        sut.AddCommonItem(item);

        Assert.That(sut.TotalStrengthBonus, Is.EqualTo(10));
    }

    [Test]
    public void AgilityBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 0, 10, 0, 0, 0);

        sut.AddCommonItem(item);

        Assert.That(sut.TotalAgilityBonus, Is.EqualTo(10));
    }

    [Test]
    public void IntelligenceBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 0, 0, 10, 0, 0);

        sut.AddCommonItem(item);

        Assert.That(sut.TotalIntelligenceBonus, Is.EqualTo(10));
    }

    [Test]
    public void HitPointsBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 0, 0, 0, 10, 0);

        sut.AddCommonItem(item);

        Assert.That(sut.TotalHitPointsBonus, Is.EqualTo(10));
    }

    [Test]
    public void DamageBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 0, 0, 0, 0, 10);

        sut.AddCommonItem(item);

        Assert.That(sut.TotalDamageBonus, Is.EqualTo(10));
    }

}

