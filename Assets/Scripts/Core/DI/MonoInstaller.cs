using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public abstract class MonoInstaller : MonoBehaviour
{
    public abstract void Install(IContainerBuilder builder);
}
