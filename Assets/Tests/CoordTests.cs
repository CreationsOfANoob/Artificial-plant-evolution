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
}
