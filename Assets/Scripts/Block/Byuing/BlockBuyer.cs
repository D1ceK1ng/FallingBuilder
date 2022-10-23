using UnityEngine;


public class BlockBuyer : MonoBehaviour
{
    [SerializeField] private BlockItem _block;
    [SerializeField] private int _playerScoreCount;

    

    public void BuyItem()
    {
        if (_playerScoreCount >= _block.Price)
        {
            _playerScoreCount -= _block.Price;
        }
    }
}
