using UnityEngine;

namespace ReadyToUse.Board
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BoardData", fileName = "BoardData")]
    public class BoardData : ScriptableObject
    {
        public GameObject cell;

        [Header("Size")] 
        public int columns;
        public int rows;
    }
}
