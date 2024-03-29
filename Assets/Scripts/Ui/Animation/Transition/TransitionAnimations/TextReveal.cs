using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
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

        public UniTask Enable()
        {
            return UniTask.CompletedTask;
        }

        public UniTask Disable()
        {
            return UniTask.CompletedTask;
        }


    }
}