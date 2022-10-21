using UnityEngine;
using Zenject;

public class Airplane : Vehicle
{
    public override void ActivateMotor()
    {
        gameObject.SetActive(true);
        transform.position = new Vector3(-5.21f, transform.position.y, transform.position.z);
        motorStrategy.SetStrategy<AirplaneMotor>();
    }
}
