using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
public class LoginnerLootLooker : MonoBehaviour
{
    [SerializeField] private ShowerHighestScrores _showerHighestScrores;
    private string _playerID;
    private void Awake()
    {
        StartCoroutine(GetInformationFromLeaderBoard());
    }
    private IEnumerator GetInformationFromLeaderBoard()
    {
        yield return Login();
        yield return _showerHighestScrores.FetchTopHighscoresRoutine();
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
