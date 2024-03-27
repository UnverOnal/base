using Ui.Animation.Transition.TransitionAnimations;

namespace UI.Screens.Game
{
    public class GameScreenView : ScreenView
    {
        private readonly GameScreenResources _resources;
        
        public GameScreenView(GameScreenResources screenResources)
        {
            _resources = screenResources;
        }

        protected override void CreateTransitions()
        {
            uiTransitions.Add(new Fade(_resources.fadeData));
        }
    }
}
