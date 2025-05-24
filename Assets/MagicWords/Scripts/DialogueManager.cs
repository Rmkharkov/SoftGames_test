using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace MagicWords.Scripts
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField] private DialogueUI dialogueUI;
        [SerializeField] private Sprite fallbackAvatar;
        [SerializeField] private DialogsConfig dialogsConfig;

        void Start()
        {
            StartCoroutine(LoadAndRenderDialogue());
        }

        IEnumerator LoadAndRenderDialogue()
        {
            using UnityWebRequest request = UnityWebRequest.Get(dialogsConfig.url);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to fetch dialogue: " + request.error);
                yield break;
            }
            
            string json = request.downloadHandler.text;
            var root = JsonConvert.DeserializeObject<DialogueRoot>(json);
            
            foreach (var entry in root.dialogue)
            {        var avatarEntry = root.avatars.FirstOrDefault(a => a.name == entry.name);
                Sprite avatarSprite = fallbackAvatar;

                if (avatarEntry != null && !string.IsNullOrEmpty(avatarEntry.url))
                {
                    using UnityWebRequest avatarRequest = UnityWebRequestTexture.GetTexture(avatarEntry.url);
                    yield return avatarRequest.SendWebRequest();

                    if (avatarRequest.result == UnityWebRequest.Result.Success)
                    {
                        var tex = DownloadHandlerTexture.GetContent(avatarRequest);
                        avatarSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
                    }
                    else
                    {
                        Debug.LogWarning($"Avatar load failed for {entry.name}: {avatarRequest.error}");
                    }
                }

                entry.text = ReplaceEmojis(entry.text);
                dialogueUI.Set(entry, avatarSprite);
                yield return new WaitForSeconds(dialogsConfig.messageLifeTime);
            }
        }
        
        private string ReplaceEmojis(string input)
        {
            return Regex.Replace(input, @"\{(\w+)\}", match =>
            {
                string key = match.Groups[1].Value;
                return $"<sprite name=\"{key}\">";
            });
        }

        [System.Serializable]
        private class DialogueWrapper
        {
            public List<DialogueEntry> entries;
        }
    }
}