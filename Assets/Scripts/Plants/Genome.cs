using System;
using UnityEngine;

public class Genome
{
    // Genome is a hexadecimal string

    public static readonly int maxGenomeLength = 100;
    public static readonly int geneLength = 2;

    public static string empty { get { var data = ""; for (int i = 0; i < maxGenomeLength; i++) { data += "0"; } return data; } }

    private string data;

    public Genome(string data = null) {
        if (data == null) { data = empty; }
        this.data = data;
    }

    public static Genome RandomGenome() {
        var data = string.Empty;
        int num;
        for (int i = 0; i < maxGenomeLength; i++)
        {
            num = (int)(UnityEngine.Random.value * 16f);
            data += num.ToString("x1"); // Add a random hexadecimal digit
        }
        var genome = new Genome(data);
        return genome;
    }

    public string Gene(int v) {
        return data.Substring(v * geneLength, geneLength);
    }

    public float geneToFloat(int i, float from, float to) {
        // Parse gene (00- ff) as int and convert to float with range from - to
        var hex = Gene(i);
        var intVal = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        var fltVal = ((float)intVal / 255f) * (to - from) + from;
        Debug.Log(fltVal);
        return fltVal;
    }
}