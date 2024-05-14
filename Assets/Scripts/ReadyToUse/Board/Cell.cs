using UnityEngine;

namespace ReadyToUse.Board
{
    public class Cell
    {
        public GameObject GameObject { get; private set; }
        public BoardLocation Location{ get; private set; }
        public Vector3 Position { get; private set; }
        public Vector2 Extents => _sprite.bounds.extents * (Vector2)_scale;

        private Transform _transform;
        private Sprite _sprite;
        private Vector3 _scale;
    
        public void SetData(GameObject gameObject, BoardLocation location)
        {
            GameObject = gameObject;
            _transform = gameObject.transform;
            _sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
            
            Position = gameObject.transform.position;
            _scale = GameObject.transform.localScale;

            Location = location;
        }

        public virtual void Reset()
        {
        }
    }

    public struct BoardLocation
    {
        public BoardLocation(int columnIndex, int rowIndex)
        {
            ColumnIndex = columnIndex;
            RowIndex = rowIndex;
        }

        public int ColumnIndex { get; private set; }
        public int RowIndex { get; private set; }
    }
}
