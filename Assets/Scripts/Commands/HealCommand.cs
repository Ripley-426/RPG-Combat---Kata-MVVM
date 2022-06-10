using System;
using Services;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class HealCommand: ICommand
    {
        private readonly CharacterData _character;
        private readonly CharacterData _target;
        private readonly HealingSkill _healingSkill;
        private readonly AllyCheckerService _allyCheckerService;

        public HealCommand(CharacterData character, CharacterData target, HealingSkill healingSkill,
            AllyCheckerService allyCheckerService)
        {
            _character = character;
            _target = target;
            _healingSkill = healingSkill;
            _allyCheckerService = allyCheckerService;
        }
        public void Execute()
        {
            if (IsTargetDead) return;
            if (IsTargetOtherThanItself && TargetIsNotAlly) return;
            _target.health.Value = IncreaseHealthUpToMaxHealthValue;
            if(_target.health.Value == _target.maxHealth) {_target.onFullHealth.OnNext(true);}
        }

        private bool IsTargetDead => _target.isAlive.Value == false;
        private bool TargetIsNotAlly => !_allyCheckerService.IsAlly();
        private bool IsTargetOtherThanItself => _target != _character;
        private float IncreaseHealthUpToMaxHealthValue => Mathf.Min(_target.health.Value + _healingSkill.heal, 1000);
    }
}