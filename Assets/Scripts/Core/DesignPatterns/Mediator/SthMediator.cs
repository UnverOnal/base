using System;
using GameManagement.LifeCycle;
using UnityEngine;
using VContainer;

namespace Core.DesignPatterns.Mediator
{
    public class SthMediator : IGameUnit
    {
        [Inject]private readonly ConcreteColleague concreteColleague;

        public void Initialize()
        {
            concreteColleague.SetMediator(this);
        }

        public void Dispose()
        {
        }

        public void Notify()
        {
        }
    }
}
