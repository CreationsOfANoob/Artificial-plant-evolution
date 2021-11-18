using UnityEngine;

public class Coord
{
    private float x;
    private float y;

    public Coord(float x = 0f, float y = 0f) {
        this.x = x;
        this.y = y;
    }

    public Vector3 AsVec3() {
        return new Vector3(x, y, 0f);
    }
}