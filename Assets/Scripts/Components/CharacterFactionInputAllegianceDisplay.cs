﻿using System;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterFactionInputAllegianceDisplay : MonoBehaviour
    {
        public GameObject notAffiliatedImage;
        public CharacterFaction faction;
        public CharacterData characterData;

        public void Start()
        {
            characterData.factions.ObserveCountChanged()
                .Subscribe(countChangeEvent => CheckAllegiance(characterData.factions))
                .AddTo(this);
        }

        private void CheckAllegiance(ReactiveCollection<CharacterFaction> characterDataFactions)
        {
            notAffiliatedImage.SetActive(IsCharacterOutsideFaction(characterDataFactions));
        }

        private bool IsCharacterOutsideFaction(ReactiveCollection<CharacterFaction> characterDataFactions)
        {
            return !characterDataFactions.Contains(faction);
        }
    }
}