using System.Collections.Generic;

internal class PlantGenomeProperties
{
    private Genome genome;
    public int numBranchLayers { get { return (int)genome.geneToFloat(0, 0f, 6f); } }
    public float initialBranchLength { get { return genome.geneToFloat(1, 0.1f, 1f); } }

    public PlantGenomeProperties(Genome genome) {
        this.genome = genome;
    }

    public LayerProperties getLayerProperties(int i) {
        var gI = 16 + (i * 5); //initial geneIndex
        return new LayerProperties((int)genome.geneToFloat(gI, 0f, 4f), genome.geneToFloat(gI + 1, 0.1f, 1f), genome.geneToFloat(gI + 2, 0.1f, 1f), genome.geneToFloat(gI + 3, 0.1f, 2f), genome.geneToFloat(gI + 1, 0f, 1f));
    }
}

internal class LayerProperties
{
    public int numBranches { get; }
    public float branchLength { get; }
    public float branchSpread { get; }
    public float upFactor { get; }



    public LayerProperties(int num, float length, float width, float spread, float up) {
        numBranches = num;
        branchLength = length;
        branchSpread = spread;
        upFactor = up;
    }
}