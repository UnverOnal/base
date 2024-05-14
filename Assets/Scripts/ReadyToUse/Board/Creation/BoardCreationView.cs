using System;
using Services.PoolingService;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ReadyToUse.Board.Creation
{
    public class BoardCreationView
    {
        private readonly BoardData _boardData;
        public event Action<Cell> OnCellCreated;
        
        private readonly ObjectPool<GameObject> _cellPrefabPool;
        private readonly ObjectPool<Cell> _cellPool;

        public BoardCreationView(IPoolService poolService, BoardData boardData)
        {
            _boardData = boardData;
            _cellPrefabPool = poolService.GetPool(() => Object.Instantiate(boardData.cell), "TilePool");
            _cellPool = poolService.GetPool(() => new Cell(), "CellPool");
        }
        
        public void CreateBoard()
        {
            for (var i = 0; i < _boardData.columns; i++)
            for (var j = 0; j < _boardData.rows; j++)
            {
                var tile = _cellPrefabPool.Get();
                var position = new Vector3(i, j);
                tile.transform.position = position;

                var cell = _cellPool.Get();
                cell.Reset();
                cell.SetData(tile, new BoardLocation(i, j));

                OnCellCreated?.Invoke(cell);
            }
        }
    }
}
