using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class TypeSkill : ScriptableObject
{
    public List<CharacterAttributes> CharactersAttributes;

    public abstract IEnumerator Targets();
}
