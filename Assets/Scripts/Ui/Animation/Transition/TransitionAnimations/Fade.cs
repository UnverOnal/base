using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Ui.Animation.Transition.TransitionData;

namespace Ui.Animation.Transition.TransitionAnimations
{
    public class Fade :UiTransition, IUiTransition
    {
        private readonly IEnumerable<FadeData> _fadeData;

        public Fade(IEnumerable<UiTransitionData> uiTransitionData) : base(uiTransitionData)
        {
            _fadeData = this.uiTransitionData.Cast<FadeData>();
        }

        public async void Enable()
        {
            foreach (var data in _fadeData)
            {
                if (data.delayTime > 0f)
                    await UniTask.Delay(TimeSpan.FromSeconds(data.delayTime));
                UiAnimationHelper.FadeIn(data.duration, data.canvasGroup);
            }
        }

        public async void Disable()
        {
            var reversedFadeData = _fadeData.Reverse();

            foreach (var data in reversedFadeData)
            {
                if (data.delayTime > 0f)
                    await UniTask.Delay(TimeSpan.FromSeconds(data.delayTime));
                UiAnimationHelper.FadeOut(data.duration, data.canvasGroup);
            }
        }
    }
}