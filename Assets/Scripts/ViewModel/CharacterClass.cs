using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "Data/Character Class")]
    public class CharacterClass : ScriptableObject
    {
        public int range;
    }
}