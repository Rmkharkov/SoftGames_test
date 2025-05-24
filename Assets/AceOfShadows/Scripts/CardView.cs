using System.Collections;
using UnityEngine;
namespace AceOfShadows.Scripts
{
    public class CardView : MonoBehaviour
    {
        public void MoveCardTo(Vector3 targetWorldPos, Transform newParent, float duration)
        {
            StartCoroutine(MoveTo(targetWorldPos, newParent, duration));
        }
        
        private IEnumerator MoveTo(Vector3 targetWorldPos, Transform newParent, float duration)
        {
            Vector3 startPos = transform.position;
            transform.SetParent(null);
            var time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime / duration;
                transform.position = Vector3.Lerp(startPos, targetWorldPos, time);
                yield return null;
            }

            transform.SetParent(newParent);
            transform.position = targetWorldPos;
        }
    }
}