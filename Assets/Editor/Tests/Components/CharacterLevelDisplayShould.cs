using Components;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Components
{
    [TestFixture]
    public class CharacterLevelDisplayShould
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
        public void ShowCharacterLevel()
        {
            var component = _gameObject.AddComponent<CharacterLevelDisplay>();
            component.levelLabel = _textField;
            component.characterData = ScriptableObject.CreateInstance<CharacterData>();

            component.Start();
            component.characterData.level.Value = 5;

            Assert.AreEqual("Level: 5", _textField.text);
        }
    }
}
