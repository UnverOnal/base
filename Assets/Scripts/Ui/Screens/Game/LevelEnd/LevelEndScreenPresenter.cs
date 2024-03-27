using GameState;

namespace UI.Screens.Game.LevelEnd
{
    public class LevelPanelEndPresenter
    {
        private readonly LevelEndPanelResources _panelResources;
        private readonly GameStatePresenter _statePresenter;
        private readonly LevelEndPanelView _levelEndPanelView;
        private readonly LevelPanelEndModel _levelPanelEndModel;

        public LevelPanelEndPresenter(LevelEndPanelResources panelResources, GameStatePresenter statePresenter)
        {
            _panelResources = panelResources;
            _statePresenter = statePresenter;
            _levelEndPanelView = new LevelEndPanelView(panelResources);
            _levelPanelEndModel = new LevelPanelEndModel();
        }

        public void Initialize()
        {
            _levelEndPanelView.Enable();
        }

        public void Close()
        {
            _levelEndPanelView.Disable();
        }
    }
}