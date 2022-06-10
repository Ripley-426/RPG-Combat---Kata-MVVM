using Services;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class AttackCommand: ICommand
    {
        private readonly CharacterData _character;
        private readonly CharacterData _target;
        private readonly DamageSkill _damageSkill;
        private readonly AllyCheckerService _allyCheckerService;

        public AttackCommand(CharacterData character, CharacterData target, DamageSkill damageSkill,
            AllyCheckerService allyCheckerService)
        {
            _character = character;
            _target = target;
            _damageSkill = damageSkill;
            _allyCheckerService = allyCheckerService;
        }
    
        public void Execute()
        {
            if (IsTargetItself) return;
            if (IsTargetOutsideClassRange) return;
            if (_allyCheckerService.IsAlly()) return;
            float damage = _damageSkill.damage;
            
            if (IsTargetStronger) damage *= 0.5f;
            if (IsTargetWeaker) damage *= 1.5f;
            _target.health.Value = ReduceHealthUntilZero(damage);
            if (IsHealthZero)
            {
                _target.isAlive.Value = false;
            }
        }

        private bool IsTargetItself => _character == _target;
        private bool IsTargetStronger => _target.level.Value - _character.level.Value >= 5;
        private bool IsTargetWeaker => _character.level.Value - _target.level.Value >= 5;
        private bool IsHealthZero => _target.health.Value == 0;
        private int GetDistanceToTarget => Mathf.Abs(_target.position - _character.position);
        private bool IsTargetOutsideClassRange => GetDistanceToTarget > _character.characterClass.Value.range.Value;
        
        private float ReduceHealthUntilZero(float damage)
        {
            return Mathf.Max(_target.health.Value - damage, 0);
        }
    }
}
