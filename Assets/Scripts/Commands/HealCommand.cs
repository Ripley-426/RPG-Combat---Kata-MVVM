using System;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class HealCommand: ICommand
    {
        private readonly CharacterData _character;
        private readonly CharacterData _target;
        private readonly CharacterCommand _command;

        public HealCommand(CharacterData character, CharacterData target, CharacterCommand command)
        {
            _character = character;
            _target = target;
            _command = command;
        }
        public void Execute()
        {
            if (IsTargetDead) return;
            if (IsTargetOtherThanItself) return;
            _target.health.Value = IncreaseHealthUpToMaxHealthValue;
        }

        private bool IsTargetDead => _target.isAlive.Value == false;
        private bool IsTargetOtherThanItself => _target != _character;
        private float IncreaseHealthUpToMaxHealthValue => Mathf.Min(_target.health.Value + _command.value, 1000);
    }
}