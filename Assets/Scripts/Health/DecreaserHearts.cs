using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[RequireComponent(typeof(ChangerTime))]
public class DecreaserHearts : MonoBehaviour
{
  [SerializeField] private Tasks _tasks;
  [SerializeField] private MusicVolume _musicVolume;
  [SerializeField] private List<Heart> _hearts = new List<Heart>();
  private ChangerTime _changerTime;
  private bool _canDecreaseHearts = true;
  private void Awake() 
  {
    _changerTime = GetComponent<ChangerTime>();
    _changerTime.SetAction(()=>
    {
      _changerTime.IsTimeGoing = false;
    });
    _musicVolume.AudioSource.Pause();
    _tasks.OnEndTime += LoseHeart;
  }
  private void LoseHeart()
  {
    if ( _changerTime.IsTimeGoing)
    {
      return;
    }
    _musicVolume.AudioSource.Play();
    Heart heart = _hearts.LastOrDefault();
    heart.TakeDamage();
    _hearts.Remove(heart);
    if (_hearts.Count == 0)
    {
      LoaderScene loaderScene = FindObjectOfType<LoaderScene>();
      loaderScene.OpenMenu();
    }
    _changerTime.IsTimeGoing = true;
  }
  private void OnDisable() 
  {
     _tasks.OnEndTime -= LoseHeart;
  }
}
