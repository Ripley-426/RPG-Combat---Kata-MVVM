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
            _target.health.Value = Mathf.Max(_target.health.Value - _command.value, 0);
            if (_target.health.Value <= 0)
            {
                _target.isAlive.Value = false;
            }
        }
    }
}