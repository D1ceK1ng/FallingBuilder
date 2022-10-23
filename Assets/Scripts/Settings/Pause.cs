using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause : MonoBehaviour
{
    private static List<IStoppable> _listOfIStoppable = new List<IStoppable>();
    private static bool _isPressedEscape = false;
    public Action<bool> OnChangeActive;
    private void Awake() 
    {

    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PressEscape();
        }
    }
    public void PressEscape()
    {
            _isPressedEscape =! _isPressedEscape;
            _listOfIStoppable.ForEach(e=>TryStoppingGame(e));
            OnChangeActive?.Invoke(_isPressedEscape);
    }
    private static void TryStoppingGame(IStoppable entitie)
    {
        Action OnAciton = _isPressedEscape ? entitie.StopEntitie : entitie.PlayEntitie;
        OnAciton?.Invoke();
    }
    public static void AddEntitie(IStoppable iStoppable)
    {
        _listOfIStoppable.Add(iStoppable);
        TryStoppingGame(iStoppable);
        
    }
    public static void RemoveEntitie(IStoppable iStoppable)
    {
       _listOfIStoppable.Remove(iStoppable);
    }
}
