using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Dispatcher : MonoBehaviour
{
    [Inject] private Airplane airplane;
    [Inject] private Car car;
    [Inject] private Bicycle bicycle;

    [SerializeField]
    private Button callAirplaneButton;

    [SerializeField]
    private Button callCarButton;

    [SerializeField]
    private Button callBicycleButton;

    private void Start()
    {
        callAirplaneButton.onClick.AddListener(airplane.ActivateMotor);
        callCarButton.onClick.AddListener(car.ActivateMotor);
        callBicycleButton.onClick.AddListener(bicycle.ActivateMotor);
    }

    private void OnDisable()
    {
        callAirplaneButton.onClick.RemoveAllListeners();
        callCarButton.onClick.RemoveAllListeners();
        callBicycleButton.onClick.RemoveAllListeners();
    }
}
