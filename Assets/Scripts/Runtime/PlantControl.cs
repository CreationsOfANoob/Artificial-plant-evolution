using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour
{
    public List<Plant> plantList;
    public int startNumPlants = 16;

    // Start is called before the first frame update
    void Start()
    {
        initializePlants();
    }

    void initializePlants() {
        plantList = new List<Plant>();
        var factory = new PlantFactory();

        for (int i = 0; i < startNumPlants; i++)
        {
            plantList.Add(factory.GeneratePlantNoProbabilities(Genome.RandomGenome()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
