using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
public class LoginnerLootLooker : MonoBehaviour
{
    private string _playerID;
    public event Action OnLogin;
    private void OnEnable()
    {
        StartCoroutine(GetInformationFromLeaderBoard());
    }
    private IEnumerator GetInformationFromLeaderBoard()
    {
        yield return Login();
        OnLogin?.Invoke();
    }
    private IEnumerator Login()
    {
        bool isDone = false;
        LootLockerSDKManager.StartGuestSession((responce) => 
        {
            if (responce.success)
            {
                Debug.Log("Login");
                _playerID = responce.player_id.ToString();
                SavePlayerID();
                isDone = true;
            }
        });
        yield return new WaitWhile(()=> isDone == false);
    }
    private void SavePlayerID()
    {
        Saver<SavablePlayerID>.Save(new SavablePlayerID(_playerID));
    }
}
