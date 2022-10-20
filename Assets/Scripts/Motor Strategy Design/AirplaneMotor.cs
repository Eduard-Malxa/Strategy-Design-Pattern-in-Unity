using UnityEngine;

public class AirplaneMotor : IMotor
{
    public void Move(Transform transform)
    {
        Vector3 waveMovement = new Vector3(transform.position.x, Mathf.Sin(1 * Time.time) * 2, transform.position.z);
        transform.position = waveMovement;
        transform.Translate(Vector3.forward * Time.deltaTime * 3, Space.Self);
        Debug.Log("AirplaneMotor");
    }
}
