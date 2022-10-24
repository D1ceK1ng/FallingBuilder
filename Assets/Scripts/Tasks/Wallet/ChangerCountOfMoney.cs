using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerCountOfMoney : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    public void IncreaseCountOfMoney(int additionalCountOfMoney)
    {
        _wallet.CountOfMoney += additionalCountOfMoney;
        SaveCountOfMoney();
    }
    public void DecreaseCountOfMoney(int additionalCountOfMoney)
    {
        _wallet.CountOfMoney -= additionalCountOfMoney;
        SaveCountOfMoney();
    }
    private void SaveCountOfMoney() =>  Saver<SavableMoney>.Save(new SavableMoney(_wallet.CountOfMoney.ToString()));

}
