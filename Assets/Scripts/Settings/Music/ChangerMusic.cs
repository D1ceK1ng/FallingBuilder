using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangerMusic : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private List<MusicVolume> _musicVolumes = new List<MusicVolume>();
    private void Awake() 
    {
       _musicVolumes = FindObjectsOfType<MusicVolume>().ToList();
       GetterMusicVolume getterMusicVolume = new GetterMusicVolume();   
       SetSliderValue(getterMusicVolume.ReturnMusicVolume());
    }
    public void SetSliderValue(float value) =>_slider.value = value;
    public void SaveVolume(float value)
    {
        Saver<SavableMusicSettings>.Save(new SavableMusicSettings(value));
        _musicVolumes.ForEach(e=>e.SetMusicVolume());
    }
}
