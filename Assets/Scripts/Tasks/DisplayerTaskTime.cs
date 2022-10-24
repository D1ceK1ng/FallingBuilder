using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayerTaskTime : MonoBehaviour
{
    [SerializeField] private Tasks _tasks;
    [SerializeField] private DestroyerBlocks _destroyerBlocks;
    [SerializeField] private Image _taskTimeBar;
    private void Awake() 
    {
        _destroyerBlocks.OnIncreaseScores += _tasks.StartNewTask;
    }
    private void Update() 
    {
        _taskTimeBar.DivideImageBar(_tasks.ChangerTime.ReloadTime, _tasks.ChangerTime.CurrentCoolDown);
    }
    private void OnDisable() 
    {
       _destroyerBlocks.OnIncreaseScores -= _tasks.StartNewTask;
    }
}
