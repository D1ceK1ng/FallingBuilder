using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableMoney : ISavable
{
   public string Money;
   public SavableMoney(string money)
   {
        Money = money;
   }
   public SavableMoney()
   {
    
   }
}
