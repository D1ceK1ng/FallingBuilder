using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Block : MonoBehaviour
{
   private bool _isOnEarth;
   private TypeOfBlock _typeOfBlock;
   private List<TypeOfBlock> _allTypesOfBlock = new List<TypeOfBlock>() {TypeOfBlock.Wood,TypeOfBlock.Stone};//,TypeOfBlock.Glass,TypeOfBlock.Brick};
   [SerializeField] private List<Sprite> _sprites;
   [SerializeField] private SpriteRenderer _spriteRenderer;
    public TypeOfBlock TypeOfBlock { get => _typeOfBlock; private set => _typeOfBlock = value; }
    public bool IsOnEarth { get => _isOnEarth; set => _isOnEarth = value; }
    public event Action<Block> OnDestroy;
    private void Awake() 
    {
    _typeOfBlock = _allTypesOfBlock.GetRandomElementOfList();
    _spriteRenderer.sprite = _sprites[(int)_typeOfBlock];   
    }
    public void ChangeColor()
    {
         _spriteRenderer.color = Color.red;
         OnDestroy?.Invoke(this);
         Destroy(gameObject,1);
    }
}
