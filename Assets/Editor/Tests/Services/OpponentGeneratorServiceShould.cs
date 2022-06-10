using System.Collections.Generic;
using NUnit.Framework;
using Services;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Services
{
    [TestFixture]
    public class OpponentGeneratorServiceShould
    {
        private OpponentGeneratorService _opponentGeneratorService;
        private readonly CharacterData _player = ScriptableObject.CreateInstance<CharacterData>();
        private readonly CharacterData _opponent = ScriptableObject.CreateInstance<CharacterData>();
        private readonly CharacterFaction _faction = ScriptableObject.CreateInstance<CharacterFaction>();
        private readonly List<CharacterFaction> _factions = new List<CharacterFaction>();

        [SetUp]
        public void Setup()
        {
            _factions.Add(_faction);
        }

        [Test]
        public void ReviveOpponent()
        {
            _opponentGeneratorService = new OpponentGeneratorService(
                _player, _opponent, _factions);
            _opponent.isAlive.Value = false;
            _opponentGeneratorService.GenerateNextOpponent();
            
            Assert.IsTrue(_opponent.isAlive.Value);
        }
        
        [Test]
        public void AssignOneFactionToNewOpponent()
        {
            _factions.Add(_faction);
            _opponentGeneratorService = new OpponentGeneratorService(
                _player, _opponent, _factions);
            _opponentGeneratorService.GenerateNextOpponent();
            
            Assert.AreEqual(1, _opponent.factions.Count);
        }
    }
}