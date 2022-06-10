using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using Components;
using UnityEditor;

namespace Editor.Tests.Scenes
{
    [TestFixture]
    public class GameSceneShould
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Game.unity");
        }
        
        [Test]
        public void HaveAllCharacterNameDisplayComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterNameDisplay>();

            Assert.IsNotEmpty(components, "No components assigned");

            foreach (var component in components)
            {
                Assert.NotNull(component.nameLabel, "Missing name label");
                Assert.NotNull(component.characterData, "Missing Character Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterLevelDisplayComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterLevelDisplay>();

            Assert.IsNotEmpty(components, "No components assigned");

            foreach (var component in components)
            {
                Assert.NotNull(component.levelLabel, "Missing level label");
                Assert.NotNull(component.characterData, "Missing Character Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterHealthDisplayComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterHealthDisplay>();

            Assert.IsNotEmpty(components, "No components assigned");

            foreach (var component in components)
            {
                Assert.NotNull(component.healthLabel,  "Missing health label");
                Assert.NotNull(component.characterData, "Missing Character Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterClassDisplayComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterClassDisplay>();

            Assert.IsNotEmpty(components, "No components assigned");
            
            foreach (var component in components)
            {
                Assert.NotNull(component.classLabel, "Missing class label");
                Assert.NotNull(component.characterData, "Missing Character Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterAttackInputComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterAttackInput>();

            Assert.IsNotEmpty(components, "No components assigned");
            
            foreach (var component in components)
            {
                Assert.NotNull(component.cmdFactory, "Missing command factory");
                Assert.NotNull(component.playerData, "Missing Player Data");
                Assert.NotNull(component.opponentData, "Missing Opponent Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterHealingInputComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterHealingInput>();

            Assert.IsNotEmpty(components, "No components assigned");
            
            foreach (var component in components)
            {
                Assert.NotNull(component.cmdFactory, "Missing command factory");
                Assert.NotNull(component.playerData, "Missing Player Data");
                Assert.NotNull(component.opponentData, "Missing Opponent Data");
            }
        }
        
        [Test]
        public void HaveAllCharacterFactionInputComponentsAssignedWithReferences()
        {
            var components = Object.FindObjectsOfType<CharacterFactionInput>();

            Assert.IsNotEmpty(components, "No components assigned");
            
            foreach (var component in components)
            {
                Assert.NotNull(component.cmdFactory, "Missing command factory");
                Assert.NotNull(component.playerData, "Missing Player Data");
            }
        }
    }
}
