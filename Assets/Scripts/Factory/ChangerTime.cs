using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ChangerTime : MonoBehaviour, IStoppable
{
   private Action _action;
    private float _currentCoolDown;
    [SerializeField] private float _reloadTime = 20;
    private bool _isTimeGoing = true;
    public float CurrentCoolDown { get => _currentCoolDown; private set => _currentCoolDown = value; }
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
    public bool IsTimeGoing { get => _isTimeGoing; set => _isTimeGoing = value; }

    private void Awake() 
    {
        Pause.AddEntitie(this);
    }
    public void SetAction(Action action)
   {
    _action = action;
   }
   private void Update() 
   {
    if(IsTimeGoing)
    {
    CoolDown();
    }
   }
    private void CoolDown()
   {
       if (ReloadTime <= CurrentCoolDown)
       {
        ResetTime();
       }
       CurrentCoolDown += Time.deltaTime;
   }
   public void ResetTime()
   {
    _action?.Invoke();
    CurrentCoolDown = 0;
   }

    public void StopEntitie()
    {
        IsTimeGoing = false;
    }

    public void PlayEntitie()
    {
        IsTimeGoing = true;
    }
    private void OnDisable() 
    {
         Pause.RemoveEntitie(this);
    }
}
