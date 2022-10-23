using UnityEngine;
using Zenject;

public class Bicycle : Transport
{
    public override void InstantiateTransport()
    {
        transportStrategy.SetStrategy<BicycleTransport>();
    }
}
