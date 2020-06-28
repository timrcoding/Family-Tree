using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveGame
{
    public static void SaveData(ScoringSingleton ss)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameData";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(ss);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData loadData()
    {
        string path = Application.persistentDataPath + "/GameData";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("FILE NOT FOUND");
            return null;
        }
    } 
}
