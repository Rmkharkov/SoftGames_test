using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AceOfShadows.Scripts
{
    public class CardStack : MonoBehaviour
    {
        [SerializeField] private Transform stackRoot;
        public Transform StackRoot => stackRoot;
        [SerializeField] private TMP_Text counterText;
        [SerializeField] private AceOfShadowsConfig aceOfShadowsConfig;

        private readonly List<CardView> _cards = new List<CardView>();

        public bool HasCards() => _cards.Count > 0;

        public void AddCard(CardView card)
        {
            _cards.Add(card);
            card.transform.SetParent(stackRoot);
            card.transform.localPosition = GetCardLocalPosition(_cards.Count - 1);
            card.transform.SetAsLastSibling();
            UpdateCounter();
        }

        public CardView RemoveTopCard()
        {
            if (_cards.Count == 0) return null;
            var card = _cards[^1];
            _cards.RemoveAt(_cards.Count - 1);
            UpdateCounter();
            return card;
        }

        public Vector3 GetNextCardWorldPosition()
        {
            Vector3 local = GetCardLocalPosition(_cards.Count);
            return stackRoot.TransformPoint(local);
        }

        private Vector3 GetCardLocalPosition(int index)
        {
            return new Vector3(0, aceOfShadowsConfig.yOffset * index, 0);
        }

        private void UpdateCounter()
        {
            counterText.text = _cards.Count.ToString();
        }
    }

}