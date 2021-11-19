using System;
using System.Collections;
using UnityEngine;

internal class PlantFactory
{
    public PlantFactory() {
    }

    internal Plant GenerateRandomPlant(ProbabilityGraph probabilities, int maxBranchDepth) {
        var finalBranches = new BranchArray();
        var oldLayerBranches = new BranchArray();
        var newLayerBranches = new BranchArray();

        var origin = Coord.Origo();
        var angle = 0f;

        newLayerBranches = EvaluateIfAddBranch(newLayerBranches, origin, angle); //Add Initial branch

        var branchDepth = 0;
        while (branchDepth < maxBranchDepth)
        {
            branchDepth++;
            finalBranches.AddBranches(oldLayerBranches);
            oldLayerBranches = newLayerBranches.Clone();
            newLayerBranches.Empty();

            foreach (var branch in oldLayerBranches.ReturnArray())
            {
                Debug.Log("added branch");

                origin = branch.End;
                angle = (float)Math.Atan2(branch.asVector.x, branch.asVector.y);
                newLayerBranches = EvaluateIfAddBranch(newLayerBranches, origin, angle);
            }
        }

        var plant = new Plant();
        plant.SetBranches(finalBranches);
        return plant;
    }

    private BranchArray EvaluateIfAddBranch(BranchArray branchArray, Coord origin, float angle) {
        angle += (UnityEngine.Random.value - 0.5f) * 0.1f; //randomize rotation
        branchArray.AddBranch(new Branch(origin, Coord.LengthAndAngle(angle + (Mathf.PI / 2f), 1f, origin)));
        Debug.Log(branchArray.ReturnArray());
        return branchArray;
    }
}