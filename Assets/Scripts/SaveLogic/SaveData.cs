using System;
using System.Collections.Generic;

[Serializable]
public class SaveData
{
    public List<float> Numbers;
    public List<string> Lines;

    public SaveData(List<string> lines)
    {
        Numbers = null;
        Lines = lines;
    }

    public SaveData(List<float> numbers, List<string> lines)
    {
        Numbers = numbers;
        Lines = lines;
    }
}
