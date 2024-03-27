using System.Collections.Generic;
using Ui.Animation.Transition;

namespace UI.Screens
{
    public abstract class ScreenView
    {
        public bool IsActive { get; private set; }

        protected readonly List<IUiTransition> uiTransitions;

        protected ScreenView()
        {
            uiTransitions = new List<IUiTransition>();
        }

        public void Enable()
        {
            IsActive = true;
            for (int i = 0; i < uiTransitions.Count; i++)
                uiTransitions[i].Enable();
        }

        public void Disable()
        {
            IsActive = false;
            for (int i = 0; i < uiTransitions.Count; i++)
                uiTransitions[i].Disable();
        }

        protected abstract void CreateTransitions();
    }
}
