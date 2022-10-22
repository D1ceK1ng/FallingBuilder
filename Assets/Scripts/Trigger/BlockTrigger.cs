using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockTrigger : Trigger
{
   [SerializeField] private float _range;
   [SerializeField] private Block _block;
   private List<Block> _closestBlocks = new List<Block>();
   public event Action<List<Block>> OnFindManyBlocks;
   private void OnTriggerEnter2D(Collider2D other) 
   {
    other.TriggerEntity<HouseConstructionZone>(e=>
    {
        e.AddBlock(_block);
    });
    other.TriggerEntity<Block>(e=>
    {
        e.IsOnEarth = true;
    }
    );
    other.TriggerEntity<Land>(e=>_block.IsOnEarth = true);
   }
   public void FindClosestBlocks(List<Block> blocksInZone)
   {
      _closestBlocks.Clear();
      Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position,_range);
      foreach (var item in collider2Ds)
      {
        if (item.TryGetComponent<Block>(out Block block))
        {
           if(_closestBlocks.Contains(block) || blocksInZone.Contains(block) == false)
            {
                continue;
            }
            _closestBlocks.Add(block);

        }
      }
      if (_closestBlocks.Count >= 4)
      {
        OnFindManyBlocks?.Invoke(_closestBlocks);
      }
   }
}
