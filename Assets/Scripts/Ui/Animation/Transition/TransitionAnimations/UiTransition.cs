using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public abstract class UiTransition
    {
        private readonly IEnumerable<UiTransitionData> _uiAnimationData;

        protected UiTransition(IEnumerable<UiTransitionData> uiAnimationData)
        {
            _uiAnimationData = uiAnimationData;
        }
    }
}
