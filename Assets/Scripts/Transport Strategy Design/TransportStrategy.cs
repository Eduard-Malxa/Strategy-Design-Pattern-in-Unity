using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;

public class TransportStrategy
{
    private ITransport transport;
    private List<ITransport> strategies = new List<ITransport>();

    public void FindAssembliesAndCreateInstances()
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(x => x.GetTypes())
                    .Where(x => typeof(ITransport).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).ToList();

        for (int i = 0; i < types.Count; i++)
        {
            Assembly assem = types[i].Assembly;
            System.Object _object = assem.CreateInstance(types[i].Name);
            strategies.Add((ITransport)_object);
        }
    }

    public void SetStrategy<T>() where T : ITransport
    {
        SetStrategyType(typeof(T));
    }

    private void SetStrategyType(Type strategyType)
    {
        if (strategyType.IsInterface || strategyType.IsAbstract) return;

        var newStrategy = strategies.Where(e => e.GetType() == strategyType).First();
        SetNewTransport(newStrategy);
    }

    private void SetNewTransport(ITransport newTransport)
    {
        transport = newTransport;
    }

    public void Move(Transform transform)
    {
        transport.Move(transform);
    }

    public void Disable(GameObject gameObject)
    {
        transport.Disable(gameObject);
    }

    public void Enable(GameObject gameObject)
    {
        transport.Enable(gameObject);
    }

    public void Arrived(Transform transform, Action OnArrivalCallBack)
    {
        transport.Arrived(transform, OnArrivalCallBack);
    }
}
