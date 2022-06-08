using System;
using UnityEngine;
using ViewModel;

namespace Commands
{
    public class HealCommand: ICommand
    {
        private CharacterData _character;
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
            if (_target.isAlive.Value == false) return;
            _target.health.Value = Mathf.Min(_target.health.Value + _command.value, 1000);
        }
    }
}