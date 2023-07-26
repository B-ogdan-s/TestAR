using System.Collections.Generic;
using UnityEngine;

internal class PoolObject<ObjectType> where ObjectType : MonoBehaviour
{
    private List<ObjectType> _saveObjects = new List<ObjectType>();
    private ObjectType _prefab;
    private Transform _parents;

    public PoolObject(ObjectType prefab, Transform parents = null)
    {
        _prefab = prefab;
        _parents = parents;
    }

    public ObjectType GetObject()
    {
        foreach (ObjectType obj in _saveObjects)
        {
            if(!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        ObjectType newObj = MonoBehaviour.Instantiate(_prefab, _parents);
        _saveObjects.Add(newObj);
        return newObj;
    }

    public void DisableAll()
    {
        foreach (ObjectType obj in _saveObjects)
        {
            obj.gameObject.SetActive(false);
        }
    }
}