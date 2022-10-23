using System;
using UnityEngine;

public interface ITransport
{
    void Disable(GameObject gameObject);
    void Enable(GameObject gameObject);
    void Move(Transform transform);
    void Arrived(Transform transform, Action OnArrivalCallBack);
}
