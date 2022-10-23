using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
public class SaverLootLooker : MonoBehaviour
{
    public static int _leaderBoardID =8069;
    private string _playerId = "";
    private void Start() 
    {
        SavablePlayerID savablePlayerID = Loader<SavablePlayerID>.Load(new SavablePlayerID());
        _playerId = savablePlayerID.PlayerID;
    }
    public void UpdloadScores() 
    {
        SavableScores savableScores = Loader<SavableScores>.Load(new SavableScores());
        StartCoroutine(SubmitScoreRoutine(int.Parse(savableScores.CountOfScores)));
    }
    public void Save(int countOfScores)
    {
        Saver<SavableScores>.Save(new SavableScores(countOfScores.ToString()));
    }
    private IEnumerator SubmitScoreRoutine(int score)
    {
        bool isDone = false;
        LootLockerSDKManager.SubmitScore(_playerId,score,_leaderBoardID, (responce) => 
        {
            string text = responce.success ? "Succesful" : "FAILED: " + responce.Error;
            Debug.Log(text);
            isDone = true;
        });
        yield return new WaitWhile(()=> isDone == false);

    }
}
