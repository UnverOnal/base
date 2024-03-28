
using Ui.Animation.Transition;

namespace UI.Screens.Game
{
    public class GameScreenView : ScreenView
    {
        private readonly GameScreenResources _resources;

        public GameScreenView(GameScreenResources screenResources)
        {
            _resources = screenResources;
            CreateTransitions(UiTransitionType.Fade, screenResources.fadeData);
        }
    }
}