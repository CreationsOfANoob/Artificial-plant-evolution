using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDisplay : MonoBehaviour
{
    public float C;
    public float a;
    public float b;
    public float m;

    public int pixels = 64;

    public GameObject renderObject;

    private Plant Plant;

    public void GenerateAndDisplayPlant() {
        var probabilities = new ProbabilityGraph(C, b, a, m);
        Plant = new PlantFactory().GenerateRandomPlant(probabilities, 10);

        var pixelScale = ((float)pixels) / 10f;
        var dimensions = new Coord(pixels);
        var midPoint = new Coord(dimensions.x / 2f, 0f);

        Texture2D plantTexture = new Texture2D((int)dimensions.x, (int)dimensions.y);

        foreach (var branch in Plant.branches.ReturnArray())
        {
            Coord start = branch.Origin * pixelScale + midPoint;
            Coord end = branch.End * pixelScale + midPoint;
            plantTexture = DrawFunctions.DrawLine(plantTexture, start, end, Color.black);
        }

        plantTexture.Apply();
        renderObject.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = plantTexture;
    }

    public void Start() {
        this.GenerateAndDisplayPlant();
    }
}
