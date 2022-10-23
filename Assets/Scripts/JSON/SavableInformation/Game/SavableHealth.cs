using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

public class SavableHealth : ISavable
{
   public string Health;
   public SavableHealth(float health)
   {
        Health = health.ToString();
   }
   public SavableHealth()
   {
   }
}
