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

    public void SetBranches(BranchArray branches) {
        this.branches = branches;
    }

    public void AddBranch(Coord p1, Coord p2) {
        branches.AddBranch(new Branch(p1, p2));
    }
}

public class BranchArray
{
    private List<Branch> branches;

    public void Empty() {
        branches = new List<Branch>();
    }

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

    public void AddBranches(BranchArray branches) {
        foreach (var branch in branches.ReturnArray())
        {
            this.branches.Add(branch);
        }
    }

    internal IEnumerable<Branch> ReturnArray() {
        return branches;
    }

    internal BranchArray Clone() {
        var newBranchList = new List<Branch>();
        foreach (var branch in this.branches)
        {
            newBranchList.Add(branch.Clone());
        }
        var newBranchArrayObject = new BranchArray(newBranchList);
        return newBranchArrayObject;
    }
}

public class Branch : ICloneable
{
    internal Coord Origin;
    internal Coord End;

    internal Coord asVector { get
        {
            return End - Origin;
        }
    }

    public Branch(Coord From, Coord To) {
        Origin = From;
        End = To;
    }

    public Branch Clone() {
        return (Branch)this.MemberwiseClone();
    }

    object ICloneable.Clone() {
        return Clone();
    }
}
