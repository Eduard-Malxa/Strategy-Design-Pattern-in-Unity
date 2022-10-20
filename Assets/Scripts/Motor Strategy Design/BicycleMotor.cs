using UnityEngine;

public class BicycleMotor : IMotor
{
    public void Move(Transform transform)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 3, Space.Self);
        Debug.Log("BicycleMotor");
    }
}
