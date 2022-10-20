using UnityEngine;
using Zenject;

public abstract class Vehicle : MonoBehaviour
{
    [Inject] protected MotorStrategy motorStrategy;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        motorStrategy.Move(transform);
    }

    public abstract void ActivateMotor();
}
