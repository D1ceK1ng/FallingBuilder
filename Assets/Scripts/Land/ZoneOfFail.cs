using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneOfFail : MonoBehaviour
{
   [SerializeField] private Tasks _tasks;
   public void LoseHeart()=> _tasks.LoseHeart();   
}
