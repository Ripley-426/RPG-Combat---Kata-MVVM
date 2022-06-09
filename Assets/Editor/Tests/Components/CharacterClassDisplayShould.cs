using Components;
using NUnit.Framework;
using TMPro;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Components
{
    [TestFixture]
    public class CharacterClassDisplayShould
    {
        private TextMeshProUGUI _textField;
        private GameObject _gameObject;
        
        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
            _textField = _gameObject.AddComponent<TextMeshProUGUI>();
            _textField.text = "";
        }

        [Test]
        public void ShowCharacterClass()
        {
            var component = _gameObject.AddComponent<CharacterClassDisplay>();
            component.classLabel = _textField;
            component.characterData = ScriptableObject.CreateInstance<CharacterData>();

            component.characterData.characterClass = new ReactiveProperty<CharacterClass>(ScriptableObject.CreateInstance<CharacterClass>());
            component.characterData.characterClass.Value.className.Value = "Ranged";
            component.Start();
            
                
            Assert.AreEqual("Ranged", _textField.text);
        }
    }
    
}