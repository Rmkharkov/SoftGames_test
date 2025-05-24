using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MagicWords.Scripts
{
    public class DialogueUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text messageText;
        [SerializeField] private Image avatarImage;

        private void Start()
        {
            avatarImage.gameObject.SetActive(false);
        }

        public void Set(DialogueEntry entry, Sprite avatarSprite)
        {
            avatarImage.gameObject.SetActive(true);
            nameText.text = entry.name;
            messageText.text = entry.text;
            avatarImage.sprite = avatarSprite;
        }
    }
}