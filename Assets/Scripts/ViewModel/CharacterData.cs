using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "Character", menuName = "Data/Character")]
    public class CharacterData : ScriptableObject
    {
        private const int MAXHealth = 1000;
        public int maxHealth = MAXHealth;
        public StringReactiveProperty characterName = new StringReactiveProperty("Unit");
        public FloatReactiveProperty health = new FloatReactiveProperty(MAXHealth);
        public IntReactiveProperty level = new IntReactiveProperty(1);
        public BoolReactiveProperty isAlive = new BoolReactiveProperty(true);
        public ReactiveCollection<CharacterFaction> factions = new ReactiveCollection<CharacterFaction>();
        public readonly ISubject<bool> onFullHealth = new Subject<bool>();
        public readonly ISubject<bool> onZeroHealth = new Subject<bool>();

        public ReactiveProperty<CharacterClass> characterClass;
        public int position;
        public Sprite characterImage;
    }
}
