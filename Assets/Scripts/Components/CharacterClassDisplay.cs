using TMPro;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterClassDisplay: MonoBehaviour
    {
        public TextMeshProUGUI classLabel;
        public CharacterData characterData;

        //TODO: ¿Se puede subscribir al cambio de un scriptable object en el inspector?
        public void Start()
        {
            characterData.characterClass
                .Subscribe(UpdateClass)
                .AddTo(this);
        }

        private void UpdateClass(CharacterClass characterClass)
        {
            characterClass.className
                .Subscribe(UpdateClassName)
                .AddTo(this);
        }

        private void UpdateClassName(string className)
        {
            classLabel.text = className;
        }
    }
}