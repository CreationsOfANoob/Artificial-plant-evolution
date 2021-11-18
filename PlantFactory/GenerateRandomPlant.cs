public class GenerateRandomPlant : Plant
{
    private ProbabilityGraph probabilities;

    public GenerateRandomPlant(ProbabilityGraph probabilities) {
        this.probabilities = probabilities;
    }
}
