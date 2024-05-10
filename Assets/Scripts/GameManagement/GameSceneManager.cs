using System;
using System.Collections.Generic;
using System.Linq;
using GameManagement.LifeCycle;
using VContainer;
using VContainer.Unity;

namespace GameManagement
{
    public class GameSceneManager : IInitializable, ITickable, IDisposable
    {
        [Inject] private readonly IEnumerable<IGameUnit> _gameUnits;
        private readonly IEnumerable<IUpdatable> _updatables;

        private readonly bool _canUpdate;

        [Inject]
        public GameSceneManager(IEnumerable<IUpdatable> updatables)
        {
            _updatables = updatables;

            _canUpdate = !_updatables.Any();
        }

        public void Initialize()
        {
            foreach (var gameUnit in _gameUnits)
                gameUnit.Initialize();
        }

        public void Tick()
        {
            if(!_canUpdate) return;

            foreach (var updateable in _updatables)
                updateable.Update();
        }

        public void Dispose()
        {
            foreach (var gameUnit in _gameUnits)
                gameUnit.Dispose();
        }
    }
}
