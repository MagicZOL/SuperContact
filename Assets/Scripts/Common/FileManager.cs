using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager<T> where T : struct
{
    public static T? Load(string fileName)
    {
        T? items = null;

        string filePath = $"{Application.persistentDataPath}\\{fileName}";

        if (File.Exists(filePath))
        {
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string jsonStr = streamReader.ReadToEnd();
                items = JsonUtility.FromJson<T>(jsonStr);
            }
        }
        return items;
    }

    public static void Save(T items, string fileName)
    {
        string filePath = $"{Application.persistentDataPath}\\{fileName}";

        using (StreamWriter streamWriter = new StreamWriter(filePath))
        {
            string jsonStr = JsonUtility.ToJson(items);
            streamWriter.Write(jsonStr);
        }
    }
}