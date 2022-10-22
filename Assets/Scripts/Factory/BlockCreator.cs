using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockCreator : GenericFactory<Block>
{
   [SerializeField] private List<Transform> _points;
   private List<Block> _currentBlocks = new List<Block>();
   [SerializeField] private float _additionalTime = 3;
   [SerializeField] private int _countOfBlocks = 10;
   public event Action<List<Block>> OnCreate;
   private void Awake() 
   {
     Create();
   }
   private void Create()
   {
    for (int i = 0; i < _countOfBlocks; i++)
    {
      StartCoroutine(CoolDown(i / _additionalTime));
    }
    Invoke(nameof(InvokeAction), _countOfBlocks / _additionalTime);
   }
   private IEnumerator CoolDown(float waitTime)
   {
    yield return new WaitForSeconds(waitTime);
     Block block = InstantiateObject(_points.GetRandomElementOfList().position);
     block.name = "block " + waitTime;
     _currentBlocks.Add(block);
   }
   private void InvokeAction() => OnCreate?.Invoke(_currentBlocks);
}
