using UnityEngine;
using Zenject;

public class Bicycle : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
        motorStrategy.SetStrategy<BicycleMotor>();
    }
}
