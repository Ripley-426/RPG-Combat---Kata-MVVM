using NUnit.Framework;
using Services;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Services
{
    [TestFixture]
    public class AllyCheckerServiceShould
    {
        private CharacterFaction _faction;
        private CharacterFaction _secondfaction;
        private CharacterFaction _thirdfaction;
        private CharacterData _player;
        private CharacterData _opponent;
        private AllyCheckerService _allyCheckerService;
        
        [SetUp]
        public void Setup()
        {
            _faction = ScriptableObject.CreateInstance<CharacterFaction>();
            _secondfaction = ScriptableObject.CreateInstance<CharacterFaction>();
            _thirdfaction = ScriptableObject.CreateInstance<CharacterFaction>();
            _player = ScriptableObject.CreateInstance<CharacterData>();
            _opponent = ScriptableObject.CreateInstance<CharacterData>();
            
            _allyCheckerService = new AllyCheckerService(_player, _opponent);
        }
        
        [Test]
        public void ReturnTrueIfPlayerHasAtLeastOneFactionInCommonWithOpponent()
        {
            _player.factions.Add(_faction);
            _player.factions.Add(_secondfaction);
            _opponent.factions.Add(_faction);
            _opponent.factions.Add(_thirdfaction);
            
            Assert.True(_allyCheckerService.IsAlly());
        }

        [Test]
        public void ReturnFalseIfPlayerHasNoFactionsInCommonWithOpponent()
        {
            Assert.False(_allyCheckerService.IsAlly());
        }
    }
}