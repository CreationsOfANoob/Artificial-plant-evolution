using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProbabilityGraphTests
{
    [Test]
    public void A1()
    {
        var foo = new ProbabilityGraph(1f, 0f, 1.0f, 0f);
        Assert.AreEqual(foo.evaluate(0f), 0f);
    }

    [Test]
    public void A2() {
        var foo = new ProbabilityGraph(1f, 0f, 1.0f, 0f);
        Assert.AreEqual(foo.evaluate(1f), 1f);
    }

    [Test]
    public void A3() {
        var foo = new ProbabilityGraph(1f, 0f, 1.0f, 0f);
        Assert.AreEqual(foo.evaluate(-1f), -1f);
    }

    [Test]
    public void B1() {
        var foo = new ProbabilityGraph(1f, 0f, 2.0f, 0f);
        Assert.AreEqual(foo.evaluate(0f), 0f);
    }

    [Test]
    public void B2() {
        var foo = new ProbabilityGraph(1f, 0f, 2.0f, 0f);
        Assert.AreEqual(foo.evaluate(2f), 4f);
    }

    [Test]
    public void B3() {
        var foo = new ProbabilityGraph(1f, 0f, 2.0f, 0f);
        Assert.AreEqual(foo.evaluate(-2f), 4f);
    }
}
