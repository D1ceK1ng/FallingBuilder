using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class BlockItem : ScriptableObject
{ 
    [SerializeField] private int _price;
    [SerializeField] private string _name;
    [SerializeField] private TypeOfBlock _blockType;
    public int Price => _price; 
    public string Name => _name;
    public TypeOfBlock BlockType => _blockType;
}

