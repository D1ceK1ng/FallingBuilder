
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(ChangerTime))]
public class Tasks : MonoBehaviour
{
    private ChangerTime _changerTime;
    [SerializeField] private List<Craft> _tasks;
    [SerializeField] private BlockCreator _blockCreator;
    private Craft _currentCraft;
    public ChangerTime ChangerTime { get => _changerTime; private set => _changerTime = value; }

    public event Action OnEndTime;
    private void Start()
    {
        ChangerTime = GetComponent<ChangerTime>();
        ChangerTime.SetAction(Reload);
        GenerateTask();
    }
    public void ResetTime()
    {
        ChangerTime.ResetTime();
    }
    private void Reload()
    {
        GenerateTask();
        OnEndTime?.Invoke();
    }
    public void StartNewTask()
    {
        ChangerTime.SetAction(GenerateTask);
        ResetTime();
        ChangerTime.SetAction(Reload);
    }
    private void GenerateTask()
    {
        _currentCraft = _tasks.GetRandomElementOfList();
        ChangerTime.ReloadTime = _currentCraft.ReloadTime;
        _blockCreator.SetCurrentCraft(_currentCraft);
    }
}
