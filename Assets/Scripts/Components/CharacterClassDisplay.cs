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

        public void Start()
        {
            characterData.characterClass
                .Subscribe(UpdateClass)
                .AddTo(this);
        }

        private void UpdateClass(CharacterClass characterClass)
        {
            characterClass.className
                .Subscribe(UpdateClass)
                .AddTo(this);
        }

        private void UpdateClass(string className)
        {
            classLabel.text = className;
        }
    }
}