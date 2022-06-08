using NUnit.Framework;
using UnityEngine;
using ViewModel;
using Commands;

namespace Editor.Tests.Commands
{
    [TestFixture]
    public class AttackCommandShould
    {
        private CharacterData _character;
        private CharacterData _opponent;
        private CharacterCommand _attackCommand;
        
        [SetUp]
        public void Setup()
        {
            _character = ScriptableObject.CreateInstance<CharacterData>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            _attackCommand = ScriptableObject.CreateInstance<CharacterCommand>();
        }
        
        [Test]
        public void ReduceTargetHealth()
        {
            int initialHealth = _opponent.health.Value;
            _attackCommand.value = 50;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();

            Assert.AreEqual(initialHealth - _attackCommand.value, _opponent.health.Value);
        }

        [Test]
        public void KillTargetIfDamageIsEqualOrHigherThanHealth()
        {
            _attackCommand.value = _opponent.health.Value + 1;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();
            
            Assert.IsFalse(_opponent.isAlive.Value);
        }
        
        [Test]
        public void NotReduceTargetHealthBelowZero()
        {
            _attackCommand.value = _opponent.health.Value + 1;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();
            
            Assert.AreEqual(0, _opponent.health.Value);
        }
    }
}
