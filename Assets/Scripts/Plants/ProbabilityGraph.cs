using System;

public class ProbabilityGraph
{
    // Exponential function C * (x + b)^a + m
    private float C;
    private float a;
    private float m;
    private float b;

    public ProbabilityGraph(float fac = 1f, float offset = 0f, float exponent = 1, float constant = 0) {
        C = fac;
        a = exponent;
        m = constant;
        b = offset;
    }

    public float evaluate(float x) {
        return C * (float)Math.Pow((x + b), a) + m;
    }
}