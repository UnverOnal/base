using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class ScaleUp : IUiTransition
    {
        private IEnumerable<ScaleUpData> _scaleUpData;

        public ScaleUp(IEnumerable<ScaleUpData> scaleUpData)
        {
            _scaleUpData = scaleUpData;
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}