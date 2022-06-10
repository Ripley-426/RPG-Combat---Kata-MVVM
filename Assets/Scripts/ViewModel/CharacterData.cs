using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "Character", menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        public StringReactiveProperty characterName = new StringReactiveProperty("Unit");
        public FloatReactiveProperty health = new FloatReactiveProperty(1000);
        public IntReactiveProperty level = new IntReactiveProperty(1);
        public BoolReactiveProperty isAlive = new BoolReactiveProperty(true);
        public List<CharacterFaction> factions = new List<CharacterFaction>();

        public ReactiveProperty<CharacterClass> characterClass;
        public int position;
    }
}
