using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DestroyerBlocks : MonoBehaviour
{
  [SerializeField] private BlockCreator _blockCreator;
  [SerializeField] private CheckerBlocks _checkerBlocks;
  private List<Block> _blocks = new List<Block>();
  private void Awake() 
  {
    _blockCreator.OnCreate += GetBlocks;
    _checkerBlocks.OnRemove += RemoveBlocks;
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
  private void GetBlocks(List<Block> blocks)
  {
    _blocks = blocks;
    _blocks.ForEach(e=>e.OnDestroy += Destroy);
  }
  private void Destroy(Block block)
  {
    _blocks.Remove(block);
  }
  private void OnDisable() 
  {
    _blocks.ForEach(e=>e.OnDestroy -= Destroy);
    _blockCreator.OnCreate -= GetBlocks;
  }
}
