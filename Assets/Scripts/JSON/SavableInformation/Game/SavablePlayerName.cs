using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavablePlayerName : ISavable
{
   public string PlayerName;
   public SavablePlayerName()
   {
    
   }
   public SavablePlayerName(string playerName)
   {
    PlayerName = playerName;
   }
}
