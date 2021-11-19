using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDisplay : MonoBehaviour
{
    public float C;
    public float a;
    public float b;
    public float m;

    public GameObject renderObject;

    private Plant Plant;

    public void GenerateAndDisplayPlant() {
        var probabilities = new ProbabilityGraph(C, b, a, m);
        Plant = new PlantFactory().GenerateRandomPlant(probabilities);
        foreach (var branch in Plant.branches.ReturnArray())
        {
        }
        Texture2D plantTexture = new Texture2D(64, 64);
        for (int x = 0; x < 64; x++)
        {
            for (int y = 0; y < 50; y++)
            {
                plantTexture.SetPixel(x, y, Color.red);
            }
        }
        plantTexture.Apply();
        renderObject.GetComponent<MeshRenderer>().sharedMaterial.mainTexture = plantTexture;
    }

    public void Start() {
        this.GenerateAndDisplayPlant();
    }
}
