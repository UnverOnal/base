using System;
using System.Collections.Generic;

namespace Services.PoolingService
{
    public class PoolService : IPoolService
    {
        private readonly Dictionary<string, object> _pools = new();

        public ObjectPool<T> GetPool<T>(Func<T> creator, string poolId, bool canExpand = true, int maxSize = 0)
        {
            if (!_pools.TryGetValue(poolId, out var pool))
            {
                pool = new ObjectPool<T>(creator, canExpand, maxSize);
                _pools.Add(poolId, pool);
            }

            return (ObjectPool<T>)pool;
        }
    }
}