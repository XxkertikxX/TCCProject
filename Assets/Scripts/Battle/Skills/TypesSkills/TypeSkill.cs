using UnityEngine;
using System.Collections.Generic;

public abstract class TypeSkill : ScriptableObject
{
    public abstract List<CharacterAttributes> Targets();
}
