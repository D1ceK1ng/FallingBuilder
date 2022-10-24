using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReseterGame : MonoBehaviour
{
   public void ResetData()
   {
    Saver<SavableMoney>.Save(new SavableMoney());
    Saver<SavablePlayerID>.Save(new SavablePlayerID());
    Saver<SavableMusicSettings>.Save(new SavableMusicSettings());
    Saver<SavablePlayerName>.Save(new SavablePlayerName());
    Saver<SavableScores>.Save(new SavableScores());
   }
   
}
