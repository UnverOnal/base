using System.Collections.Generic;
using System.Linq;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class TextReveal : UiTransition, IUiTransition
    {
        private readonly IEnumerable<TextRevealData> _textRevealData;
        
        public TextReveal(IEnumerable<UiTransitionData> uiTransitionData) : base(uiTransitionData)
        {
            _textRevealData = this.uiTransitionData.Cast<TextRevealData>();
        }

        public void Enable()
        {
        }

        public void Disable()
        {
        }


    }
}