using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Reflection;
using Zenject;

public class MotorStrategyInstaller : MonoInstaller<MotorStrategyInstaller>
{
    public override void InstallBindings()
    {
        var motorStrategy = new MotorStrategy();
        motorStrategy.FindAssembliesAndCreateInstances();
        Container.BindInstance(motorStrategy).AsSingle();
    }
}
