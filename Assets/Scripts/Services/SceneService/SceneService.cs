using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Services.SceneService
{
    public class SceneService : ISceneService
    {
        private readonly SceneDataContainer _sceneDataContainer;

        /// <summary>
        /// Called right after the loading of the scene.
        /// </summary>
        public event Action OnSceneLoaded;
        
        /// <summary>
        /// Called right before the unloading of the scene.
        /// </summary>
        public event Action OnSceneUnloaded;
        
        public event Action<float> OnProgressUpdated;
        
        private AsyncOperationHandle<SceneInstance> _sceneHandle;

        public SceneService(SceneDataContainer sceneDataContainer)
        {
            _sceneDataContainer = sceneDataContainer;
        }

        public async void LoadScene(SceneType type)
        {
            var sceneData = _sceneDataContainer.GetSceneData(type);
            
            if (_sceneHandle.IsValid())
                UnloadSceneAsync(_sceneHandle);

            AsyncOperationHandle<SceneInstance> loadingHandle = default;
            if (sceneData.ShowLoadingScene)
            {
                loadingHandle =
                    Addressables.LoadSceneAsync(sceneData.loadingScene.type.ToString(), LoadSceneMode.Additive);
                await UniTask.WaitUntil(() => loadingHandle.IsDone);
            }

            LoadSceneAsync(sceneData, loadingHandle);
        }
        
        private async void LoadSceneAsync(SceneData sceneData, AsyncOperationHandle<SceneInstance> loadingHandle)
        {
            _sceneHandle = Addressables.LoadSceneAsync(sceneData.type.ToString(), LoadSceneMode.Additive);
            _sceneHandle.Completed += _ =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneData.type.ToString()));
               
                OnSceneLoaded?.Invoke();

                if (sceneData.ShowLoadingScene)
                    UnloadSceneAsync(loadingHandle);
            };

            while (!_sceneHandle.IsDone)
            {
                OnProgressUpdated?.Invoke(_sceneHandle.PercentComplete);
            
                await UniTask.Yield();
            }
        }

        private void UnloadSceneAsync(AsyncOperationHandle<SceneInstance> handle)
        {
            OnSceneUnloaded?.Invoke();

            if (handle.IsDone)
                Addressables.UnloadSceneAsync(handle);
        }
    }
}