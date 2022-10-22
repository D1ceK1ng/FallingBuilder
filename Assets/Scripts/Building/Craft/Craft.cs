using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Craft", order = 1)]
public class Craft : ScriptableObject
{
    [SerializeField] private List<RowOfCraftableBlocks> _listOfRowsOfCraftableBlocks;

    public List<RowOfCraftableBlocks> ListOfRowsOfCraftableBlocks { get => _listOfRowsOfCraftableBlocks; private set => _listOfRowsOfCraftableBlocks = value; }
}
