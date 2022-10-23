using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class FinderHighestFallenBlock : MonoBehaviour
{
    [SerializeField] private BlockCreator _blockCreator;
    [SerializeField] private CheckerBlocks _checkerBlocks;
    private Dictionary<float, float> _highestVectorsOfBlocks = new Dictionary<float, float>();
    private Vector2 _unallowedVector;
    //private Block _block;
    private void OnEnable() 
    {
     _checkerBlocks.OnLandBlock += FindHighestFallenBlock; 
     _blockCreator.OnCreate += SetUnallowedVectorToBlock;
    }
    private void SetUnallowedVectorToBlock(Block block)
    {
        block.BlockMovement.SetDictionary(_highestVectorsOfBlocks);
    }
    private void FindHighestFallenBlock()
    {
        List<Block> blocksOnEarth = _blockCreator.CurrentBlocks.Where(e=>e.IsOnAir == false).ToList();
        _highestVectorsOfBlocks.Clear();
        if(blocksOnEarth.Count > 0)
        {
          List<float> listOfXPositions = blocksOnEarth.Select(e=>e.transform.position.x).Distinct().ToList();
          foreach (var xPosition in listOfXPositions)
          {
            List<Block> blocks = blocksOnEarth.FindAll(e=>e.transform.position.x == xPosition);
            _highestVectorsOfBlocks.Add(blocks.FirstOrDefault().transform.position.x, blocks.Max(e=>e.transform.position.y));
          }
         //_unallowedVector.y = blocksOnEarth.Max(e=>e.transform.position.y);
         //_block = _blockCreator.CurrentBlocks.Find(e=>e.transform.position.y == _unallowedVector.y);
         //_unallowedVector = new Vector2(_block.transform.position.x, _unallowedVector.y);
        }
    }
    private void OnDisable() 
    {
       _checkerBlocks.OnLandBlock -= FindHighestFallenBlock; 
        _blockCreator.OnCreate += SetUnallowedVectorToBlock;
    }
}
