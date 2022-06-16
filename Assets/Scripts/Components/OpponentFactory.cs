using System;
using System.Collections.Generic;
using Services;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class OpponentFactory: MonoBehaviour
    {
        public CharacterData player;
        public CharacterData opponent;
        public List<CharacterFaction> factions;
        private OpponentGeneratorService _opponentGeneratorService;

        public void Start()
        {
            _opponentGeneratorService = new OpponentGeneratorService(player, opponent, factions);
            _opponentGeneratorService.GenerateNextOpponent();
            
            opponent.onFullHealth
                .Subscribe(GenerateNewOpponent)
                .AddTo(this);
            opponent.onZeroHealth
                .Subscribe(GenerateNewOpponent)
                .AddTo(this);
        }

        private void GenerateNewOpponent(bool fullHeal)
        {
            _opponentGeneratorService.GenerateNextOpponent();
        }
    }
}