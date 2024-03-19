using UnityEngine;

namespace Services.InputService
{
    public class InputService : IInputService
    {
        public bool IsPointerDown { get; private set; }
        public bool IsPointerUp { get; private set; }
        public bool IsPointerHold { get; private set; }

        public Vector3 DeltaPosition => PointerPosition - PointerPreviousPosition;
        public Vector3 PointerPreviousPosition { get; private set; }
        public Vector3 PointerPosition { get; private set; }
        public Vector3 PointerDownPosition { get; private set; }

        private bool _ignoreInput;
        
        public void Update()
        {
            if (_ignoreInput)
                return;
            
            IsPointerDown = Input.GetMouseButtonDown(0);
            IsPointerUp = Input.GetMouseButtonUp(0);
            IsPointerHold = Input.GetMouseButton(0);

            if (IsPointerDown)
            {
                PointerPosition = Input.mousePosition;
                PointerPreviousPosition = PointerPosition;
                PointerDownPosition = PointerPosition;
                return;
            }
            
            PointerPreviousPosition = PointerPosition;
            if (IsPointerHold)
                PointerPosition = Input.mousePosition;
        }

        public void IgnoreInput(bool ignore)
        {
            _ignoreInput = ignore;
        }
        
        public int GetSwipe(float sensitivity)
        {
            var input = Vector3.Dot(Vector3.right, DeltaPosition) * sensitivity / Screen.width;

            var swipeInput = (int)Mathf.Clamp(input, -1.1f, 1.1f);

            return swipeInput;
        }

        public Vector2 GetDragInput(float sensitivity)
        {
            var dragInput = new Vector2
            {
                x = GetDragOnSingleAxis(Vector3.right, sensitivity),
                y = GetDragOnSingleAxis(Vector3.up, sensitivity)
            };

            return dragInput;
        }

        private float GetDragOnSingleAxis(Vector3 axis, float sensitivity)
        {
            var input = Vector3.Dot(axis, DeltaPosition) * sensitivity / Screen.width;
            return input;
        }
    }
}