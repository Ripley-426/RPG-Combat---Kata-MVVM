using Components;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Components
{
    [TestFixture]
    public class CharacterHealthDisplayShould
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
        public void ShowCharacterHealth()
        {
            var component = _gameObject.AddComponent<CharacterHealthDisplay>();
            component.healthLabel = _textField;
            component.characterData = ScriptableObject.CreateInstance<CharacterData>();

            component.Start();
            component.characterData.health.Value = 500;

            Assert.AreEqual("500/1000", _textField.text);
        }
    }
}