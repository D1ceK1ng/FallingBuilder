using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockCreator : GenericFactory<Block>
{
  [SerializeField] private Craft _craft;
   [SerializeField] private List<Transform> _points;
   private List<Block> _currentBlocks = new List<Block>();
   [SerializeField] private float _coolDown = 2;
    private List<TypeOfBlock> _typesOfBlock = new List<TypeOfBlock>();
    public List<Block> CurrentBlocks { get => _currentBlocks; set => _currentBlocks = value; }
    public List<TypeOfBlock> TypesOfBlock { get => _typesOfBlock; set => _typesOfBlock = value; }
    public Craft Craft { get => _craft; set => _craft = value; }

    public event Action<Block> OnCreate;
   private void Awake() 
   {
     Create();
   }
   private void Create()
   {
    TypesOfBlock = Craft.ListOfRowsOfCraftableBlocks.SelectMany(e=>e.ListOfTypesOfBlocks).ToList();
    TypesOfBlock = TypesOfBlock.Distinct().ToList();
    StartCoroutine(CoolDown());
   }
   private IEnumerator CoolDown()
   {
    yield return new WaitForSeconds(_coolDown);
     Block block = InstantiateObject(_points.GetRandomElementOfList().position);
     block.name = "block";
     CurrentBlocks.Add(block);
     OnCreate?.Invoke(block);
     StartCoroutine(CoolDown());
   }
}
