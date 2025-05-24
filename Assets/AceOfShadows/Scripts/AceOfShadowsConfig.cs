using UnityEngine;

namespace AceOfShadows.Scripts
{
    [CreateAssetMenu(fileName = "AceOfShadowsConfig", menuName = "Configs/AceOfShadowsConfig", order = 0)]
    public class AceOfShadowsConfig : ScriptableObject
    {
        public float moveInterval = 1f;
        public float moveTime = 1f;
        public int totalCards = 144;
        public float yOffset = -10f;
    }
}