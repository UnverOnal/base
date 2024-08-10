using Cysharp.Threading.Tasks;
using Services.DataStorageService;
using VContainer;

namespace GameManagement.LevelCounter
{
    public class LevelPresenter
    {
        private readonly LevelModel _levelModel;

        [Inject]
        public LevelPresenter(LevelContainer levelContainer, IDataStorageService dataStorageService)
        {
            _levelModel = new LevelModel(levelContainer, dataStorageService);
        }

        public async UniTask<LevelData> GetNextLevelData()
        {
            if(!_levelModel.IsDataLoaded)
                await _levelModel.LoadLevelIndex();
            
            _levelModel.UpdateLevel();
            return _levelModel.GetLevelData();
        }

        public LevelData GetCurrentLevelData()
        {
            return _levelModel.GetLevelData();
        }

        public void SaveLevel() => _levelModel.SaveLevelIndex();
    }
}
