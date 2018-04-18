using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Tests
{
    private ISimpleOrderedBag<string> names;

    [SetUp]
    public void SetUp()
    {
        this.names = new SimpleSortedList<string>();
    }

    [Test]
    public void TestEmptyCtor()
    {
        this.names = new SimpleSortedList<string>();
        Assert.AreEqual(this.names.Capacity, 16);
        Assert.AreEqual(this.names.Size, 0);
    }

    [Test]
    public void TestCtorWithInitialCapacity()
    {
        this.names = new SimpleSortedList<string>(20);
        Assert.AreEqual(this.names.Capacity, 20);
        Assert.AreEqual(this.names.Size, 0);
    }

    [Test]
    public void TestCtorWithAllParams()
    {
        this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
        Assert.AreEqual(this.names.Capacity, 30);
        Assert.AreEqual(this.names.Size, 0);
    }
    [Test]
    public void TestCtorWithInitialComparer()
    {
        this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
        Assert.AreEqual(this.names.Capacity, 16);
        Assert.AreEqual(this.names.Size, 0);
    }

    [Test]
    public void TestAddIncreasesSize()
    {
        this.names.Add("Person");
        Assert.AreEqual(1, this.names.Size);
    }

    [Test]
    public void TestAddNullThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => this.names.Add(null));
    }

    [Test]
    public void TestAddUnsortedDataIsHeldSorted()
    {
        List<string> names = new List<string> { "Rosen", "Georgi", "Balkan" };

        this.names.AddAll(names);

        names.Sort();

        Assert.That(names, Is.EquivalentTo(this.names));
    }

    [Test]
    public void TestAddingMoreThanInitialCapacity()
    {
        for (int i = 0; i < 17; i++)
        {
            this.names.Add("Person");
        }

        Assert.That(this.names.Capacity, !Is.EqualTo(16));
    }

    [Test]
    public void TestAddingAllFromCollectionIncreasesSize()
    {
        List<string> names = new List<string> { "Person1", "Person2" };

        this.names.AddAll(names);

        Assert.That(this.names.Size, Is.EqualTo(2));
    }

    [Test]
    public void TestAddingAllFromNullThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => this.names.AddAll(null));
    }

    [Test]
    public void TestAddAllKeepsSorted()
    {
        List<string> names = new List<string> { "Rosen", "Georgi", "Balkan" };

        this.names.AddAll(names);

        names.Sort();

        Assert.That(names, Is.EquivalentTo(this.names));
    }

    [Test]
    public void TestRemoveValidElementDecreasesSize()
    {
        this.names.Add("Person");
        this.names.Remove("Person");

        Assert.That(this.names.Size, Is.EqualTo(0));
    }

    [Test]
    public void TestRemoveValidElementRemovesSelectedOne()
    {
        this.names.Add("Ivan");
        this.names.Add("Vasko");

        this.names.Remove("Ivan");

        Assert.That(this.names.FirstOrDefault(n => n == "Ivan"), Is.Null);
    }

    [Test]
    public void TestRemovingNullThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => this.names.Remove(null));
    }

    [Test]
    public void TestJoinWithNull()
    {
        Assert.Throws<ArgumentNullException>(() => this.names.JoinWith(null));
    }

    [Test]
    public void TestJoinWorksFine()
    {
        List<string> namesToAdd = new List<string>() { "Person1", "Person2" };

        this.names.AddAll(namesToAdd);

        string result = this.names.JoinWith(", ");

        string namesToAddJoined = string.Join(", ", namesToAdd);

        Assert.That(result, Is.EqualTo(namesToAddJoined));
    }
}

