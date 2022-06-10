using Commands;
using NUnit.Framework;
using Services;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Commands
{
    [TestFixture]
    public class HealCommandShould
    {
        private CharacterData _player;
        private CharacterData _opponent;
        private HealingSkill _healingSkill;
        private AllyCheckerService _allyCheckerService;
        
        [SetUp]
        public void Setup()
        {
            _player = ScriptableObject.CreateInstance<CharacterData>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            _healingSkill = ScriptableObject.CreateInstance<HealingSkill>();
            _allyCheckerService = new AllyCheckerService(_player, _opponent);
        }
        
        [Test]
        public void HealDamagedTargets()
        {
            const int initialHealth = 500;
            const int healValue = 50;
            _player.health.Value = initialHealth;
            _healingSkill.heal = healValue;

            var command = CreateNewHealCommandToHealItself();
            command.Execute();
            
            Assert.AreEqual(initialHealth + healValue, _player.health.Value);
        }

        [Test]
        public void NotHealDeadTargets()
        {
            const int initialHealth = 0;
            _opponent.health.Value = initialHealth;
            _opponent.isAlive.Value = false;

            var command = CreateNewHealCommandToHealItself();
            command.Execute();
            
            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }
        
        [Test]
        public void NotOverHeal()
        {
            const int healValue = 50;
            float initialHealth = _player.health.Value - 25;
            _player.health.Value = initialHealth;
            _healingSkill.heal = healValue;

            var command = CreateNewHealCommandToHealItself();
            command.Execute();
            
            Assert.AreEqual(1000, _player.health.Value);
        }
        
        [Test]
        public void NotLetACharacterHealOthersNotAlliedToItself()
        {
            const int initialHealth = 500;
            const int healValue = 50;
            _opponent.health.Value = initialHealth;
            _healingSkill.heal = healValue;

            var command = CreateNewHealCommandToHealItself();
            command.Execute();
            
            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }

        [Test]
        public void HealAlliedCharacters()
        {
            CharacterFaction faction = ScriptableObject.CreateInstance<CharacterFaction>();
            _player.factions.Add(faction);
            _opponent.factions.Add(faction);
            _opponent.health.Value = 500;
            const int healValue = 50;
            _healingSkill.heal = healValue;
            
            float initialHealth = _opponent.health.Value;
            
            var command = CreateNewHealCommandToHealOpponent();
            command.Execute();
            
            Assert.AreEqual(initialHealth + healValue, _opponent.health.Value);
        }

        private HealCommand CreateNewHealCommandToHealItself()
        {
            return new HealCommand(_player, _player, _healingSkill, _allyCheckerService);
        }
        
        private HealCommand CreateNewHealCommandToHealOpponent()
        {
            return new HealCommand(_player, _opponent, _healingSkill, _allyCheckerService);
        }
    }
}