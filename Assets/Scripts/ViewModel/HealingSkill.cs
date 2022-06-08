using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "HealingSkill", menuName = "Data/Healing Skill")]
    public class HealingSkill : ScriptableObject
    {
        public float heal;
    }
}