using System.Collections.Generic;
using System.Linq;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class Slide : UiTransition, IUiTransition
    {
        private IEnumerable<SlideData> _slideData;

        public Slide(IEnumerable<UiTransitionData> uiTransitionData) : base(uiTransitionData)
        {
            _slideData = this.uiTransitionData.Cast<SlideData>();
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}