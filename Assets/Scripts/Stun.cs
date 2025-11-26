using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Stun : MonoBehaviour
{
    [SerializeField] private CharacterAttributes characterAttributes;
    [SerializeField] private GameObject stunGO;
    void Update() {
        if(!PlayerCharactersSkills.OnBattle) {
            stunGO.SetActive(characterAttributes.TurnsForCanAttack > 0);
        }
    }
}
