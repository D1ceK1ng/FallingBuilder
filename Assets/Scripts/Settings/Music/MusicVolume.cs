using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Awake() 
    {
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        GetterMusicVolume getterMusicVolume = new GetterMusicVolume();
        _audioSource.volume = getterMusicVolume.ReturnMusicVolume();
    }
}
