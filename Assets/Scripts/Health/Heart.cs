using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Heart : MonoBehaviour
{
    [SerializeField] private Image _icon;
   public void TakeDamage()
   {
    _icon.color = Color.white;
   }
}
