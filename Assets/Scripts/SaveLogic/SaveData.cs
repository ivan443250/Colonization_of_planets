using System;

[Serializable]
public class SaveData
{
    public float[] Numbers;
    public string[] Lines;

    public SaveData(float[] numbers, string[] lines)
    {
        Numbers = numbers;
        Lines = lines;
    }
}
