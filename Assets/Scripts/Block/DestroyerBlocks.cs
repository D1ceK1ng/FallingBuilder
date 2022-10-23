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
    block.OnDestroy += Destroy;
  }
  private void Destroy(Block block)
  {
    _blocks.Remove(block);
    _blockCreator.CurrentBlocks.Remove(block);
  }
  private void OnDisable() 
  {
    _blocks.ForEach(e=>e.OnDestroy -= Destroy);
    _blockCreator.OnCreate -= AddBlock;
  }
}
