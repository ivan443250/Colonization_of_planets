using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save(SaveData saveData, string saveFilename)
    {
        string filePath = Application.persistentDataPath + $"/{saveFilename}.dat";
        using (FileStream file = File.Create(filePath))
        {
            new BinaryFormatter().Serialize(file, saveData);
        }
    }

    public static SaveData Load(string saveFilename)
    {
        string filePath = Application.persistentDataPath + $"/{saveFilename}.dat";
        SaveData saveData;
        if (File.Exists(filePath) == false)
            return null;
        using (FileStream file = File.Open(filePath, FileMode.Open))
        {
            object loadData = new BinaryFormatter().Deserialize(file);
            saveData = (SaveData)loadData;
        }
        return saveData;
    }
}
