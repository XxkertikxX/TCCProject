using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Stun : MonoBehaviour
{
    [SerializeField] private CharacterAttributes characterAttributes;
    void Update() {
        if(!PlayerCharactersSkills.OnBattle) {
            gameObject.SetActive(characterAttributes.TurnsForCanAttack > 0);
        }
    }
}
