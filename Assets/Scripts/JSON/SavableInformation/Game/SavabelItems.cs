using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavabelItems : ISavable
{
   public List<string> NamesOfItems;
   public SavabelItems(List<string> namesOfItems)
   {
    NamesOfItems = namesOfItems;
   }
   public SavabelItems()
   {
    
   }
}
