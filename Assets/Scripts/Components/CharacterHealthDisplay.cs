using TMPro;
using UniRx;
using UnityEngine;
using ViewModel;

namespace Components
{
    public class CharacterHealthDisplay : MonoBehaviour
    {
        public TextMeshProUGUI healthLabel;
        public CharacterData characterData;

        public void Start()
        {
            characterData.health
                .Subscribe(UpdateHealth)
                .AddTo(this);
        }

        private void UpdateHealth(float characterHealth)
        {
            healthLabel.text = $"{characterHealth}/{characterData.maxHealth}";
        }
    }
}