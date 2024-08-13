using UI.Screens;
using UnityEngine;
using VContainer;

namespace Ui.Screens.LevelEnd
{
    public class LevelEndScreenResources : ScreenResources
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(this);
        }
    }
}