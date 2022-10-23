using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockTrigger : Trigger
{
   [SerializeField] private float _range;
   [SerializeField] private Block _block;
   private List<Block> _closestBlocks = new List<Block>();
   private BlockHand _blockHand;
   private void Awake() 
   {
    _blockHand = FindObjectOfType<BlockHand>();
    _blockHand.ChooseBlock(_block);
   }
   private void OnTriggerEnter2D(Collider2D other) 
   {
    other.TriggerEntity<HouseConstructionZone>(e=>
    {
        e.AddBlock(_block);
    });
   }
   private void OnCollisionEnter2D(Collision2D other) 
   {
      other.collider.TriggerEntity<Block>(e=>
      {
        if(Mathf.Round(_block.transform.position.x) ==Mathf.Round(e.transform.position.x))
        {
         e.Land();
        }
      });
     other.collider.TriggerEntity<Land>(e=> _block.Land());
   }

}
