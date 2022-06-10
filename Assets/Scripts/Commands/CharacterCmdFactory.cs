using Services;
using UnityEngine;
using ViewModel;

namespace Commands
{
    [CreateAssetMenu(fileName = "CharacterCmdFactory", menuName = "Command Factory/Character")]
    public class CharacterCmdFactory: ScriptableObject
    {
        private AllyCheckerService _allyCheckerService;
        public AttackCommand PerformAttack(CharacterData playerData, CharacterData opponentData, DamageSkill damageSkill)
        {
            _allyCheckerService = new AllyCheckerService(playerData, opponentData);
            return new AttackCommand(playerData, opponentData, damageSkill, _allyCheckerService);
        }

        public HealCommand PerformHeal(CharacterData playerData, CharacterData opponentData, HealingSkill healingSkill)
        {
            _allyCheckerService = new AllyCheckerService(playerData, opponentData);
            return new HealCommand(playerData, opponentData, healingSkill, _allyCheckerService);
        }

        public ChangeFactionStatusCommand ChangeFaction(CharacterData playerData, CharacterFaction faction)
        {
            return new ChangeFactionStatusCommand(playerData, faction);
        }
    }
}