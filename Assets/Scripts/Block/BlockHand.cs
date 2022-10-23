using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHand : MonoBehaviour
{
   private Block _block;
   public void ChooseBlock(Block block)
   {
    ReselectBlock(_block);
    block.CanMove = true;
    _block = block;
   }
   public void ReselectBlock(Block block)
   {
    if (_block != null)
    {
        _block.CanMove = false;
    }
   }
   private void Update() 
   {
      if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
      {
        _block.BlockMovement.SpeedUp();
      }
      if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
      {
         _block.BlockMovement.SpeedDown();
      }
   }
}
