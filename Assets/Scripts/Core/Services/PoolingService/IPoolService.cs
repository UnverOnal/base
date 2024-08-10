using System;

namespace Services.PoolingService
{
    public interface IPoolService
    {
        ObjectPool<T> GetPool<T>(Func<T> creator, string poolId, bool canExpand = true, int maxSize = 0);
    }
}
