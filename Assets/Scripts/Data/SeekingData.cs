using System;
using UnityEngine;

[Serializable]
public class SeekingData
{
    public string target;

    public SeekingData(string target)
    {
        this.target = target;
    }
}
