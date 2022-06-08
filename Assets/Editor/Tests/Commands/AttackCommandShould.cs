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
        private CharacterClass _meleeClass;
        private CharacterClass _rangedClass;
        
        [SetUp]
        public void Setup()
        {
            _character = ScriptableObject.CreateInstance<CharacterData>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            _attackCommand = ScriptableObject.CreateInstance<CharacterCommand>();
            _meleeClass = ScriptableObject.CreateInstance<CharacterClass>();
            _meleeClass.range = 2;
            _rangedClass = ScriptableObject.CreateInstance<CharacterClass>();
            _rangedClass.range = 20;

            _character.characterClass = _rangedClass;
            _opponent.characterClass = _meleeClass;
        }
        
        [Test]
        public void ReduceTargetHealth()
        {
            float initialHealth = _opponent.health.Value;
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
        
        [Test]
        public void NotLetACharacterDealDamageToItself()
        {
            float initialHealth = _character.health.Value;
            _attackCommand.value = initialHealth/2;

            var command = new AttackCommand(_character, _character, _attackCommand);
            command.Execute();
            
            Assert.AreEqual(initialHealth, _character.health.Value);
        }
        
        [Test]
        public void DealLessDamageToHigherLevelTarget()
        {
            const float damageReductionPercentage = 0.5f;
            float initialHealth = _opponent.health.Value;
            _attackCommand.value = 50;
            _opponent.level.Value = 6;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();

            Assert.AreEqual(initialHealth - _attackCommand.value * damageReductionPercentage, _opponent.health.Value);
        }
        
        [Test]
        public void DealMoreDamageToLowerLevelTarget()
        {
            const float damageIncreasePercentage = 1.5f;
            float initialHealth = _opponent.health.Value;
            _attackCommand.value = 50;
            _character.level.Value = 6;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();

            Assert.AreEqual(initialHealth - _attackCommand.value * damageIncreasePercentage, _opponent.health.Value);
        }
        
        [Test]
        public void NotDealDamageToATargetOutsideRange()
        {
            float initialHealth = _opponent.health.Value;
            _attackCommand.value = 50;
            _opponent.position = 25;

            var command = new AttackCommand(_character, _opponent, _attackCommand);
            command.Execute();

            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }
    }
}
