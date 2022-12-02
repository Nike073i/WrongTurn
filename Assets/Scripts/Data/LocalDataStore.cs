using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LocalDataStore
{
    public static readonly string SaveFilePath = "/LocalData.dat";
    public void Save(LocalData data)
    {
        using var file = File.Create(Application.persistentDataPath + SaveFilePath);
        var binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, data);
    }

    public LocalData? Load()
    {
        var path = Application.persistentDataPath + SaveFilePath;
        if (File.Exists(path))
        {
            var bf = new BinaryFormatter();
            using var file = File.Open(path, FileMode.Open);
            var deserializeObject = bf.Deserialize(file);
            return deserializeObject is LocalData localData ? localData : null;
        }
        return null;
    }
}

