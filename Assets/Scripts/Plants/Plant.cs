using System.Collections;
using System.Collections.Generic;

public class Plant
{
    public Genome genome;
    public BranchArray branches;

    public Plant(Genome in_genome = null, BranchArray in_branches = null)
    {
        if (in_genome == null)
        {
            in_genome = new Genome();
        }

        if (in_branches == null)
        {
            in_branches = new BranchArray();
        }

        genome = in_genome;
        branches = in_branches;
    }
}

public class BranchArray
{
    public BranchArray() {

    }
}

public class Branch
{
    public Branch() {

    }
}
