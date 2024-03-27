using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class Slide : IUiTransition
    {
        private IEnumerable<SlideData> _slideData;

        public Slide(IEnumerable<SlideData> slideData)
        {
            _slideData = slideData;
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}