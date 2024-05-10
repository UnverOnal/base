namespace Services.DataStorageService
{
    public abstract class LocalSaveData
    {
        public string version;

        public abstract void SetDefault();
    }
}
