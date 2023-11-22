using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem<T>
{
    private readonly string _filePath;

    public SaveSystem(string saveFilename) 
    {
        _filePath = Application.persistentDataPath + $"/{saveFilename}.dat";
    }

    public void Save(T saveData)
    {
        using (FileStream file = File.Create(_filePath))
        {
            new BinaryFormatter().Serialize(file, saveData);
        }
    }

    public T Load() 
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
