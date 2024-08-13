using Cysharp.Threading.Tasks;
using Services.DataStorageService;
using VContainer;

namespace GameManagement.LevelCounter
{
    public class LevelPresenter
    {
        private readonly LevelModel _levelModel;

        private LevelData _currentLevel;

        [Inject]
        public LevelPresenter(IDataStorageService dataStorageService)
        {
            _levelModel = new LevelModel(dataStorageService);
        }

        public async UniTask<LevelData> GetNextLevelData()
        {
            if(!_levelModel.IsDataLoaded)
                await _levelModel.LoadLevelIndex();

            _levelModel.UpdateLevel();
            _currentLevel = await _levelModel.GetLevelData();
            return _currentLevel;
        }

        public LevelData GetCurrentLevelData()
        {
            return _currentLevel;
        }

        public void SaveLevel() => _levelModel.SaveLevelIndex();
    }
}
