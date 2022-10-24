using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DecreaserHearts : MonoBehaviour
{
  [SerializeField] private Tasks _tasks;
  [SerializeField] private MusicVolume _musicVolume;
  [SerializeField] private List<Heart> _hearts = new List<Heart>();
  private void Awake() 
  {
    _musicVolume.AudioSource.Pause();
    _tasks.OnEndTime += LoseHeart;
  }
  private void LoseHeart()
  {
    _musicVolume.AudioSource.Play();
    Heart heart = _hearts.LastOrDefault();
    heart.TakeDamage();
    _hearts.Remove(heart);
    if (_hearts.Count == 0)
    {
      LoaderScene loaderScene = FindObjectOfType<LoaderScene>();
      loaderScene.OpenMenu();
    }
  }
  private void OnDisable() 
  {
     _tasks.OnEndTime -= LoseHeart;
  }
}
