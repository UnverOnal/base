using Cysharp.Threading.Tasks;
using Services.DataStorageService;

namespace GameManagement.LevelCounter
{
    public class LevelModel
    {
        public bool IsDataLoaded => _gameData != null;
        
        private readonly LevelContainer _levelContainer;
        private readonly IDataStorageService _dataStorageService;

        private int _levelIndex;
        private GameData _gameData;

        public LevelModel(LevelContainer levelContainer, IDataStorageService dataStorageService)
        {
            _levelContainer = levelContainer;
            _dataStorageService = dataStorageService;
        }

        public void UpdateLevel() => _levelIndex++;

        public LevelData GetLevelData()
        {
            _levelIndex %= _levelContainer.levels.Count;
            return _levelContainer.levels[_levelIndex];
        }

        public async UniTask LoadLevelIndex()
        {
            _gameData = await _dataStorageService.GetFileContentAsync<GameData>();
            var levelIndex = _gameData.levelIndex;
            _levelIndex = levelIndex;
        }
        
        public void SaveLevelIndex()
        {
            _gameData.levelIndex = _levelIndex;
            _dataStorageService.SetFileContent(_gameData);
        }
    }
}
