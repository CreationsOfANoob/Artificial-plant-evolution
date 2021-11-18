using System;
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

    public void AddBranch((float, float, float) p1, (float, float, float) p2) {
        branches.AddBranch(new Branch(new Coord(), new Coord()));
    }
}

public class BranchArray
{
    private List<Branch> branches;

    public BranchArray(List<Branch> branches = null) {
        if (branches == null)
        {
            branches = new List<Branch>();
        }
        this.branches = branches;
    }

    public void AddBranch(Branch branch) {
        branches.Add(branch);
    }

    internal IEnumerable<Branch> ReturnArray() {
        return branches;
    }
}

public class Branch
{
    internal Coord Origin;
    internal Coord End;

    public Branch(Coord From, Coord To) {
        Origin = From;
        End = To;
    }
}
