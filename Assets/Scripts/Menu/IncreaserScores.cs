using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaserScores : MonoBehaviour
{
    private int _countOfScores; 
    [SerializeField] private MusicVolume _musicVolume;
    [SerializeField] private DestroyerBlocks _destroyerBlocks;
    [SerializeField] private SaverLootLooker _saverLootLooker;
    private void OnEnable() 
    {
        Debug.Log("TRY!");
        _musicVolume.AudioSource.Pause();
      _destroyerBlocks.OnIncreaseScores += IncreaseScore;   
    }
    private void IncreaseScore()
    {
        Debug.Log("PLAY!");
        _countOfScores++;
        _musicVolume.AudioSource.Play();
        _saverLootLooker.Save(_countOfScores);
        _saverLootLooker.UpdloadScores();
    }
    private void OnDisable() 
    {
         _destroyerBlocks.OnIncreaseScores -= IncreaseScore;   
    }
}
