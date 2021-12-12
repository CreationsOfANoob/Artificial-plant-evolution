using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GenomeTests
{
    [Test]
    public void GenomeGetGene()
    {
        var foo = new Genome("aabc");
        Assert.AreEqual(foo.Gene(0), "aa");
    }

    [Test]
    public void GenomeGetGene2() {
        var foo = new Genome("aabc");
        Assert.AreEqual(foo.Gene(1), "bc");
    }

    [Test]
    public void GenomeGetgeneAsFloat1() {
        var foo = new Genome("00");
        Assert.AreEqual(foo.geneToFloat(0, 0f, 1f), 0f);
    }

    [Test]
    public void GenomeGetgeneAsFloatSecondGene() {
        var foo = new Genome("ff00");
        Assert.AreEqual(foo.geneToFloat(1, 0f, 1f), 0f);
    }

    [Test]
    public void GenomeGetgeneAsFloatSecondGeneMiddleVal() {
        var foo = new Genome("ff80");
        Assert.AreEqual(foo.geneToFloat(1, 0f, 255f), 128f);
    }

    [Test]
    public void GenomeGetgeneAsFloatSecondGeneFalseVal() {
        var foo = new Genome("ff81");
        Assert.AreNotEqual(foo.geneToFloat(1, 0f, 255f), 128f);
    }

    [Test]
    public void GenomeGetgeneAsFloatOtherValue() {
        var foo = new Genome("ff00");
        Assert.AreEqual(foo.geneToFloat(0, 0f, 1f), 1f);
    }

    [Test]
    public void GenomeGetgeneAsFloatOtherRange() {
        var foo = new Genome("ff00");
        Assert.AreEqual(foo.geneToFloat(0, 0f, 2f), 2f);
    }

    [Test]
    public void GenomeGetgeneAsFloatOffsetRange() {
        var foo = new Genome("ff00");
        Assert.AreEqual(foo.geneToFloat(0, -1f, 1f), 1f);
    }
}
