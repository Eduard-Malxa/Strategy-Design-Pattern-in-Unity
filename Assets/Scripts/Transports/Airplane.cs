using UnityEngine;
using Zenject;

public class Airplane : Transport
{
    public override void InstantiateTransport()
    {
        transportStrategy.SetStrategy<AirplaneTransport>();
    }
}
