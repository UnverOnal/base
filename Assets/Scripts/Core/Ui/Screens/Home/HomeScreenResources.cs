using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;
using UnityEngine.UI;
using VContainer;

namespace UI.Screens.Home
{
    public class HomeScreenResources : ScreenResources
    {
        public Button playButton;
        public List<ScaleUpData> scaleUpData;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(this);
        }
    }
}