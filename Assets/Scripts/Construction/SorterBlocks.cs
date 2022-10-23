using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SorterBlocks : MonoBehaviour
{
    public event Action<List<Block>> OnRemove;
    [SerializeField] private BlockCreator _blockCreator;
    public void SortBlocks(List<Block> currentBlocks)
    {
        List<List<Block>> avableBlocks = new List<List<Block>>();
        List<float> values =  currentBlocks.Select(e=>e.transform.position.y).ToList();
        for (int i = 0; i < values.Count; i++)
        {
            values[i] = Mathf.Round(values[i]);
        }
        values = values.Distinct().ToList();
        foreach (var item in values)
        {
            List<Block> plusBlocks = currentBlocks.FindAll(e=>Mathf.Round(e.transform.position.y) == item).ToList();
           avableBlocks.Add(plusBlocks);
        }
        List<List<TypeOfBlock>> currentTypesOfBlock = _blockCreator.Craft.ListOfRowsOfCraftableBlocks.Select(e=>e.ListOfTypesOfBlocks).ToList();
        if( avableBlocks.Count == currentTypesOfBlock.Count)
        {
               if (CanRemoveBlocks(avableBlocks, currentTypesOfBlock))
               {
                 OnRemove?.Invoke(currentBlocks);
               }
        }
    }
    private bool CanRemoveBlocks(List<List<Block>> avableBlocks, List<List<TypeOfBlock>> currentTypesOfBlock )
    {
        for (int i = 0; i < avableBlocks.Count; i++)
        {
                for (int j = 0; j < currentTypesOfBlock[i].Count; j++)
                {
                    
                    if (currentTypesOfBlock[i].Count != avableBlocks[i].Count)
                    {
                        return false;
                    }
                    if (avableBlocks[i][j].TypeOfBlock != currentTypesOfBlock[i][j])
                    {
                    return false;
                    }
                }
        }
        return true;
            
    }

}
