using GameState;
using UI.Screens.Game.LevelEnd;
using VContainer;

namespace UI.Screens.Game
{
    public class GameScreenPresenter : ScreenPresenter, IScreenPresenter
    {
        private readonly GameScreenView _screenView;
        
        private readonly GameScreenResources _resources;
        private readonly LevelEndPresenter _levelEndPresenter;

        [Inject]
        public GameScreenPresenter(GameScreenResources resources, GameStatePresenter statePresenter) : base(statePresenter)
        {
            _resources = resources;
            _screenView = new GameScreenView(resources);
            _levelEndPresenter = new LevelEndPresenter(resources.levelEndResources, statePresenter);
        }

        public void Initialize()
        {
            SetStateAction();
        }

        protected override void OnStateUpdate(GameState.GameState gameState)
        {
            switch (gameState)
            {
                case GameState.GameState.Game:
                    OnGameStart();
                    break;
                case GameState.GameState.LevelEnd:
                    OnLevelEndStart();
                    break;
                default:
                    _screenView.Disable();
                    _levelEndPresenter.Close();
                    break;
            }
        }

        private void OnGameStart()
        {
            _screenView.Enable();
            _resources.inGameObject.SetActive(true);
        }

        private void OnLevelEndStart()
        {
            _resources.inGameObject.SetActive(false);
            _levelEndPresenter.Initialize();
        }
    }
}