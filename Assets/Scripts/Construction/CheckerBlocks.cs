using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckerBlocks : MonoBehaviour
{
    [SerializeField] private HouseConstructionZone _houseConstructionZone;
   [SerializeField] private SorterBlocks _sorterBlocks;
  [SerializeField] private BlockCreator _blockCreator;
  private List<Block> _blocks = new List<Block>();
  public event Action OnLandBlock;
  private void Awake() 
  {
        _blockCreator.OnCreate += AddBlock;
  }
  private void AddBlock(Block block)
  {
    _blocks.Add(block);
    block.SetTypeOfBlock(_blockCreator.TypesOfBlock.GetRandomElementOfList());
    block.OnLand += TryFinding;
  }
  private void TryFinding()
  {
        OnLandBlock?.Invoke();
        _blocks.RemoveAll(e=>e == null);
        List<FinderBlocks> listOffinderBlocks = FindObjectsOfType<FinderBlocks>().ToList();
        listOffinderBlocks.ForEach(e=>
        {
                e.SetCollider2D(_blockCreator.Craft.ListOfRowsOfCraftableBlocks.Count);
                e.OnFindManyBlocks += _sorterBlocks.SortBlocks;
                e.FindClosestBlocks(_houseConstructionZone.Blocks);
        });

  }
    private void OnDisable() 
    {
      _blockCreator.OnCreate -= AddBlock;
     _blocks.ForEach(e=>e.OnLand -= TryFinding);
    }
        

}
