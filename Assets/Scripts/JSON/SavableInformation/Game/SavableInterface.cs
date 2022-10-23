using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class SavableInterface : ISavable
{
   public List<string> NamesOfItems;
   public SavableInterface()
   {
    
   }
    public SavableInterface(List<string> namesOfItems)
   {
     NamesOfItems = namesOfItems;
   }
}
