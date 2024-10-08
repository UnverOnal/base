using GameState;
using VContainer;

namespace UI.Screens.Home
{
    public class HomeScreenPresenter : ScreenPresenter
    {
        private readonly HomeScreenResources _resources;
        private readonly HomeScreenView _screenView;

        [Inject]
        public HomeScreenPresenter(HomeScreenResources resources, GameStatePresenter statePresenter) : base(statePresenter)
        {
            _resources = resources;
            _screenView = new HomeScreenView(resources, statePresenter);
        }

        public override void Initialize()
        {
            base.Initialize();
            _screenView.Enable();
            _resources.playButton.onClick.AddListener(_screenView.OnPlayButtonClicked);
        }

        protected override void OnStateUpdate(GameManagement.GameState.GameState gameState)
        {
            if(gameState == GameManagement.GameState.GameState.Home)
                _screenView.Enable();
            else if(_screenView.IsActive)
                _screenView.Disable();
        }
    }
}