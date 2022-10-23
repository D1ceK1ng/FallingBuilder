
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    private float _taskTime;
    
    [SerializeField] private List<Craft> _tasks;
    [SerializeField] private BlockCreator _blockCreator;
    private Craft _currentCraft;
    private readonly float _maxTaskTime = 10f;


    private void Start()
    {
        GenerateTask();
    }
    

    private void Update()
    {
        
        if (_taskTime >=  _maxTaskTime)
        {
            GenerateTask();
            _taskTime = 0;
        }

        _taskTime += Time.deltaTime;

    }

    private void GenerateTask()
    {
        _currentCraft = _tasks.GetRandomElementOfList();
        _blockCreator.SetCurrentCraft(_currentCraft);
    }
}
