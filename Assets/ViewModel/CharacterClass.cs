using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "CharacterCommand", menuName = "Data/Character Command")]
    public class CharacterClass : ScriptableObject
    {
        public int range;
    }
}