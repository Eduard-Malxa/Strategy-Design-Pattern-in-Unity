using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DestinationPoint : MonoBehaviour
{
    [Inject] private Dispatcher dispatcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Transport vehicle))
        {
            vehicle.Arrived(dispatcher.TransportArrived);
        }
    }
}
