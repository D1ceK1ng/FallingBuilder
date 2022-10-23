using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;
using System.Text;

public class Loader<T> where T : ISavable 
{
    
    private static string _dataPath = "DataPath";
    public static T Load(T file)
    {
        string dataPath =GetterFilePath.GetFilePath(_dataPath, $"{file}");
        if (!Directory.Exists(Path.GetDirectoryName(dataPath)))
        {
            return default(T);
        }
        byte[] jsonDataAsBytes = null;
        try
        {
            jsonDataAsBytes = File.ReadAllBytes(dataPath);
        }
        catch (Exception e)
        {
            Debug.LogWarning("Error: " + e.Message);
            return default(T);
        }
        if (jsonDataAsBytes == null)
        {
            return default(T);
        }
        string jsonData;
        jsonData = Encoding.ASCII.GetString(jsonDataAsBytes);
        T returnedData = JsonUtility.FromJson<T>(jsonData);
        return (T)Convert.ChangeType(returnedData, typeof(T));
    }

}
