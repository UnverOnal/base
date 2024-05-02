using GameManagement;
using GameManagement.LifeCycle;
using GameState;
using UI;
using UI.Screens;
using UI.Screens.Game;
using UI.Screens.Home;
using Ui.Screens.LevelEnd;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private HomeScreenResources homeScreenResources;
        [SerializeField] private GameScreenResources gameScreenResources;
        [SerializeField] private LevelEndScreenResources levelEndScreenResources;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameSceneManager>();
            
            RegisterScreens(builder);
            
            builder.Register<GameStatePresenter>(Lifetime.Singleton);
        }
        
        private void RegisterScreens(IContainerBuilder builder)
        {
            builder.RegisterInstance(homeScreenResources);
            builder.Register<IGameUnit, HomeScreenPresenter>(Lifetime.Singleton).AsSelf();
            
            builder.RegisterInstance(gameScreenResources);
            builder.Register<IGameUnit, GameScreenPresenter>(Lifetime.Singleton).AsSelf();
            
            builder.RegisterInstance(levelEndScreenResources);
            builder.Register<IGameUnit, LevelEndScreenPresenter>(Lifetime.Singleton).AsSelf();
        }
    }
}
