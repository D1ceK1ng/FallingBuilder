using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Craft", order = 1)]
public class Craft : ScriptableObject
{
    [SerializeField] private float _reloadTime = 20;
    [SerializeField] private List<RowOfCraftableBlocks> _listOfRowsOfCraftableBlocks;
    [SerializeField] private Image _image;

    public Image Image { get => _image; private set => _image = value; }
    public List<RowOfCraftableBlocks> ListOfRowsOfCraftableBlocks { get => _listOfRowsOfCraftableBlocks; private set => _listOfRowsOfCraftableBlocks = value; }
    public float ReloadTime { get => _reloadTime; set => _reloadTime = value; }
}
