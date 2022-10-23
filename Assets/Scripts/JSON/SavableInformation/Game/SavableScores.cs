using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableScores : ISavable
{
   public string CountOfScores;
   public SavableScores(string countOfScores)
   {
    CountOfScores = countOfScores;
   }
   public SavableScores()
   {
    
   }
}
