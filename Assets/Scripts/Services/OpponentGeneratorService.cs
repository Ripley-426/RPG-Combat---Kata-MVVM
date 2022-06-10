using System;
using System.Collections.Generic;
using ViewModel;

namespace Services
{
    public class OpponentGeneratorService
    {
        private readonly CharacterData _player;
        private readonly CharacterData _opponent;
        private readonly List<CharacterFaction> _factions;
        private Random _random = new Random();
        private AllyCheckerService _allyCheckerService;

        public OpponentGeneratorService(CharacterData player, CharacterData opponent, List<CharacterFaction> factions)
        {
            _player = player;
            _opponent = opponent;
            _factions = factions;
            _allyCheckerService = new AllyCheckerService(_player, _opponent);
        }

        public void GenerateNextOpponent()
        {
            _opponent.factions.Clear();
            _opponent.factions.Add(_factions[_random.Next(_factions.Count)]);

            if (_allyCheckerService.IsAlly())
            {
                _opponent.characterName.Value = "Allied Soldier";
                _opponent.health.Value = _opponent.maxHealth/2;
            }
            else
            {
                _opponent.characterName.Value = "Enemy";
                _opponent.health.Value = _opponent.maxHealth;
            }
            
            _opponent.isAlive.Value = true;
        }
    }
}
