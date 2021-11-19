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

        var plant = new Plant();
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