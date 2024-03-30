using GameState;
using Ui.Animation.Transition;

namespace UI.Screens.Home
{
    public class HomeScreenView : ScreenView
    {
        private readonly GameStatePresenter _statePresenter;
        private readonly HomeScreenResources _resources;

        public HomeScreenView(HomeScreenResources screenResources, GameStatePresenter statePresenter) : base(screenResources)
        {
            _statePresenter = statePresenter;
            _resources = screenResources;
            CreateTransitions(UiTransitionType.Slide, screenResources.slideData);
            CreateTransitions(UiTransitionType.ScaleUp, screenResources.scaleUpData);
        }

        public void OnPlayButtonClicked()
        {
            _statePresenter.UpdateGameState(GameManagement.GameState.GameState.Game);
            Disable();
        }
    }
}