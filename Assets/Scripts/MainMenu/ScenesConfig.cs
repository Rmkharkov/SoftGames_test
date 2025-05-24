using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    [CreateAssetMenu(fileName = "ScenesConfig", menuName = "Configs/ScenesConfig", order = 0)]
    public class ScenesConfig : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<EGameMode, string> scenes = new SerializedDictionary<EGameMode, string>();

        public string GetSceneByType(EGameMode gameMode)
        {
            return scenes.GetValueOrDefault(gameMode);
        }
    }
}