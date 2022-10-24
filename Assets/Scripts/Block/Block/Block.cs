using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour, IStoppable
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float _gravityScale = 4;
    private BlockMovement _blockMovement;
    private float _destroyTime = 0.6f;
    private bool _isOnAir = true;
    private Vector2 _lastVelocity;
    private bool _isTimeGoing = true;
    private TypeOfBlock _typeOfBlock;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    public TypeOfBlock TypeOfBlock { get => _typeOfBlock; private set => _typeOfBlock = value; }
    public bool IsOnAir { get => _isOnAir; set => _isOnAir = value; }
    public bool CanMove { get; set; }
    public BlockMovement BlockMovement { get => _blockMovement; private set => _blockMovement = value; }
    public event Action OnLand;
    public event Action<Block> OnDestroy;
    private void OnEnable() 
    {
        BlockMovement = new BlockMovement(transform);
        Pause.AddEntitie(this);  
    }
    public void SetTypeOfBlock(TypeOfBlock typeOfBlock)
    {
        _typeOfBlock = typeOfBlock;
        _spriteRenderer.sprite = ReturnSprite(typeOfBlock); 
    }
    public Sprite ReturnSprite(TypeOfBlock typeOfBlock) => _sprites[(int)typeOfBlock];
    private void Update()
    {
        if(CanMove && IsOnAir && _isTimeGoing)
        {
            BlockMovement.Move();
        }
    }
    public void StopEntitie()
    {
        _isTimeGoing = false;
        _rigidbody2D.gravityScale = 0;
        _rigidbody2D.velocity = _lastVelocity;
        _rigidbody2D.velocity = Vector2.zero;

    }
    public void SetGravityScale(float gravityScale) 
    {
         _gravityScale = gravityScale;
         _rigidbody2D.gravityScale = gravityScale;
         BlockMovement.SetRigidbody2D(_rigidbody2D.gravityScale, _rigidbody2D);
    }
    public void PlayEntitie()
    {
        _isTimeGoing = true;
        if(IsOnAir)
        {
        _rigidbody2D.gravityScale = _blockMovement.StartGravityScale;
        _rigidbody2D.velocity = _lastVelocity;
        _blockMovement.SetTransformToMousePosition();
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
    private void OnDisable()
    {
        Pause.RemoveEntitie(this);
    }


    

}
