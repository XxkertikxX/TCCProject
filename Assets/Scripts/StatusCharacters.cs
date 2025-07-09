using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
    [SerializeField] private float _hp;
    [SerializeField] private float _power;
    [SerializeField] private List<SkillBase> _skills;

    public float Hp => _hp;
    public float Power => _power;
    public List<SkillBase> Skills => _skills;
}
