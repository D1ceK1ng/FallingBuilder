using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class SavableAbilities : ISavable
{
   public List<string> NamesOfAbilities;
 
    public SavableAbilities()
    {
        
    }
    public SavableAbilities(List<string> namesOfAbilities)
    {
        NamesOfAbilities = namesOfAbilities;
    }
}
