using System;
using Cysharp.Threading.Tasks;
using Services.SceneService;
using UnityEngine;
using VContainer;

public class Test : MonoBehaviour
{
    [Inject] private ISceneService _sceneService;

    private async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(5d));
        _sceneService.LoadScene(SceneType.GameScene);
    }
}