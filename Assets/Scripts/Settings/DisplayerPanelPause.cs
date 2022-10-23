using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DisplayerPanelPause : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private CanvasGroup _canvasGroup;
    private void Awake() 
    {
        _pause.OnChangeActive += ChangeActiveOfPanel;
    }
    private void ChangeActiveOfPanel(bool isActive)
    {
        _canvasGroup.ChangeStateOfCanvasGroup(isActive);
    }
    private void OnDisable() 
    {
       _pause.OnChangeActive -= ChangeActiveOfPanel;
    }
}
