using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens.Game
{
    public class GameScreenResources : ScreenResources
    {
        public Button homeButton;
        public List<SlideData> slideData;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(this);
        }
    }
}