using System.Collections.Generic;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class TextReveal : IUiTransition
    {
        private IEnumerable<TextRevealData> _textRevealData;

        public TextReveal(IEnumerable<TextRevealData> textRevealData)
        {
            _textRevealData = textRevealData;
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }
    }
}