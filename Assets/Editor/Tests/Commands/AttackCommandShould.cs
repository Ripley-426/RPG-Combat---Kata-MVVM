using NUnit.Framework;
using UnityEngine;
using ViewModel;
using Commands;
using Services;
using UniRx;

namespace Editor.Tests.Commands
{
    [TestFixture]
    public class AttackCommandShould
    {
        private CharacterData _player;
        private CharacterData _opponent;
        private DamageSkill _damageSkill;
        private CharacterClass _meleeClass;
        private CharacterClass _rangedClass;
        private AllyCheckerService _allyCheckerService;
        
        [SetUp]
        public void Setup()
        {
            _player = ScriptableObject.CreateInstance<CharacterData>();
            _player.characterClass = new ReactiveProperty<CharacterClass>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            _opponent.characterClass = new ReactiveProperty<CharacterClass>();
            _damageSkill = ScriptableObject.CreateInstance<DamageSkill>();
            _meleeClass = ScriptableObject.CreateInstance<CharacterClass>();
            _meleeClass.range.Value = 2;
            _rangedClass = ScriptableObject.CreateInstance<CharacterClass>();
            _rangedClass.range.Value = 20;

            _player.characterClass.Value = _rangedClass;
            _opponent.characterClass.Value = _meleeClass;

            _allyCheckerService = new AllyCheckerService(_player, _opponent);
        }
        
        [Test]
        public void ReduceTargetHealth()
        {
            float initialHealth = _opponent.health.Value;
            _damageSkill.damage = 50;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();

            Assert.AreEqual(initialHealth - _damageSkill.damage, _opponent.health.Value);
        }

        [Test]
        public void KillTargetIfDamageIsEqualOrHigherThanHealth()
        {
            _damageSkill.damage = _opponent.health.Value + 1;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();
            
            Assert.IsFalse(_opponent.isAlive.Value);
        }
        
        [Test]
        public void NotReduceTargetHealthBelowZero()
        {
            _damageSkill.damage = _opponent.health.Value + 1;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();
            
            Assert.AreEqual(0, _opponent.health.Value);
        }
        
        [Test]
        public void NotLetACharacterDealDamageToItself()
        {
            float initialHealth = _player.health.Value;
            _damageSkill.damage = initialHealth/2;

            var command = new AttackCommand(_player, _player, _damageSkill, _allyCheckerService);
            command.Execute();
            
            Assert.AreEqual(initialHealth, _player.health.Value);
        }
        
        [Test]
        public void DealLessDamageToHigherLevelTarget()
        {
            const float damageReductionPercentage = 0.5f;
            float initialHealth = _opponent.health.Value;
            _damageSkill.damage = 50;
            _opponent.level.Value = 6;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();

            Assert.AreEqual(initialHealth - _damageSkill.damage * damageReductionPercentage, _opponent.health.Value);
        }
        
        [Test]
        public void DealMoreDamageToLowerLevelTarget()
        {
            const float damageIncreasePercentage = 1.5f;
            float initialHealth = _opponent.health.Value;
            _damageSkill.damage = 50;
            _player.level.Value = 6;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();

            Assert.AreEqual(initialHealth - _damageSkill.damage * damageIncreasePercentage, _opponent.health.Value);
        }
        
        [Test]
        public void NotDealDamageToATargetOutsideRange()
        {
            float initialHealth = _opponent.health.Value;
            _damageSkill.damage = 50;
            _opponent.position = 25;

            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();

            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }

        [Test]
        public void NotDealDamageToAnAlly()
        {
            float initialHealth = _opponent.health.Value;
            CharacterFaction faction = ScriptableObject.CreateInstance<CharacterFaction>();
            _player.factions.Add(faction);
            _opponent.factions.Add(faction);
            
            var command = new AttackCommand(_player, _opponent, _damageSkill, _allyCheckerService);
            command.Execute();
            
            Assert.AreEqual(initialHealth, _opponent.health.Value);
        }
    }
}
