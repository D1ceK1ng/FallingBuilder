using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _gravityScale = 4;
    private BlockMovement _blockMovement;
    private float _destroyTime = 0.6f;
    private bool _isOnAir = true;
    private TypeOfBlock _typeOfBlock;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public TypeOfBlock TypeOfBlock { get => _typeOfBlock; private set => _typeOfBlock = value; }
    public bool IsOnAir { get => _isOnAir; set => _isOnAir = value; }
    public bool CanMove { get; set; }
    public BlockMovement BlockMovement { get => _blockMovement; private set => _blockMovement = value; }
    public event Action OnLand;
    public event Action<Block> OnDestroy;
    private void Awake() 
    {
        BlockMovement = new BlockMovement(transform, _gravityScale, _rigidbody2D);  
    }
    public void SetTypeOfBlock(TypeOfBlock typeOfBlock)
    {
        _typeOfBlock = typeOfBlock;
        _spriteRenderer.sprite = ReturnSprite(typeOfBlock); 
    }
    public Sprite ReturnSprite(TypeOfBlock typeOfBlock) => _sprites[(int)typeOfBlock];
    private void Update()
    {
        if(CanMove && IsOnAir)
        {
            BlockMovement.Move();
        }
    }


    public void Land()
    {
        OnLand?.Invoke();
        IsOnAir = false;
        _blockMovement.SpeedDown();
    }

    public void DestroyBlock()
    {
         OnDestroy?.Invoke(this);
         Destroy(gameObject,_destroyTime);
    }


    

}
