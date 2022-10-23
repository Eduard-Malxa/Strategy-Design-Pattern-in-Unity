using System;
using UnityEngine;
using Zenject;

public abstract class Transport : MonoBehaviour
{
    [Inject] protected TransportStrategy transportStrategy;

    private void Awake()
    {
        InstantiateTransport();
    }

    private void Start()
    {
        transportStrategy.Disable(gameObject);
    }

    private void Update()
    {
        transportStrategy.Move(transform);
    }

    public void Arrived(Action OnArrivalCallBack)
    {
        transportStrategy.Arrived(transform, OnArrivalCallBack);
    }

    public void Enable()
    {
        transportStrategy.Enable(gameObject);
    }

    public abstract void InstantiateTransport();
}
