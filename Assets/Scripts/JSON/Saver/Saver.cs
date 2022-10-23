using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using System;
using System.Text;

public class Saver<T> where T : ISavable 
{

   private static string _dataPath = "DataPath";

   public static void Save(T data)
   {
        string dataPath = GetterFilePath.GetFilePath(_dataPath, $"{data}");
        string jsonData = JsonUtility.ToJson(data, true);
        byte[] byteData = Encoding.ASCII.GetBytes(jsonData);
        if (!Directory.Exists(Path.GetDirectoryName(dataPath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(dataPath));
        }
       File.WriteAllBytes(dataPath, byteData);
   }
}
