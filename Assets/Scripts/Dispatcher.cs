using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Dispatcher : MonoBehaviour
{
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

    private void Start()
    {
        callAirplaneButton.onClick.AddListener(() => CallVehicle(airplane));
        callCarButton.onClick.AddListener(() => CallVehicle(car));
        callBicycleButton.onClick.AddListener(() => CallVehicle(bicycle));
    }

    private void OnDisable()
    {
        callAirplaneButton.onClick.RemoveAllListeners();
        callCarButton.onClick.RemoveAllListeners();
        callBicycleButton.onClick.RemoveAllListeners();
    }

    public void CallVehicle(Vehicle vehicle)
    {
        vehicle.ActivateMotor();
        CloseCallOptions();
    }

    public async void CloseCallOptions()
    {
        canvasGroup.interactable = false;
        await Task.Delay(5000);
        canvasGroup.interactable = true;
    }
}
