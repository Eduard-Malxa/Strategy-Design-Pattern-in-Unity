using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Dispatcher : MonoBehaviour
{
    [Inject] private DispatcherDescriptions dispatcherDescriptions;

    [Inject] private Airplane airplane;
    [Inject] private Car car;
    [Inject] private Bicycle bicycle;

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Button callAirplaneButton;

    [SerializeField]
    private Button callCarButton;

    [SerializeField]
    private Button callBicycleButton;

    private event Action OnArrivalAtLocation;

    private void Start()
    {
        OnArrivalAtLocation += OpenCallOptions;
        callAirplaneButton.onClick.AddListener(() => CallTransport(airplane));
        callCarButton.onClick.AddListener(() => CallTransport(car));
        callBicycleButton.onClick.AddListener(() => CallTransport(bicycle));
    }

    private void OnDisable()
    {
        OnArrivalAtLocation -= OpenCallOptions;
        callAirplaneButton.onClick.RemoveAllListeners();
        callCarButton.onClick.RemoveAllListeners();
        callBicycleButton.onClick.RemoveAllListeners();
    }

    private void CallTransport(Transport vehicle)
    {
        vehicle.InstantiateTransport();
        vehicle.Enable();
        dispatcherDescriptions.TransportSendedText(vehicle);
        CloseCallOptions();
    }

    private void CloseCallOptions()
    {
        canvasGroup.interactable = false;
    }

    private void OpenCallOptions()
    {
        canvasGroup.interactable = true;
    }

    public void TransportArrived()
    {
        dispatcherDescriptions.TransportArrivedText();
        OnArrivalAtLocation.Invoke();
    }
}
