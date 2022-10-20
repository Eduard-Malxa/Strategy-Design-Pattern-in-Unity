using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class MotorStrategy
{
    private IMotor motor;
    private List<IMotor> Strategies = new List<IMotor>();

    public void FindAssembliesAndCreateInstances()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => typeof(IMotor).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

        for (int i = 0; i < types.Count; i++)
        {
            Assembly assem = types[i].Assembly;
            System.Object _object = assem.CreateInstance(types[i].Name);
            Strategies.Add((IMotor)_object);
        }
    }

    public void SetStrategy<T>() where T : IMotor
    {
        SetStrategyType(typeof(T));
    }

    private void SetStrategyType(Type strategyType)
    {
        if (strategyType.IsInterface || strategyType.IsAbstract) return;

        var newStrategy = Strategies.Where(e => e.GetType() == strategyType).First();
        SetNewMotor(newStrategy);
    }

    private void SetNewMotor(IMotor newMotor)
    {
        motor = newMotor;
    }

    public void Move(Transform transform)
    {
        motor.Move(transform);
    }
}
