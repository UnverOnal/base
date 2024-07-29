using System;
using UnityEngine;

namespace Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<Vector3> OnTap;
        public event Action OnRelease;
        
        public Vector3 PointerPosition { get; private set; }
        
        public bool IsPointerDown => Input.GetMouseButtonDown(0);
        public bool IsPointerUp => Input.GetMouseButtonUp(0);
        public bool IsPointerHold => Input.GetMouseButton(0);

        private Vector3 DeltaPosition => PointerPosition - _pointerPreviousPosition;
        private Vector3 _pointerPreviousPosition;
        private Vector3 _startingPosition;
        
        private bool IgnoreInput { get; set; }
        
        public void Update()
        {
            if (IgnoreInput)
                return;
            
            Track();

            if (IsPointerDown)
            {
                OnTap?.Invoke(PointerPosition);
                _startingPosition = PointerPosition;
            }
            
            if (IsPointerUp)
                OnRelease?.Invoke();
        }

        public void Ignore(bool ignore)
        {
            IgnoreInput = ignore;
        }

        public Vector3 GetDragDirection()
        {
            var startingPointerPositionWorld = new Vector3(_startingPosition.x, _startingPosition.y, 10f);
            startingPointerPositionWorld = Camera.main.ScreenToWorldPoint(startingPointerPositionWorld);
                
            var pointerPositionWorld = new Vector3(PointerPosition.x, PointerPosition.y, 10f);
            pointerPositionWorld = Camera.main.ScreenToWorldPoint(pointerPositionWorld);
                
            return (pointerPositionWorld - startingPointerPositionWorld).normalized;
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

        private void Track()
        {
            if (IsPointerDown)
            {
                PointerPosition = Input.mousePosition;
                _pointerPreviousPosition = PointerPosition;
                return;
            }
            
            _pointerPreviousPosition = PointerPosition;
            if (IsPointerHold)
                PointerPosition = Input.mousePosition;
        }
    }
}