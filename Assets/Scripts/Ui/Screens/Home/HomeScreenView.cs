using GameState;
using Ui.Animation.Transition.TransitionAnimations;

namespace UI.Screens.Home
{
    public class HomeScreenView : ScreenView
    {
        private readonly GameStatePresenter _statePresenter;
        private readonly HomeScreenResources _resources;
        
        public HomeScreenView(HomeScreenResources screenResources, GameStatePresenter statePresenter)
        {
            _statePresenter = statePresenter;
            _resources = screenResources;
        }

        public void OnPlayButtonClicked()
        {
            _statePresenter.UpdateGameState(GameManagement.GameState.GameState.Game);
            Disable();
        }

        protected override void CreateTransitions()
        {
            uiTransitions.Add(new Fade(_resources.fadeData));
        }
    }
}
