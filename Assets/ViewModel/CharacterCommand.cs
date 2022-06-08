using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "CharacterCommand", menuName = "Data/Character Command")]
    public class CharacterCommand : ScriptableObject
    {
        public int value;
    }
}
