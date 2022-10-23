using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class TupleOfItem
{
    [SerializeField] private KeyCode _keyCode;
    [SerializeField] private Button _button;

    public KeyCode KeyCode { get => _keyCode; private set => _keyCode = value; }
    public Button Button { get => _button; private set => _button = value; }
}
