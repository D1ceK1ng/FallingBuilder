using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class ShowerHighestScrores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNamesText;
    [SerializeField] private TextMeshProUGUI _playerScoresText;
    [SerializeField] private LoginnerLootLooker _loginnerLootLooker;
    [SerializeField] private int _countOfBestPlayers = 10;
    private int _countOfWorstPlayers = 0;
    private void Awake() 
    {
      _loginnerLootLooker.OnLogin += TryGetHighscores;
    }
    private void TryGetHighscores() => StartCoroutine(FetchTopHighscoresRoutine());
    public IEnumerator FetchTopHighscoresRoutine()
    {
        bool isDone = false;
        LootLockerSDKManager.GetScoreList(SaverLootLooker._leaderBoardID,_countOfBestPlayers,_countOfWorstPlayers, (responce) => 
        {
            if (responce.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";
                LootLockerLeaderboardMember[] members = responce.items;
                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    tempPlayerNames += members[i].player.name == "" ? members[i].player.id : members[i].player.name;
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                _playerNamesText.text = tempPlayerNames;
                _playerScoresText.text = tempPlayerScores;
            }
          isDone = true;
        });
        yield return new WaitWhile(()=> isDone == false);

    }
    private void OnDisable() 
    {
      _loginnerLootLooker.OnLogin -= TryGetHighscores;
    }
}
