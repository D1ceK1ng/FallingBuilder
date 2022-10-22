using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class RowOfCraftableBlocks 
{
    [SerializeField] private List<TypeOfBlock> _listOfTypesOfBlocks;
    public List<TypeOfBlock> ListOfTypesOfBlocks { get => _listOfTypesOfBlocks; private set => _listOfTypesOfBlocks = value; }
}
