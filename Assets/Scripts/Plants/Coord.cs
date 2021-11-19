using System;
using UnityEngine;

public class Coord
{
    public float x { get; }
    public float y { get; }
    public float length { get { return Mathf.Sqrt(x * x + y * y); } }

    public Coord(float x = 0f, float? y = null) {
        if (!y.HasValue) { y = x; }
        this.x = x;
        this.y = (float)y;
    }

    public Vector3 AsVec3() {
        return new Vector3(x, y, 0f);
    }

    public static Coord operator +(Coord c1, Coord c2) {
        return new Coord(c1.x + c2.x, c1.y + c2.y);
    }

    public static Coord operator -(Coord c1, Coord c2) {
        return c1 + (c2 * -1f);
    }

    public static Coord operator *(Coord c1, float f) {
        return new Coord(c1.x * f, c1.y * f);
    }

    public static Coord operator /(Coord c1,  float f) {
        return c1 * (1 / f);
    }

    public static bool Compare(Coord c1, Coord c2, int? epsilonE = null) {
        if (epsilonE.HasValue)
        {
            var epsilon = Mathf.Pow(10, (float)epsilonE);
            if (Mathf.Abs(c1.x - c2.x) < epsilon && Mathf.Abs(c1.y - c2.y) < epsilon) { return true; }
        }
        else
        {
            if (c1.x == c2.x && c1.y == c2.y) { return true; }
        }
        return false;
    }

    public static Coord Origo() {
        return new Coord(0f);
    }

    public static Coord LengthAndAngle(float angle, float length, Coord offset = null) {
        if (offset == null) { offset = Origo(); }
        var coord = (new Coord(Mathf.Cos(angle) * length, Mathf.Sin(angle) * length)) + offset;
        return coord;
    }
}