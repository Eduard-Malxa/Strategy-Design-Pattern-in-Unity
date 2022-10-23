using UnityEngine;
using Zenject;

public class Car : Transport
{
    public override void InstantiateTransport()
    {
        transportStrategy.SetStrategy<CarTransport>();
    }
}
