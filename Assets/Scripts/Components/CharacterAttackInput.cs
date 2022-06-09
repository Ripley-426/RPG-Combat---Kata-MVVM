using Commands;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterAttackInput: MonoBehaviour
    {
        public CharacterCmdFactory cmdFactory;
        public CharacterData playerData;
        public CharacterData opponentData;
        
        public void OnClick(DamageSkill damageSkill)
        {
            cmdFactory.PerformAttack(playerData, opponentData, damageSkill).Execute();
        }
    }
}