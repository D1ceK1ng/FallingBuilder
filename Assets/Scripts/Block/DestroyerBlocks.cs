using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DestroyerBlocks : MonoBehaviour
{
  [SerializeField] private BlockCreator _blockCreator;
  [SerializeField] private SorterBlocks _sorterBlocks;
  private List<Block> _blocks = new List<Block>();
  private void Awake() 
  {
    _blockCreator.OnCreate += AddBlock;
    _sorterBlocks.OnRemove += RemoveBlocks;
    _blockCreator.OnSetCtraft += DestroyBlocks;
  }

  private void DestroyBlocks(Craft craft)
  {
      Debug.Log("hueta");
      int currentBlocksCount = _blockCreator.CurrentBlocks.Count;
      List<Block> currentBlockList = new List<Block>();
      currentBlockList.AddRange(_blockCreator.CurrentBlocks);
      for (int i = 0; i < currentBlocksCount; i++)
      {
          var block = currentBlockList[i];
          RemoveCurrentBlock(block);
          block.ChangeColor();
      }
  }

  private void RemoveBlocks(List<Block> blocks)
  {
    if (blocks.All(e=>_blocks.Contains(e)))
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].ChangeColor();
            
        }
    }
  }
  private void AddBlock(Block block)
  {
    _blocks.Add(block);
    block.OnDestroy += RemoveCurrentBlock;
  }
  private void RemoveCurrentBlock(Block block)
  {
    _blocks.Remove(block);
    _blockCreator.CurrentBlocks.Remove(block);
  }
  private void OnDisable() 
  {
        _blocks.ForEach(e=>e.OnDestroy -= RemoveCurrentBlock);
        _blockCreator.OnCreate -= AddBlock;
        _blockCreator.OnSetCtraft -= DestroyBlocks;
    }
}
