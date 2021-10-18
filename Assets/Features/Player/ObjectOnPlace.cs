using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectOnPlace<T> where T : Component
{
    public bool IsOnPlace => _object != null;
    public T Object => _object;

    private string _tag;
    private T _object;
    private Action<T> OnEnter;
    private Action<T> OnExit;

    public ObjectOnPlace(string tag, Action<T> onEnter = null, Action<T> onExit = null)
    {
        _tag = tag;
        OnEnter = onEnter;
        OnExit = onExit;
    }

    public void CheckEnter(Collider other)
    {
        if (other.CompareTag(_tag))
        {
            if (_object != null)
            {
                OnExit?.Invoke(_object);
                _object = null;
            }

            _object = other.GetComponent<T>();
            OnEnter?.Invoke(_object);
        }
    }

    public void CheckExit(Collider other)
    {
        if (other.CompareTag(_tag) && _object != null && (other.gameObject == _object.gameObject))
        {
            OnExit?.Invoke(_object);
            _object = null;
        }
    }
}