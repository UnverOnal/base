using Services.DataStorageService;

namespace GameManagement
{
    public class GameData : LocalSaveData
    {
        public int levelIndex;
        
        public override void SetDefault()
        {
            levelIndex = -1;
        }
    }
}
