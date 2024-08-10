using System.Collections.Generic;
using UnityEngine;

namespace GameManagement.LevelCounter
{
    [CreateAssetMenu(fileName = "LevelContainer", menuName = "ScriptableObjects/LevelContainer")]
    public class LevelContainer : ScriptableObject
    {
        public List<LevelData> levels;
    }
}
