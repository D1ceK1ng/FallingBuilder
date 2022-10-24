using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlotOfCraft : MonoBehaviour
{
   [SerializeField] private Image _icon;
   [SerializeField] private Block _block;
   private TypeOfBlock _typeOfBlock;
   public TypeOfBlock TypeOfBlock { get => _typeOfBlock; set => _typeOfBlock = value; }
   public void SetTypeOfBlock(TypeOfBlock typeOfBlock) 
   {
    _icon.sprite = _block.ReturnSprite(typeOfBlock);
    TypeOfBlock = typeOfBlock;
   }
}
