using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerCountOfMoney : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private List<BlockItem> _blockItems;
    [SerializeField] private DestroyerBlocks _destroyerBlocks;
    public Wallet Wallet { get => _wallet; private set => _wallet = value; }
    private void Awake() 
    {
        _destroyerBlocks.OnIncreaseScores += IncreaseCountOfMoney;
    }
    public void IncreaseCountOfMoney()
    {
        int additionalCountOfMoney = 0;
        _destroyerBlocks.SelectedBlocks.Select(e=>e.TypeOfBlock).ToList().ForEach(e=>additionalCountOfMoney += _blockItems.Find(a=>a.BlockType ==e ).Price);
        Wallet.CountOfMoney += additionalCountOfMoney;
        SaveCountOfMoney();
    }
    public void DecreaseCountOfMoney(int additionalCountOfMoney)
    {
        Wallet.CountOfMoney -= additionalCountOfMoney;
        SaveCountOfMoney();
    }
    private void SaveCountOfMoney() =>  Saver<SavableMoney>.Save(new SavableMoney(Wallet.CountOfMoney.ToString()));
    private void OnDisable() 
    {
        _destroyerBlocks.OnIncreaseScores -= IncreaseCountOfMoney;
    }

}
