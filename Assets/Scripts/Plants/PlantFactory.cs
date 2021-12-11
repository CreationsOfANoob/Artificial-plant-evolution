using System;
using System.Collections;
using UnityEngine;

internal class PlantFactory
{
    public PlantFactory() {
    }

    internal Plant GeneratePlantNoProbabilities(Genome genome) {
        //Genome:
        //16 genes for properties
        //for each branch layer, 5 genes: number 0-4, length, widthPercent 0.1f-1f, spreading 0.1f-0.9f, up-factor 0f-1f,
        var genomeData = new PlantGenomeProperties(genome);

        var finalBranches = new BranchArray();
        var oldLayerBranches = new BranchArray();
        var newLayerBranches = new BranchArray();

        var origin = Coord.Origo();
        var angle = 0f;

        var branchDepth = 0;
        while (branchDepth < genomeData.numBranchLayers)
        {
            finalBranches.AddBranches(oldLayerBranches);
            oldLayerBranches = newLayerBranches.Clone();
            newLayerBranches.Empty();

            var layerProperties = genomeData.getLayerProperties(branchDepth);
            if (layerProperties.numBranches == 0)
            {
                break;
            }
            else
            {
                foreach (var branch in oldLayerBranches.ReturnArray())
                {
                    origin = branch.End;
                    angle = (float)Math.Atan2(branch.asVector.x, branch.asVector.y);

                    for (int branchN = 0; branchN < layerProperties.numBranches; branchN++)
                    {
                        newLayerBranches.AddBranch(new Branch(origin, Coord.LengthAndAngle(angle + (Mathf.PI / 2f), 1f, origin)));
                    }
                }

            }

            branchDepth++;
        }

        return new Plant();
    }

    internal Plant GenerateRandomPlant(ProbabilityGraph probabilities, int maxBranchDepth) {
        // Create genome
        var genome = Genome.RandomGenome();
        var variables = new ProbabilityPlantGenomeData(genome);

        // Setup branch generation
        var finalBranches = new BranchArray();
        var oldLayerBranches = new BranchArray();
        var newLayerBranches = new BranchArray();

        var origin = Coord.Origo();
        var angle = 0f;

        EvaluateIfAddBranch(newLayerBranches, origin, angle, 0); //Add Initial branch

        var branchDepth = 0;
        while (branchDepth < maxBranchDepth)
        {
            branchDepth++;
            finalBranches.AddBranches(oldLayerBranches);
            oldLayerBranches = newLayerBranches.Clone();
            newLayerBranches.Empty();

            foreach (var branch in oldLayerBranches.ReturnArray())
            {
                origin = branch.End;
                angle = (float)Math.Atan2(branch.asVector.x, branch.asVector.y);
                var lBefore = 1;
                var lAfter = 0;
                while (lBefore != lAfter)
                {
                    lBefore = newLayerBranches.ReturnArray().Count;
                    EvaluateIfAddBranch(newLayerBranches, origin, angle, branchDepth);
                    lAfter = newLayerBranches.ReturnArray().Count;
                }
            }
        }

        // Create plant and add data
        var plant = new Plant(Genome.RandomGenome());
        plant.SetBranches(finalBranches);
        return plant;
    }

    private void EvaluateIfAddBranch(BranchArray branchArray, Coord origin, float angle, int branchDepth) {
        angle += (UnityEngine.Random.value - 0.5f) * 2f; //randomize rotation
        if (UnityEngine.Random.value < 0.5 || branchDepth == 0)
        {
            branchArray.AddBranch(new Branch(origin, Coord.LengthAndAngle(angle + (Mathf.PI / 2f), 1f, origin)));
        }
    }
}