using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public List<int>[] IntNumbers;
    public List<float>[] FloatNumbers;
    public List<string>[] Lines;

    public SaveData()
    {
        IntNumbers = null;
        FloatNumbers = null;
        Lines = null;
    }

    public SaveData(List<string>[] lines)
    {
        IntNumbers = null;
        FloatNumbers = null;
        Lines = lines;
    }

    public SaveData(List<int>[] intNumbers, List<string>[] lines)
    {
        IntNumbers = intNumbers;
        FloatNumbers = null;
        Lines = lines;
    }

    public SaveData(List<int>[] intNumbers, List<float>[] floatNumbers, List<string>[] lines)
    {
        IntNumbers = intNumbers;
        FloatNumbers = floatNumbers;
        Lines = lines;
    }
}
