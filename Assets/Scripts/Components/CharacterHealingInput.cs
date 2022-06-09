using Commands;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterHealingInput : MonoBehaviour
    {
        public CharacterCmdFactory cmdFactory;
        public CharacterData playerData;
        public CharacterData opponentData;
        
        public void OnClick(HealingSkill healingSkill)
        {
            cmdFactory.PerformHeal(playerData, opponentData, healingSkill).Execute();
        }
    }
}