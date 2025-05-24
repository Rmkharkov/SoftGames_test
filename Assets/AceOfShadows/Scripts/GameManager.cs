using System.Collections;
using UnityEngine;

namespace AceOfShadows.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private CardStack leftStack;
        [SerializeField] private CardStack rightStack;
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject messageText;
        [SerializeField] private AceOfShadowsConfig aceOfShadowsConfig;

        private void Start()
        {
            for (int i = 0; i < aceOfShadowsConfig.totalCards; i++)
            {
                var cardGo = Instantiate(cardPrefab, leftStack.StackRoot);
                var card = cardGo.GetComponent<CardView>();
                leftStack.AddCard(card);
            }

            StartCoroutine(MoveLoop());
        }

        IEnumerator MoveLoop()
        {
            for (int i = 0; i < aceOfShadowsConfig.totalCards; i++)
            {
                Vector3 targetPos = rightStack.GetNextCardWorldPosition();
                var card = leftStack.RemoveTopCard();
                card.MoveCardTo(targetPos, rightStack.StackRoot, aceOfShadowsConfig.moveTime);
                rightStack.AddCard(card);

                yield return new WaitForSeconds(aceOfShadowsConfig.moveInterval);
            }

            messageText.SetActive(true);
        }
    }

}