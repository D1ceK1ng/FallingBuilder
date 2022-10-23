using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetterMusicVolume 
{
   public float ReturnMusicVolume()
   {
        float volume = 1;
        SavableMusicSettings savableMusicSettings = Loader<SavableMusicSettings>.Load(new SavableMusicSettings());
        if (savableMusicSettings != null)
        {
            if (savableMusicSettings.MusicVolume != "")
            {
              volume = float.Parse(savableMusicSettings.MusicVolume);
            }
        }
        return volume;
   } 
}
