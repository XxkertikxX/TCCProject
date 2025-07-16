using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "CharacterCreator")]
public class StatusCharacters : ScriptableObject
{
    [SerializeField] private float hp;
    [SerializeField] private float power;
    [SerializeField] private List<SkillBase> skills;

    public float Hp => hp;
    public float Power => power;
    public List<SkillBase> Skills => skills;
}
