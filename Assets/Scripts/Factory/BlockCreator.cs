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
    [SerializeField] private float _coolDown;
    private List<TypeOfBlock> _typesOfBlock = new List<TypeOfBlock>();
    public List<Block> CurrentBlocks { get => _currentBlocks; set => _currentBlocks = value; }
    public List<TypeOfBlock> TypesOfBlock { get => _typesOfBlock; set => _typesOfBlock = value; }
    public Craft Craft { get => _craft; set => _craft = value; }

    public event Action<Block> OnCreate;
   
    public event Action<Craft> OnSetCtraft;
    private float _waitTime = 2;

    private void Update()
    {
        CoolDown();
    }

   private void Create()
   {
        TypesOfBlock = Craft.ListOfRowsOfCraftableBlocks.SelectMany(e=>e.ListOfTypesOfBlocks).ToList();
        TypesOfBlock = TypesOfBlock.Distinct().ToList();
        
   }
   private void CoolDown()
   {
       if (_coolDown >= _waitTime)
       {
           Block block = InstantiateObject(_points.GetRandomElementOfList().position);
           block.name = "block";
           CurrentBlocks.Add(block);
           OnCreate?.Invoke(block);
           _coolDown = 0;
       }

       _coolDown += Time.deltaTime;
   }

   public void SetCurrentCraft(Craft craft)
   {
        Craft = craft;
        
        Create();
        OnSetCtraft?.Invoke(craft);
   }
}
