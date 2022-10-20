using UnityEngine;

public class CarMotor : IMotor
{
    public void Move(Transform transform)
    {
        Vector3 waveMovement = new Vector3(transform.position.x, Mathf.Sin(30 * Time.time) * 0.05f, transform.position.z);
        transform.position = waveMovement;
        transform.Translate(Vector3.forward * Time.deltaTime * 3, Space.Self);
        Debug.Log("CarMotor");
    }
}
