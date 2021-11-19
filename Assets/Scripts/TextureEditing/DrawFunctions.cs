using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFunctions
{
    public static Texture2D DrawLine(Texture2D texture2D, Coord start, Coord end, Color color) {
        for (int x = 0; x < texture2D.width; x++)
        {
            for (int y = 0; y < texture2D.height; y++)
            {
                if (ApproximateOnLine(new Coord(x, y), start, end, 0.02f))
                {
                    texture2D.SetPixel(x, y, color);
                }
            }
        }
        return texture2D;
    }

    private static bool ApproximateOnLine(Coord c, Coord a, Coord b, float epsilon) {
        var ca = (c - a).length;
        var cb = (c - b).length;
        var ab = (a - b).length;

        return Mathf.Abs(ca + cb - ab) <= epsilon;
    }
}
