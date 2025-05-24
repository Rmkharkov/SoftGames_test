using UnityEngine;

namespace MagicWords.Scripts
{
    [CreateAssetMenu(fileName = "DialogsConfig", menuName = "Configs/DialogsConfig", order = 0)]
    public class DialogsConfig : ScriptableObject
    {
        public string url = "https://private-624120-softgamesassignment.apiary-mock.com/v3/magicwords";
        public float messageLifeTime = 5f;
    }
}