using System;
using Cysharp.Threading.Tasks;
using Services.InputService;
using Services.SceneService;
using UnityEngine;
using VContainer;

public class Test : MonoBehaviour
{
    [Inject] private ISceneService _sceneService;
    [Inject] private IInputService _inputService;

    private void Start()
    {
        _inputService.OnItemPicked += gO =>
        {
            if (gO.CompareTag("Player"))
                Debug.Log("Yesssss-Pick");
        };

        _inputService.OnItemReleased += () => Debug.Log("Yesssss-Release");
    }

    private void Update()
    {
        // MoveSides(_inputService.GetDragInput(10f).x, Vector3.right, 5f, 10f, transform.parent);
        // Debug.Log(_inputService.GetSwipe(50f));
        //
        // if(Input.GetKeyDown(KeyCode.I))
        //     _inputService.IgnoreInput(true);
        // if (Input.GetKeyDown(KeyCode.N))
        //     _inputService.IgnoreInput(false);
    }
    
    public void MoveSides(float input ,Vector3 axis, float moveFactor, float border, Transform platform, float smoothness = 3f)
    {
        Vector3 targetPosition = transform.position + axis * input * moveFactor;
        targetPosition.x = Mathf.Clamp(targetPosition.x, platform.position.x - border, platform.position.x + border);

        MoveTo(targetPosition, smoothness);
    }
    
    public void MoveTo(Vector3 targetPosition, float smoothness)
    {
        Vector3 currentPosition = transform.position;

        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * smoothness);
        transform.position = smoothedPosition;
    }
}