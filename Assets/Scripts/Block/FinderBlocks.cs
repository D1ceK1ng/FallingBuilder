using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinderBlocks : MonoBehaviour
{
    [SerializeField] private Collider2D _currentCollider2D;
    [SerializeField] private List<Collider2D> _listOfColliders2D;
    [SerializeField] private float _time = 0.3f;
    [SerializeField] private Block _block;
   [SerializeField] private List<Block> _blocks = new List<Block>();
   private int _additionalSpaceForCollider = 2;
   private int _maximumCountOfBlocks = 3;
    public event Action<List<Block>> OnFindManyBlocks;
    public void SetCollider2D(int value)
    {
      _listOfColliders2D.FindAll(e=>e.enabled).ForEach(e=>e.enabled = false);
      _currentCollider2D = _listOfColliders2D[value - _additionalSpaceForCollider];
      _currentCollider2D.enabled = true;
    }
   private void OnTriggerStay2D(Collider2D other) 
   {
     other.TriggerEntity<Block>(e=>
     {
        if(_blocks.Contains(e))
        {
        return;
        }
        _blocks.Add(e);
     });
   }
   private void OnTriggerExit2D(Collider2D other) 
   {
     other.TriggerEntity<Block>(e=>
     {
        _blocks.Remove(e);
     });
   }
    public void FindClosestBlocks(List<Block> blocksInZone)
    {
         _blocks.Clear();
         _currentCollider2D.enabled = false;
          _currentCollider2D.enabled = true;
         StartCoroutine(CoolDown(blocksInZone));
    }
    private IEnumerator CoolDown(List<Block> blocksInZone)
    {
        yield return new WaitForSeconds(_time);
        _blocks.Add(_block);
        _blocks = _blocks.Distinct().ToList();
        _blocks.RemoveAll(e=>blocksInZone.Contains(e) == false);
        _blocks = _blocks.OrderBy(e=>Mathf.Round(e.transform.position.x)).OrderBy(e=>e.transform.position.y).ToList();
        int index = _blocks.IndexOf(_block);
        if (_blocks.Count >= _maximumCountOfBlocks && index == 0)
        {
            _blocks.Reverse();
            _blocks = _blocks.OrderBy(e=>e.transform.position.y).ToList();
        }
        OnFindManyBlocks?.Invoke(_blocks);
    }
}
