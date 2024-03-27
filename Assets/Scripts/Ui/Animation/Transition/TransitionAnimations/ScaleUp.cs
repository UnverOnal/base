using System.Collections.Generic;
using System.Linq;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class ScaleUp : UiTransition, IUiTransition
    {
        private IEnumerable<ScaleUpData> _scaleUpData;
        
        public ScaleUp(IReadOnlyCollection<UiTransitionData> uiAnimationData) : base(uiAnimationData)
        {
            _scaleUpData = uiAnimationData.Cast<ScaleUpData>();
        }
        
        public void Enable()
        {
            
        }

        public void Disable()
        {
            
        }
    }
}
