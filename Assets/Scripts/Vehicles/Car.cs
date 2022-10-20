using UnityEngine;
using Zenject;

public class Car : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        motorStrategy.SetStrategy<CarMotor>();
    }
}
