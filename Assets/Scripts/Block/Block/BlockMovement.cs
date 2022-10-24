using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BlockMovement
{
    private Transform _currentTransform;
    private Rigidbody2D _rigidbody2D;
    private float _gravityScale;
    private float _startGravityScale;
    private float _avableBlockDistance =1;
    private Dictionary<float,float> _highestVectorsOfBlocks = new Dictionary<float, float>();
    private Vector2 _bordersForMoving = new Vector2(-7,-3);
    private float _additionalY = 1;
    private float _lastXPosition;
    private float _possibleXMousePosition;
    public void Move()
    {
         _possibleXMousePosition = GetXMousePosition();
        float difference = Mathf.Abs(_currentTransform.position.x - _possibleXMousePosition);
        if (difference > _avableBlockDistance)
        {
            return;
        }
        if(_highestVectorsOfBlocks.ContainsKey(_possibleXMousePosition))
        {
            float maximumY = _highestVectorsOfBlocks[_possibleXMousePosition];
            if (_currentTransform.position.y < maximumY + _additionalY && _lastXPosition != _possibleXMousePosition)
            {
                Vector2 xVector = _currentTransform.position.x > _possibleXMousePosition ? 
                new Vector2(_possibleXMousePosition + _avableBlockDistance,_bordersForMoving.y) : 
                new Vector2(_bordersForMoving.x, _possibleXMousePosition - _avableBlockDistance);
                ChangeBlockPosition(xVector);
                return;
            }
        }
        ChangeBlockPosition(_bordersForMoving);
        _lastXPosition = _currentTransform.position.x;
    }
    private void ChangeBlockPosition(Vector2 border)
    {
      _currentTransform.position = new Vector2(Mathf.Clamp(_possibleXMousePosition,border.x,border.y),_currentTransform.position.y);
    }
    private float GetXMousePosition() => Mathf.Round(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);
    public BlockMovement(Transform transform, float gravityScale, Rigidbody2D rigidbody2D)
    {
        _currentTransform = transform;
        _currentTransform.position = new Vector2(GetXMousePosition(), transform.position.y);
        _gravityScale = gravityScale;
        _rigidbody2D = rigidbody2D;
        _startGravityScale = _rigidbody2D.gravityScale;
    }
    public void SetDictionary(Dictionary<float,float> dictionary)
    {
        _highestVectorsOfBlocks = dictionary;
    }
    private void ChangeGravity(float gravity) =>_rigidbody2D.gravityScale = gravity;
    public void SpeedUp() => ChangeGravity(_gravityScale);
    public void SpeedDown() => ChangeGravity(_startGravityScale);
}
