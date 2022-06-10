using Commands;
using NUnit.Framework;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Commands
{
    [TestFixture]
    public class ChangeFactionStatusCommandShould
    {
        private CharacterData _characterData;
        private CharacterFaction _characterFaction;
        private ChangeFactionStatusCommand _changeFactionStatusCommand;

        [SetUp]
        public void Setup()
        {
            _characterData = ScriptableObject.CreateInstance<CharacterData>();
            _characterFaction = ScriptableObject.CreateInstance<CharacterFaction>();
        }

        [Test]
        public void JoinFactionIfNotAffiliated()
        {
            _changeFactionStatusCommand = new ChangeFactionStatusCommand(_characterData, _characterFaction);
            _changeFactionStatusCommand.Execute();
            
            CollectionAssert.Contains(_characterData.factions, _characterFaction);
        }

        [Test]
        public void LeaveFactionIfAffiliated()
        {
            _characterData.factions.Add(_characterFaction);
            
            _changeFactionStatusCommand = new ChangeFactionStatusCommand(_characterData, _characterFaction);
            _changeFactionStatusCommand.Execute();
            
            CollectionAssert.DoesNotContain(_characterData.factions, _characterFaction);
        }
    }
}