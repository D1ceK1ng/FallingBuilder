using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private void Awake() 
    {
        GetterMusicVolume getterMusicVolume = new GetterMusicVolume();
        _audioSource.volume = getterMusicVolume.ReturnMusicVolume();
    }
}
