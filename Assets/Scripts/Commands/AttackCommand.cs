using UnityEngine;
using ViewModel;

namespace Commands
{
    public class AttackCommand: ICommand
    {
        private CharacterData _character;
        private readonly CharacterData _target;
        private readonly CharacterCommand _command;

        public AttackCommand(CharacterData character, CharacterData target, CharacterCommand command)
        {
            _character = character;
            _target = target;
            _command = command;
        }
    
        public void Execute()
        {
            if (_character == _target) return;
            float damage = _command.value;
            if (_target.level.Value - _character.level.Value >= 5) damage *= 0.5f;
            if (_character.level.Value - _target.level.Value >= 5) damage *= 1.5f;
            _target.health.Value = Mathf.Max(_target.health.Value - damage, 0);
            if (_target.health.Value <= 0)
            {
                _target.isAlive.Value = false;
            }
        }
    }
}