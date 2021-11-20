using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlantCreation
{
    [Test]
    public void PlantCreationReturnsPlant()
    {
        var result = new Plant();
        Assert.IsInstanceOf<Plant>(result);
    }

    [Test]
    public void PlantCreatedHasGenome() {
        var result = new Plant().genome;
        Assert.IsInstanceOf<PlantGenomeData>(result);
    }

    [Test]
    public void PlantCreatedHasBranches() {
        var result = new Plant().branches;
        Assert.IsInstanceOf<BranchArray>(result);
    }

}
