using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangerMusic : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private void Awake() 
    {
       GetterMusicVolume getterMusicVolume = new GetterMusicVolume();   
       SetSliderValue(getterMusicVolume.ReturnMusicVolume());
    }
    public void SetSliderValue(float value) =>_slider.value = value;
    public void SaveVolume(float value)
    {
        Saver<SavableMusicSettings>.Save(new SavableMusicSettings(value));
    }
}
