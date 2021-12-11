using System.Collections.Generic;

internal class PlantGenomeProperties
{
    private Genome genome;
    public int numBranchLayers { get { return (int)genome.geneToFloat(0, 0f, 4f); } }

    public PlantGenomeProperties(Genome genome) {
        this.genome = genome;
    }

    public LayerProperties getLayerProperties(int i) {
        var gI = 16 + i; //initial geneIndex
        return new LayerProperties((int)genome.geneToFloat(gI, 0f, 4f), genome.geneToFloat(gI + 1, 0.1f, 1f));
    }
}

internal class LayerProperties
{
    public int numBranches { get; }
    public float branchLength { get; }

    public LayerProperties(int num, float length) {
        numBranches = num;
        branchLength = length;
    }
}