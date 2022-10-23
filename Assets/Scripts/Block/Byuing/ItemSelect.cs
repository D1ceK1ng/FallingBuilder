using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class ItemSelect : MonoBehaviour
{
    [SerializeField] private List<TupleOfItem> _listOfTyples = new List<TupleOfItem>();

    private void Update()
    {
        foreach (KeyCode keyCode in KeyCode.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(keyCode))
            {
                TupleOfItem tupleOfItem = _listOfTyples.Find(e => e.KeyCode == keyCode);
                if (tupleOfItem != null)
                {
                    Button button = tupleOfItem.Button;
                    button.Select();
                }
            }
        }
        
    }
}
