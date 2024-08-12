using System;
using UnityEngine;

namespace Services.InputService
{
    public class InputService : IInputService
    {
        public event Action<Vector3> OnTap;
        public event Action<Vector3> OnHold;
        public event Action OnRelease;
        public event Action<GameObject> OnItemPicked;

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
                Pick();
                _startingPosition = PointerPosition;
            }

            if (IsPointerUp)
                OnRelease?.Invoke();

            if (IsPointerHold)
                OnHold?.Invoke(PointerPosition);
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

        private float GetDragOnSingleAxis(Vector3 axis, float sensitivity)
        {
            var input = Vector3.Dot(axis, DeltaPosition) * sensitivity / Screen.width;
            return input;
        }

        ///Picks item selected by using tap/click. Doesn't run if OnItemPicked event is not subscribed.
        private void Pick()
        {
            if(OnItemPicked == null)
                return;

            var pickedGameObject = GetSelectedGameObject2D();
            pickedGameObject ??= GetSelectedGameObject3D();
            if(pickedGameObject != null)
                OnItemPicked.Invoke(pickedGameObject);
        }

        private GameObject GetSelectedGameObject3D()
        {
            GameObject pickedGameObject = null;
            var ray = Camera.main.ScreenPointToRay(PointerPosition);

            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
                pickedGameObject = hit.transform.gameObject;

            return pickedGameObject;
        }

        private GameObject GetSelectedGameObject2D()
        {
            GameObject pickedGameObject = null;
            Vector2 worldPointerPosition = Camera.main.ScreenToWorldPoint(PointerPosition);

            var hit = Physics2D.Raycast(worldPointerPosition, Vector2.zero);

            if (hit.collider != null)
                pickedGameObject = hit.collider.gameObject;

            return pickedGameObject;
        }
    }
}