using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "CharacterClass", menuName = "Data/Character Class")]
    public class CharacterClass : ScriptableObject
    {
        public StringReactiveProperty className = new StringReactiveProperty("No Class");
        public IntReactiveProperty range = new IntReactiveProperty(1);
    }
}