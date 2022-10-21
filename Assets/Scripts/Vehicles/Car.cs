using UnityEngine;
using Zenject;

public class Car : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-4.02f, transform.position.y, transform.position.z);
        motorStrategy.SetStrategy<CarMotor>();
    }
}
