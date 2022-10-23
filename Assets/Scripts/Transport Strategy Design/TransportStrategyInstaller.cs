using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using Zenject;

public class TransportStrategyInstaller : MonoInstaller<TransportStrategyInstaller>
{
    public override void InstallBindings()
    {
        var transportStrategy = new TransportStrategy();
        transportStrategy.FindAssembliesAndCreateInstances();
        Container.BindInstance(transportStrategy).AsSingle();
    }
}
