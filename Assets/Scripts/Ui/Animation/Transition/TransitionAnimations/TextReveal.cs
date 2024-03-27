using System.Collections.Generic;
using System.Linq;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class TextReveal : UiTransition, IUiTransition
    {
        private IEnumerable<TextRevealData> _textRevealData;

        public TextReveal(IReadOnlyCollection<UiTransitionData> uiAnimationData) : base(uiAnimationData)
        {
            _textRevealData = uiAnimationData.Cast<TextRevealData>();
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}