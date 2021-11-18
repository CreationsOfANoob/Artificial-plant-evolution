using System;
using System.Collections;

internal class PlantFactory
{
    public PlantFactory() {
    }

    internal Plant GenerateRandomPlant(ProbabilityGraph probabilities) {
        var plant = new Plant();
        plant.AddBranch((0f, 0f,0f), (0f,1f,0f));
        return plant;
    }
}