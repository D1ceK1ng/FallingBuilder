using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CreatorSlotOfCraft : GenericFactory<SlotOfCraft>
{
    [SerializeField] private Transform _point;
    [SerializeField] private GridLayoutGroup _grid;
    [SerializeField] private BlockCreator _blockCreator;
    private List<SlotOfCraft> _listOfSlotsOfCrafts = new List<SlotOfCraft>();
    private Craft _craft;
    private void Awake()
    {
        _blockCreator.OnSetCtraft += SetCraft;
    }

    private void SetCraft(Craft craft)
    {
        _craft = craft;
        _grid.constraintCount = _craft.ListOfRowsOfCraftableBlocks.Count;
        if (_listOfSlotsOfCrafts.Count >= 0)
        {
            int count = _listOfSlotsOfCrafts.Count;
            for (int i = 0; i < count; i++)
            {
               Destroy(_listOfSlotsOfCrafts[i].gameObject);
            }
            _listOfSlotsOfCrafts.Clear();
        }
        List<TypeOfBlock> typesOfBlocks = _craft.ListOfRowsOfCraftableBlocks.SelectMany(e=>e.ListOfTypesOfBlocks).Reverse().ToList();
        foreach (var item in typesOfBlocks)
        {
           SlotOfCraft slotOfCraft = InstantiateObject(_point.position);
           slotOfCraft.SetTypeOfBlock(item);
           slotOfCraft.transform.SetParent(_point);
           _listOfSlotsOfCrafts.Add(slotOfCraft);
        }
    }
    private void OnDisable() 
    {
      _blockCreator.OnSetCtraft -= SetCraft;
    }
}
