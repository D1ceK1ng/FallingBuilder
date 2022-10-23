using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class StarterNewGame : MonoBehaviour
{
    public static void StartNewGame()
    {
        Saver<SavableAbilities>.Save(new SavableAbilities());
        Saver<SavableCountOfSouls>.Save(new SavableCountOfSouls());
        Saver<SavableHealth>.Save(new SavableHealth());
        Saver<SavableMusicSettings>.Save(new SavableMusicSettings());
    }
    public void TryStartNewGame()
    {
       SavableHealth savableHealth = Loader<SavableHealth>.Load(new SavableHealth());
       if (savableHealth != null)
       {
         if (savableHealth.Health != "")
         {
            float health = float.Parse(savableHealth.Health);
            if (health <= 0)
            {
                StartNewGame();
            }
         }
       }
    }
}
