using GameManagement;
using GameManagement.LevelCounter;
using GameManagement.LifeCycle;
using GameState;
using UI.Screens.Game;
using UI.Screens.Home;
using Ui.Screens.LevelEnd;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameScope : CustomScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterEntryPoint<GameSceneManager>();

            RegisterScreens(builder);

            builder.Register<GameStatePresenter>(Lifetime.Singleton);

            RegisterLevel(builder);
        }

        private void RegisterScreens(IContainerBuilder builder)
        {
            builder.Register<IGameUnit, HomeScreenPresenter>(Lifetime.Singleton).AsSelf();
            builder.Register<IGameUnit, GameScreenPresenter>(Lifetime.Singleton).AsSelf();
            builder.Register<IGameUnit, LevelEndScreenPresenter>(Lifetime.Singleton).AsSelf();
        }

        private void RegisterLevel(IContainerBuilder builder)
        {
            builder.Register<LevelPresenter>(Lifetime.Singleton);
        }
    }
}