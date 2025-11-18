using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWithKeyboard : MonoBehaviour
{
    [SerializeField] private CharacterClick characterClick;
    [SerializeField] private string key;
    [SerializeField] private GameObject selectIndicator;

    private CharacterAttributes status;

    void Start() {
        status = GetComponent<CharacterAttributes>();
    }

    void Update() {
        if(InputCatalyst.input.InputButtonDown(key) && !PlayerCharactersSkills.OnBattle) {
            characterClick.ClickCharacter(status);
            if(CharacterClick.CharacterInteraction == new CharacterAttack()) {
                selectIndicator.SetActive(true);
            }
        }

        selectIndicator.SetActive(ActiveIndicator());
    }

    private bool ActiveIndicator() {
        return CharacterClick.CharacterAttr == status;
    }
}