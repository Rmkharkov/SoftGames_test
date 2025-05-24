using TMPro;
using UnityEngine;
namespace Utils
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI fpsText;
        [SerializeField] private float updateInterval = 0.5f;

        private float _timeElapsed;
        private int _frames;

        void Update()
        {
            _timeElapsed += Time.unscaledDeltaTime;
            _frames++;

            if (_timeElapsed >= updateInterval)
            {
                float fps = _frames / _timeElapsed;
                fpsText.text = $"FPS: {Mathf.RoundToInt(fps)}";
                _timeElapsed = 0f;
                _frames = 0;
            }
        }
    }
}