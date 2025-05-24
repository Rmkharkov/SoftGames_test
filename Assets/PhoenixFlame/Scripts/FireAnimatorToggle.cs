using TMPro;
using UnityEngine.UI;

namespace PhoenixFlame.Scripts
{using UnityEngine;

    public class FireAnimatorToggle : MonoBehaviour
    {
        [SerializeField] private Button interactButton;
        [SerializeField] private TextMeshProUGUI buttonText;
        [SerializeField] private Animator animator;
        private bool _isRunning = true;

        private void Start()
        {
            ToggleColorLoop();
            interactButton.onClick.AddListener(ToggleColorLoop);
        }

        private void ToggleColorLoop()
        {
            _isRunning = !_isRunning;
            animator.enabled = _isRunning;

            buttonText.text = _isRunning ? "Stop animation" : "Run animation";
        }
    }

}