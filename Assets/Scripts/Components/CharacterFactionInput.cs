using Commands;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterFactionInput: MonoBehaviour
    {
        public CharacterCmdFactory cmdFactory;
        public CharacterData playerData;
        
        public void OnClick(CharacterFaction faction)
        {
            cmdFactory.ChangeFaction(playerData, faction).Execute();
        }
    }
}