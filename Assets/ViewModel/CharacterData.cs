using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "Character", menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        public FloatReactiveProperty health = new FloatReactiveProperty(1000);
        public IntReactiveProperty level = new IntReactiveProperty(1);
        public BoolReactiveProperty isAlive = new BoolReactiveProperty(true);
    }
}
