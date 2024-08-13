using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class CustomScope : LifetimeScope
{
    [SerializeField] private List<MonoInstaller> _defaultInstallers = new();

    protected override void Configure(IContainerBuilder builder)
    {
        _defaultInstallers.ForEach(installer => installer.Install(builder));
    }

}
