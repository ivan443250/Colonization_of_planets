using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void Save<T>(T saveData, string saveFilename) where T : class
    {
        string filePath = Application.persistentDataPath + $"/{saveFilename}.dat";
        using (FileStream file = File.Create(filePath))
        {
            new BinaryFormatter().Serialize(file, saveData);
        }
    }

    public static T Load<T>(string saveFilename) where T : class
    {
        string filePath = Application.persistentDataPath + $"/{saveFilename}.dat";

        if (File.Exists(filePath) == false)
            return null;

        T saveData;
        using (FileStream file = File.Open(filePath, FileMode.Open))
        {
            object loadData = new BinaryFormatter().Deserialize(file);
            saveData = (T)loadData;
        }
        return saveData;
    }

    public static void Delete(string saveFilename)
    {
        string filePath = Application.persistentDataPath + $"/{saveFilename}.dat";
        File.Delete(filePath);
    }
}
