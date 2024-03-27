using GameState;
using Ui.Screens.LevelEnd;
using VContainer;

namespace UI.Screens.Game
{
    public class GameScreenPresenter : ScreenPresenter
    {
        private readonly GameScreenView _screenView;
        
        private readonly GameScreenResources _resources;
        private readonly LevelEndScreenPresenter _levelEndScreenPresenter;

        [Inject]
        public GameScreenPresenter(GameScreenResources resources, GameStatePresenter statePresenter) : base(statePresenter)
        {
            _resources = resources;
            _screenView = new GameScreenView(resources);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void OnStateUpdate(GameManagement.GameState.GameState gameState)
        {
            if (gameState == GameManagement.GameState.GameState.Game)
                _screenView.Enable();
            else if(_screenView.IsActive)
                _screenView.Disable();
        }
    }
}