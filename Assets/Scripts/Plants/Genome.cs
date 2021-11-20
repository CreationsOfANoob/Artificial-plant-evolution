using System;
using UnityEngine;

public class Genome
{
    public static readonly int maxGenomeLength = 64;
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
}