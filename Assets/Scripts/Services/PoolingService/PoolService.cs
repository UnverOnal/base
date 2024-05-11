using System;
using System.Collections.Generic;

namespace Services.PoolingService
{
    public class PoolService : IPoolService
    {
        private readonly Dictionary<Type, object> _pools = new();

        public ObjectPool<T> GetPool<T>(Func<T> creator, bool canExpand = true, int maxSize = 0)
        {
            var poolType = typeof(T);
            if (!_pools.TryGetValue(poolType, out var pool))
            {
                pool = new ObjectPool<T>(creator, canExpand, maxSize);
                _pools.Add(poolType, pool);
            }

            return (ObjectPool<T>)pool;
        }
    }
}