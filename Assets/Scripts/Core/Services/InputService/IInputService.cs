using System;
using UnityEngine;

namespace Services.InputService
{
    public interface IInputService
    {
        public event Action<Vector3> OnTap;
        public event Action<Vector3> OnHold;
        public event Action OnRelease;
        public event Action<GameObject> OnItemPicked;

        public Vector3 PointerPosition { get;}

        public bool IsPointerDown { get;}
        public bool IsPointerUp { get; }
        public bool IsPointerHold { get;}

        public void Ignore(bool ignore);
        public int GetSwipe(float sensitivity);
        public Vector2 GetDragInput(float sensitivity);
        public Vector3 GetDragDirection();
    }
}
