using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace MagicWords.Scripts
{
    [CreateAssetMenu(fileName = "EmojisConfig", menuName = "Configs/EmojisConfig", order = 0)]
    public class EmojisConfig : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<string, string> emojis = new SerializedDictionary<string, string>();

        public string GetEmoji(string text)
        {
            return emojis.GetValueOrDefault(text);
        }
    }
}