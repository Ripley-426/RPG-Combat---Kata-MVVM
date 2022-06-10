using Commands;
using Components;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using ViewModel;

namespace Editor.Tests.Components
{
    [TestFixture] [Ignore("Missing test")]
    public class CharacterAttackInputShould
    {
        // TODO: ¿Que test double usar para la command factory? Revisar mockeo de ScriptableObjects
        // [Test]
        // public void ExecuteTheAttackCommandGivenByTheCommandFactory()
        // {
        //     CharacterData player = ScriptableObject.CreateInstance<CharacterData>();
        //     CharacterData opponent = ScriptableObject.CreateInstance<CharacterData>();
        //     DamageSkill skill = ScriptableObject.CreateInstance<DamageSkill>();
        //     CharacterCmdFactory cmdFactory = Substitute.For<CharacterCmdFactory>();
        //     AttackCommand command = Substitute.For<AttackCommand>();
        //     cmdFactory.PerformAttack(player, opponent, skill).Returns(command);
        //     
        //     command.Received(1).Execute();
        // }
    }
}