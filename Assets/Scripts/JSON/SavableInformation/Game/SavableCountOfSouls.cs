using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavableCountOfSouls : ISavable
{
  public string CountOfSouls;
  public SavableCountOfSouls(string countOfSouls)
  {
    CountOfSouls = countOfSouls;
  }
  public SavableCountOfSouls()
  {
    
  }

}
