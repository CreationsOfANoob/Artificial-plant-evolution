using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDisplay : MonoBehaviour
{
    public float C;
    public float a;
    public float b;
    public float m;

    private Plant Plant;

    public void GenerateAndDisplayPlant() {
        var probabilities = new ProbabilityGraph(C, b, a, m);
        Plant = new PlantFactory().GenerateRandomPlant(probabilities);
        foreach (var branch in Plant.branches.ReturnArray())
        {
            Debug.DrawLine(branch.Origin.AsVec3(), branch.End.AsVec3());
        }
    }

    public void Start() {
        this.GenerateAndDisplayPlant();
    }
}
