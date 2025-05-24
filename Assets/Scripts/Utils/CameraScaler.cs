using UnityEngine;
namespace Helpers
{
    public class CameraScaler : MonoBehaviour
    {
        public Camera targetCamera;
    
        // Размер игрового поля
        public float targetWidthInWorldUnits = 9f;
        public float targetHeightInWorldUnits = 16f;

        void Start()
        {
            if (targetCamera == null)
                targetCamera = Camera.main;

            FitToScreen();
        }

        void FitToScreen()
        {
            float screenAspect = (float)Screen.width / Screen.height;
            float targetAspect = targetWidthInWorldUnits / targetHeightInWorldUnits;

            if (screenAspect >= targetAspect)
            {
                // Экран широкий — ограничивай по высоте
                targetCamera.orthographicSize = targetHeightInWorldUnits / 2f;
            }
            else
            {
                // Экран узкий — ограничивай по ширине
                float sizeBasedOnWidth = (targetWidthInWorldUnits / screenAspect) / 2f;
                targetCamera.orthographicSize = sizeBasedOnWidth;
            }
        }
    }
}