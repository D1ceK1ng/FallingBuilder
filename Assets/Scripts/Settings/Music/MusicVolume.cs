using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public AudioSource AudioSource { get => _audioSource; private set => _audioSource = value; }

    private void Awake() 
    {
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        GetterMusicVolume getterMusicVolume = new GetterMusicVolume();
        AudioSource.volume = getterMusicVolume.ReturnMusicVolume();
    }
}
