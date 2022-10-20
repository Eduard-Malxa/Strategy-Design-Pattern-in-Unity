using UnityEngine;
using Zenject;

public class Airplane : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        motorStrategy.SetStrategy<AirplaneMotor>();
    }
}
