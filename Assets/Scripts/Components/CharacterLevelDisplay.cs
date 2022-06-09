using TMPro;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterLevelDisplay : MonoBehaviour
    {
        public TextMeshProUGUI levelLabel;
        public CharacterData characterData;

        public void Start()
        {
            characterData.level
                .Subscribe(UpdateLevel)
                .AddTo(this);
        }

        private void UpdateLevel(int characterLevel)
        {
            levelLabel.text = $"Level: {characterLevel}";
        }
    }
}
