namespace UI.Screens.Game.LevelEnd
{
    public class LevelEndPanelView
    {
        private readonly LevelEndScreenResources _screenResources;

        public LevelEndPanelView(LevelEndScreenResources screenResources)
        {
            _screenResources = screenResources;
        }

        public void Enable()
        {
            _screenResources.levelEndGameObject.SetActive(true);
        }

        public void Disable()
        {
            _screenResources.levelEndGameObject.SetActive(false);
        }
    }
}
