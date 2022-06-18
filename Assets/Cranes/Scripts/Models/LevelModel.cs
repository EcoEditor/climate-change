using UnityEngine;

namespace Cranes.Scripts.Models
{
    [CreateAssetMenu(fileName = "LevelModel", menuName = "ClimateChange/Models/LevelModel")]
    public class LevelModel : ScriptableObject
    {
        [SerializeField] 
        private LevelSettings[] _levelSettings;

        public LevelSettings[] LevelSettings => _levelSettings;
    }
}