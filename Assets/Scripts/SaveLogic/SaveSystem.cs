using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem
{
    private readonly string _filePath;

    public SaveSystem(string savedFilename) 
    {
        _filePath = Application.persistentDataPath + $"/{savedFilename}.dat";
    }

    public void Save<T>(T saveData) where T : ISaveData
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, saveData);
        }
    }

    public T Load<T>() where T : ISaveData
    {
        T saveData;
        using (FileStream file = File.Open(_filePath, FileMode.Open))
        {
            object loadData = new BinaryFormatter().Deserialize(file);
            saveData = (T)loadData;
        }
        return saveData;
    }
}
