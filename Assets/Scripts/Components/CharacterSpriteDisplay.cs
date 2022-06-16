using System;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace Components
{
    public class CharacterSpriteDisplay : MonoBehaviour
    {
        public Image characterSprite;
        public CharacterData characterData;

        public void Start()
        {
            characterSprite.sprite = characterData.characterImage;
        }
    }
}
