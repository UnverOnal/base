using System.Collections.Generic;
using Ui.Animation.Transition;
using Ui.Animation.Transition.TransitionData;

namespace UI.Screens
{
    public abstract class ScreenView
    {
        public bool IsActive { get; private set; }

        private readonly List<IUiTransition> _uiTransitions;
        private readonly UiTransitionFactory _factory;

        protected ScreenView()
        {
            _uiTransitions = new List<IUiTransition>();
            _factory = new UiTransitionFactory();
        }

        public void Enable()
        {
            IsActive = true;
            for (var i = 0; i < _uiTransitions.Count; i++)
                _uiTransitions[i]?.Enable();
        }

        public void Disable()
        {
            IsActive = false;
            for (var i = 0; i < _uiTransitions.Count; i++)
                _uiTransitions[i]?.Disable();
        }

        protected void CreateTransitions(UiTransitionType type, IEnumerable<UiTransitionData> uiTransitionData)
        {
            _uiTransitions.Add(_factory.GetTransition(type, uiTransitionData));
        }
    }
}