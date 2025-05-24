using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameModeSwitcher gameModeSwitcher;
        [SerializeField] private SerializedDictionary<Button, EGameMode> modesButtons;
        [SerializeField] private GameObject background;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            foreach (var keyValuePair in modesButtons)
            {
                var mode = keyValuePair.Value;
                keyValuePair.Key.onClick.AddListener(delegate{SwitchModeTo(mode);});
            }
        }

        private void SwitchModeTo(EGameMode mode)
        {
            gameModeSwitcher.SetMode(mode);
            SetButtonsActiveForGameMode(mode);
        }
        
        private void SetButtonsActiveForGameMode(EGameMode mode)
        {
            background.SetActive(mode == EGameMode.MainMenu);

            foreach (var kvp in modesButtons)
            {
                bool isMainMenuButton = kvp.Value == EGameMode.MainMenu;
                
                bool shouldBeVisible = (isMainMenuButton && mode != EGameMode.MainMenu) ||
                                       (!isMainMenuButton && mode == EGameMode.MainMenu);

                kvp.Key.gameObject.SetActive(shouldBeVisible);
            }
        }
    }
}