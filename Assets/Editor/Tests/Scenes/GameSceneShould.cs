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
        public void HaveAllCharacterNameDisplayComponentsAssigned()
        {
            var components = Resources.FindObjectsOfTypeAll<CharacterNameDisplay>();

            foreach (var component in components)
            {
                if (EditorUtility.IsPersistent(component)) return;
                Assert.NotNull(component);
                Assert.NotNull(component.nameLabel);
                Assert.NotNull(component.characterData);
            }
        }
        
        [Test]
        public void HaveAllCharacterLevelDisplayComponentsAssigned()
        {
            var components = Resources.FindObjectsOfTypeAll<CharacterLevelDisplay>();

            foreach (var component in components)
            {
                if (EditorUtility.IsPersistent(component)) return;
                Assert.NotNull(component);
                Assert.NotNull(component.levelLabel);
                Assert.NotNull(component.characterData);
            }
        }
        
        [Test]
        public void HaveAllCharacterHealthDisplayComponentsAssigned()
        {
            var components = Resources.FindObjectsOfTypeAll<CharacterHealthDisplay>();

            foreach (var component in components)
            {
                if (EditorUtility.IsPersistent(component)) return;
                Assert.NotNull(component);
                Assert.NotNull(component.healthLabel);
                Assert.NotNull(component.characterData);
            }
        }
        
        [Test]
        public void HaveAllCharacterClassDisplayComponentsAssigned()
        {
            var components = Resources.FindObjectsOfTypeAll<CharacterClassDisplay>();

            foreach (var component in components)
            {
                if (EditorUtility.IsPersistent(component)) return;
                Assert.NotNull(component);
                Assert.NotNull(component.classLabel);
                Assert.NotNull(component.characterData);
            }
        }
    }
}
