using UnityEngine;

namespace ViewModel
{
    
    [CreateAssetMenu(fileName = "CharacterFaction", menuName = "Data/Character Faction")]
    public class CharacterFaction : ScriptableObject
    {
        public string factionName;
    }
}