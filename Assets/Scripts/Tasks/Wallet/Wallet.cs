using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _countOfMoney;
    public int CountOfMoney { get => _countOfMoney; set => _countOfMoney = value; }

    private void Awake() 
    {
       LoadMoney();
    }
    private void LoadMoney()
    {
        SavableMoney savableMoney = Loader<SavableMoney>.Load(new SavableMoney());
       if (savableMoney == null)
       {
        return;
       }  
       if (savableMoney.Money != "")
       {
        CountOfMoney = int.Parse(savableMoney.Money);
       }
    }

}
