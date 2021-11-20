using System;

public class PlantGenomeData
{
    private Genome genome;
    public ProbabilityGraph branchChance { get { return ProbabilityGraphFromGenome(0); } }

    private ProbabilityGraph ProbabilityGraphFromGenome(int geneStartIndex) {
        // Construct probability graph from gene sequence as floats
        var C = genome.geneToFloat(geneStartIndex,-1f, 1f);
        var a = genome.geneToFloat(geneStartIndex + 1, -1f, 1f);
        var b = genome.geneToFloat(geneStartIndex + 2, -1f, 1f);
        var m = genome.geneToFloat(geneStartIndex + 3, -1f, 1f);

        return new ProbabilityGraph(C, b, a, m);
    }

    public PlantGenomeData(Genome genome) {
        this.genome = genome;
    }
}