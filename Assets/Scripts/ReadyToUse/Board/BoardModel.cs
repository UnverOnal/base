using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace ReadyToUse.Board
{
    public class BoardModel
    {
        public Cell[,] Board { get; }
        private readonly Dictionary<GameObject, Cell> _boardMap;

        [Inject]
        public BoardModel(BoardData boardData)
        {
            Board = new Cell[boardData.columns, boardData.rows];
            _boardMap = new Dictionary<GameObject, Cell>();
        }

        public void AddCell(Cell cell)
        {
            var location = cell.Location;
            
            Board[location.ColumnIndex, location.RowIndex] = cell;
            _boardMap.Add(cell.GameObject, cell);
        }

        public void RemoveCell(Cell cell)
        {
            var location = cell.Location;
            
            Board[location.ColumnIndex, location.RowIndex] = null;
            _boardMap.Remove(cell.GameObject);
        }

        public Cell GetCell(GameObject gameObject)
        {
            var cell = _boardMap[gameObject];
            return cell;
        }
    }
}