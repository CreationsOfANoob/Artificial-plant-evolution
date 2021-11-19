using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CoordTests
{
    [Test]
    public void ReturnVec3EmptyInit()
    {
        var foo = new Coord();
        Assert.AreEqual(foo.AsVec3(), new Vector3(0f, 0f, 0f));
    }

    [Test]
    public void ReturnVec3() {
        var foo = new Coord(1f, 1f);
        Assert.AreEqual(foo.AsVec3(), new Vector3(1f, 1f, 0f));
    }

    [Test]
    public void GetX() {
        var foo = new Coord(10f, 10f);
        Assert.AreEqual(foo.x, 10f);
    }

    [Test]
    public void GetY() {
        var foo = new Coord(10f, 10f);
        Assert.AreEqual(foo.y, 10f);
    }

    [Test]
    public void SquareRoot() {
        var foo = new Coord(3f, 4f);
        Assert.AreEqual(foo.length, 5f);
    }

    [Test]
    public void OrigoConstructor() {
        var foo = new Coord(0f);
        Assert.True(Coord.Compare(foo, Coord.Origo()));
    }

    [Test]
    public void LineFromAngleAndLengthConstructor() {
        var foo = new Coord(1f, 0f);
        Assert.True(Coord.Compare(foo, Coord.LengthAndAngle(0f, 1f)));
    }

    [Test]
    public void LineFromAngleAndLengthConstructorLong() {
        var foo = new Coord(2f, 0f);
        Assert.True(Coord.Compare(foo, Coord.LengthAndAngle(0f, 2f)));
    }

    [Test]
    public void LineFromAngleAndLengthConstructorRotated() {
        var foo = new Coord(0f, 1f);
        Assert.True(Coord.Compare(foo, Coord.LengthAndAngle(Mathf.PI / 2, 1f), -7));
    }

    [Test]
    public void ConstructWithOneArgument() {
        var foo = new Coord(10f);
        Assert.True(Coord.Compare(foo, new Coord(10f, 10f)));
    }

    [Test]
    public void MultiplyByFloatOperator() {
        var foo = new Coord(10f, 3f);
        Assert.True(Coord.Compare(foo * 2f, new Coord(20f, 6f)));
    }

    [Test]
    public void DivideByFloatOperator() {
        var foo = new Coord(10f, 3f);
        Assert.True(Coord.Compare(foo / 2f, new Coord(5f, 1.5f)));
    }


    [Test]
    public void AddCoordOperator() {
        var foo = new Coord(5f, 3f);
        Assert.True(Coord.Compare(foo + new Coord(10f, 10f), new Coord(15f, 13f)));
    }

    [Test]
    public void SubtractCoordOperator() {
        var foo = new Coord(5f, 3f);
        Assert.True(Coord.Compare(foo - new Coord(10f, 10f),new Coord(-5f, -7f)));
    }

    [Test]
    public void EqualsOperator() {
        var foo = new Coord(2f, 2f);
        Assert.True(Coord.Compare(foo, new Coord(2f, 2f)));
    }

    [Test]
    public void EqualsOperatorReturnFalse() {
        var foo = new Coord(5f, 3f);
        Assert.False(Coord.Compare(foo, new Coord(2f, 2f)));
    }
}
