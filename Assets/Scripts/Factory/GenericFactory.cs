using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericFactory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    public T InstantiateObject(Vector3 position)
    {
        return Instantiate(_prefab, position,Quaternion.identity);
    }
}
