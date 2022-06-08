using Commands;
using NUnit.Framework;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Commands
{
    [TestFixture]
    public class HealCommandShould
    {
        private CharacterData _character;
        private CharacterData _opponent;
        private CharacterCommand _healCommand;
        
        [SetUp]
        public void Setup()
        {
            _character = ScriptableObject.CreateInstance<CharacterData>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            _healCommand = ScriptableObject.CreateInstance<CharacterCommand>();
        }
        
        [Test]
        public void HealDamagedTargets()
        {
            const int initialHealth = 500;
            const int healValue = 50;
            _character.health.Value = initialHealth;
            _healCommand.value = healValue;

            var command = new HealCommand(_character, _character, _healCommand);
            command.Execute();
            
            Assert.AreEqual(initialHealth + healValue, _character.health.Value);
        }

        [Test]
        public void NotHealDeadTargets()
        {
            const int initialHealth = 0;
            _opponent.health.Value = initialHealth;
            _opponent.isAlive.Value = false;

            var command = new HealCommand(_character, _opponent, _healCommand);
            command.Execute();
            
            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }
        
        [Test]
        public void NotOverHeal()
        {
            const int healValue = 50;
            float initialHealth = _character.health.Value - 25;
            _character.health.Value = initialHealth;
            _healCommand.value = healValue;

            var command = new HealCommand(_character, _character, _healCommand);
            command.Execute();
            
            Assert.AreEqual(1000, _character.health.Value);
        }
        
        [Test]
        public void NotLetACharacterHealOthers()
        {
            const int initialHealth = 500;
            const int healValue = 50;
            _opponent.health.Value = initialHealth;
            _healCommand.value = healValue;

            var command = new HealCommand(_character, _opponent, _healCommand);
            command.Execute();
            
            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }
    }
}