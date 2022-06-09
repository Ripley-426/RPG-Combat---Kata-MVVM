using UnityEngine;
using ViewModel;

namespace Commands
{
    [CreateAssetMenu(fileName = "CharacterCmdFactory", menuName = "Command Factory/Character")]
    public class CharacterCmdFactory: ScriptableObject
    {
        public AttackCommand PerformAttack(CharacterData characterData, CharacterData opponentData, DamageSkill damageSkill)
        {
            return new AttackCommand(characterData, opponentData, damageSkill);
        }

        public HealCommand PerformHeal(CharacterData playerData, CharacterData opponentData, HealingSkill healingSkill)
        {
            return new HealCommand(playerData, opponentData, healingSkill);
        }
    }
}