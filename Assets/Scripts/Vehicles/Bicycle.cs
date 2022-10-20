using UnityEngine;
using Zenject;

public class Bicycle : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        motorStrategy.SetStrategy<BicycleMotor>();
    }
}
