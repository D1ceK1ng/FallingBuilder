using System.IO;
using UnityEngine;

public class GetterFilePath 
{
      public static string GetFilePath(string FolderName, string FileName = "")
    {
        string filePath;
        filePath = Path.Combine(Application.persistentDataPath, ("data/" + FolderName));
        if(FileName != "")
            filePath = Path.Combine(filePath, (FileName + ".txt"));
        return filePath;
    }

}
