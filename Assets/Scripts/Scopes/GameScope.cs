using GameManagement;
using GameManagement.LevelCounter;
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
        
        [SerializeField] private LevelContainer levelContainer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameSceneManager>();
            
            RegisterScreens(builder);
            
            builder.Register<GameStatePresenter>(Lifetime.Singleton);
            
            RegisterLevel(builder);
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

        private void RegisterLevel(IContainerBuilder builder)
        {
            builder.Register<LevelPresenter>(Lifetime.Singleton);
            builder.RegisterInstance(levelContainer);
        }
    }
}
