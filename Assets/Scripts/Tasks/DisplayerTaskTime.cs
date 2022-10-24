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
        _taskTimeBar.DivideImageBar(_tasks.MaxTaskTime, _tasks.TaskTime);
    }
    private void OnDisable() 
    {
       _destroyerBlocks.OnIncreaseScores -= _tasks.StartNewTask;
    }
}
