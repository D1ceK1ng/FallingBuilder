using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseConstructionZone : MonoBehaviour
{
  private List<Block> _blocks = new List<Block>();
  public List<Block> Blocks { get => _blocks; private set => _blocks = value; }
  public void AddBlock(Block block)
  {
    if (Blocks.Contains(block))
    {
        return;
    }
    _blocks.Add(block);
  }
}
