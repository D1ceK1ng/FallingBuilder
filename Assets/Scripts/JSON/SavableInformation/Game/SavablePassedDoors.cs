using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]

public class SavablePassedDoors : ISavable
{
   public List<string> NamesOfDoors;
   public SavablePassedDoors()
   {
    
   }
    public SavablePassedDoors(List<string> namesOfDoors)
   {
     NamesOfDoors = namesOfDoors;
   }
}
