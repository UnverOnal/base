using UnityEngine;

namespace GameManagement.LevelCounter
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "ScriptableObjects/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int levelIndex;
    }
}