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
        private readonly IEnumerable<IUpdateable> _updateables;

        private readonly bool _canUpdate;

        [Inject]
        public GameSceneManager(IEnumerable<IUpdateable> updateables)
        {
            _updateables = updateables;

            _canUpdate = !_updateables.Any();
        }

        public void Initialize()
        {
            foreach (var gameUnit in _gameUnits)
                gameUnit.Initialize();
        }

        public void Tick()
        {
            if(!_canUpdate) return;

            foreach (var updateable in _updateables)
                updateable.Update();
        }

        public void Dispose()
        {
            foreach (var gameUnit in _gameUnits)
                gameUnit.Dispose();
        }
    }
}
