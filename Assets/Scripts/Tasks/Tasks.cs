
using System.Collections.Generic;
using UnityEngine;
using System;
public class Tasks : MonoBehaviour
{
    private float _taskTime;
    
    [SerializeField] private List<Craft> _tasks;
    [SerializeField] private BlockCreator _blockCreator;
    private Craft _currentCraft;
   [SerializeField]  private float _maxTaskTime = 10f;
    public float MaxTaskTime { get => _maxTaskTime; private set => _maxTaskTime = value; }
    public float TaskTime { get => _taskTime; private set => _taskTime = value; }
    public event Action OnEndTime;
    private void Start()
    {
        GenerateTask();
    }
    private void Update()
    {
        IncreaseTime();
    }
    private void IncreaseTime()
    {
        if (TaskTime >=  _maxTaskTime)
        {
           LoseHeart();
        }
        TaskTime += Time.deltaTime;

    }
    public void LoseHeart()
    {
            StartNewTask();
            OnEndTime?.Invoke();
    }
    public void StartNewTask()
    {
        GenerateTask();
        TaskTime = 0;
    }
    private void GenerateTask()
    {
        _currentCraft = _tasks.GetRandomElementOfList();
        _blockCreator.SetCurrentCraft(_currentCraft);
    }
}
