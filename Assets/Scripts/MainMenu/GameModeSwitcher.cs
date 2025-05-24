using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class GameModeSwitcher : MonoBehaviour
    {
        [SerializeField] private ScenesConfig scenesConfig;

        private string _lastLoadedScene;
        
        public void SetMode(EGameMode mode)
        {
            if (mode == EGameMode.MainMenu)
            {
                SceneManager.UnloadSceneAsync(_lastLoadedScene);
            } else
            {
                _lastLoadedScene = scenesConfig.GetSceneByType(mode);

                SceneManager.LoadSceneAsync(_lastLoadedScene, LoadSceneMode.Additive);
            }
        }
    }
}