using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.Events;

public class DestroyerBlocks : MonoBehaviour
{
  [SerializeField] private BlockCreator _blockCreator;
  [SerializeField] private SorterBlocks _sorterBlocks;
  private List<Block> _blocks = new List<Block>();
  private List<Block> _selectedBlocks = new List<Block>();
  public List<Block> SelectedBlocks { get => _selectedBlocks; set => _selectedBlocks = value; }

    public event UnityAction OnIncreaseScores;
  private void Awake() 
  {
    _blockCreator.OnCreate += AddBlock;
    _sorterBlocks.OnRemove += RemoveBlocks;
    _blockCreator.OnSetCtraft += DestroyBlocks;
  }

  private void DestroyBlocks(Craft craft)
  {
      int currentBlocksCount = _blockCreator.CurrentBlocks.Count;
      List<Block> currentBlockList = new List<Block>();
      currentBlockList.AddRange(_blockCreator.CurrentBlocks);
      for (int i = 0; i < currentBlocksCount; i++)
      {
          var block = currentBlockList[i];
          RemoveCurrentBlock(block);
          block.DestroyBlock();
      }
  }

  private void RemoveBlocks(List<Block> blocks)
  {
    OnIncreaseScores?.Invoke();
    SelectedBlocks = blocks;
    if (blocks.All(e=>_blocks.Contains(e)))
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].DestroyBlock();
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
        _sorterBlocks.OnRemove -= RemoveBlocks;
    }
}
