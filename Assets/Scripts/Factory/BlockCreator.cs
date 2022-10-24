using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(ChangerTime))]
public class BlockCreator : GenericFactory<Block>
{
    [SerializeField] private Craft _craft;
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _deltaTimeForCreatingBlocks = 0.2f;
    [SerializeField] private float _deltaTimeForGravityScale = 0.2f;
    private ChangerTime _changerTime;
    private List<Block> _currentBlocks = new List<Block>();
    private List<TypeOfBlock> _typesOfBlock = new List<TypeOfBlock>();
    private float _additionalGravityScale =0.3f;
    private float _minumumSpawnRate = 1.5f;
    public List<Block> CurrentBlocks { get => _currentBlocks; set => _currentBlocks = value; }
    public List<TypeOfBlock> TypesOfBlock { get => _typesOfBlock; set => _typesOfBlock = value; }
    public Craft Craft { get => _craft; set => _craft = value; }

    public event Action<Block> OnCreate;
   
    public event Action<Craft> OnSetCtraft;
    private void Awake() 
    {
        _changerTime = GetComponent<ChangerTime>();
        _changerTime.SetAction(() =>
        {
           Block block = InstantiateObject(_points.GetRandomElementOfList().position);
           block.SetGravityScale(_additionalGravityScale);
           block.name = "block";
           CurrentBlocks.Add(block);
           OnCreate?.Invoke(block);
        });
    }
    private void Update() 
    {
        if (_changerTime.ReloadTime >= _minumumSpawnRate)
        {
            _additionalGravityScale -= Time.deltaTime * _deltaTimeForCreatingBlocks;
        }
        _additionalGravityScale += Time.deltaTime * _deltaTimeForGravityScale;
    }
   private void Create()
   {
        TypesOfBlock = Craft.ListOfRowsOfCraftableBlocks.SelectMany(e=>e.ListOfTypesOfBlocks).ToList();
        TypesOfBlock = TypesOfBlock.Distinct().ToList();
        
   }
   public void SetCurrentCraft(Craft craft)
   {
        Craft = craft;
        Create();
        OnSetCtraft?.Invoke(craft);
   }
}
