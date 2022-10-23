using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement
{
    private Transform _currentTransform;
    private Rigidbody2D _rigidbody2D;
    private float _gravityScale;
    private float _startGravityScale;
    private Vector2 _bordersForMoving = new Vector2(-9,-3);
    public void Move()
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentTransform.position = new Vector2(Mathf.Clamp(Mathf.Round(position.x),_bordersForMoving.x,_bordersForMoving.y),_currentTransform.position.y);
    }
    public BlockMovement(Transform transform, float gravityScale, Rigidbody2D rigidbody2D)
    {
        _currentTransform = transform;
        _gravityScale = gravityScale;
        _rigidbody2D = rigidbody2D;
        _startGravityScale = _rigidbody2D.gravityScale;
    }
    private void ChangeGravity(float gravity) =>_rigidbody2D.gravityScale = gravity;
    public void SpeedUp() => ChangeGravity(_gravityScale);
    public void SpeedDown() => ChangeGravity(_startGravityScale);
}
