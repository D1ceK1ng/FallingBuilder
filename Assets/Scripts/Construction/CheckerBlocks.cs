using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CheckerBlocks : MonoBehaviour
{
    [SerializeField] private HouseConstructionZone _houseConstructionZone;
   [SerializeField] private Craft _craft;
    public event Action<List<Block>> OnRemove;
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            List<FinderBlocks> listOffinderBlocks = FindObjectsOfType<FinderBlocks>().ToList();
            listOffinderBlocks.ForEach(e=>
            {
                e.SetCollider2D(_craft.ListOfRowsOfCraftableBlocks.Count);
                e.OnFindManyBlocks += SortBlocks;
                e.FindClosestBlocks(_houseConstructionZone.Blocks);
            });
        }
    }
    private void SortBlocks(List<Block> currentBlocks)
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
        List<List<TypeOfBlock>> currentTypesOfBlock = _craft.ListOfRowsOfCraftableBlocks.Select(e=>e.ListOfTypesOfBlocks).ToList();
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
                    else
                    {
                       if (avableBlocks[i][j].TypeOfBlock != currentTypesOfBlock[i][j])
                       {
                        return false;
                       }
                    }
                }
        }
        return true;
            
    }
        

}
