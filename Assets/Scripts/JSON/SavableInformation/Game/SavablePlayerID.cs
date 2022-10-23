using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavablePlayerID : ISavable
{
   public string PlayerID;
   public SavablePlayerID(string playerID)
   {
    PlayerID = playerID;
   }
   public SavablePlayerID()
   {
    
   }
}
