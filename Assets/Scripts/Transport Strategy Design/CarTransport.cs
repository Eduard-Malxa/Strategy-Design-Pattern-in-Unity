using System;
using UnityEngine;

public class CarTransport : ITransport
{
    public void Arrived(Transform transform, Action OnArrivalCallBack)
    {
        OnArrivalCallBack?.Invoke();
        Disable(transform.gameObject);
        transform.position = Vector3.zero;
    }

    public void Disable(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void Enable(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void Move(Transform transform)
    {
        Vector3 waveMovement = new Vector3(transform.position.x, Mathf.Sin(30 * Time.time) * 0.05f, transform.position.z);
        transform.position = waveMovement;
        transform.Translate(Vector3.right * Time.deltaTime * 5, Space.Self);
        Debug.Log("CarVehicle");
    }
}
