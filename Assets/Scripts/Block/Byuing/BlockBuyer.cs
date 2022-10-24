using UnityEngine;


public class BlockBuyer : MonoBehaviour
{
    [SerializeField] private BlockItem _block;
    [SerializeField] private BlockSwaper _blockSwaper;
    private ChangerCountOfMoney _changerCountOfMoney;
    private void Awake() 
    {
        _changerCountOfMoney = FindObjectOfType<ChangerCountOfMoney>();
    }
    

    public void BuyItem()
    {
        if (_changerCountOfMoney.Wallet.CountOfMoney - _block.Price >= 0 )
        {
            _changerCountOfMoney.DecreaseCountOfMoney(_block.Price); 
            _blockSwaper.SwapBlock(_block);
        }
    }
}
