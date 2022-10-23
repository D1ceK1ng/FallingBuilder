using UnityEngine;
using System;
[Serializable]

public class SavableMusicSettings : ISavable, ISavableSettings
{
   public string MusicVolume;
   public SavableMusicSettings()
   {
      
   }
   public SavableMusicSettings(float musicVolume)
   {
      MusicVolume = musicVolume.ToString();
   }
}
