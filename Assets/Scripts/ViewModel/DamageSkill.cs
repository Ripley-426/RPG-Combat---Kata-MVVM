using UnityEngine;

namespace ViewModel
{
    [CreateAssetMenu(fileName = "DamageSkill", menuName = "Data/Damage Skill")]
    public class DamageSkill : ScriptableObject
    {
        public float damage;
    }
}
