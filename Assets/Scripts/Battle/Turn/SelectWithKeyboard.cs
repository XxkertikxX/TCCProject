using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWithKeyboard : MonoBehaviour
{
    [SerializeField] private CharacterClick characterClick;
    [SerializeField] private string key;
    [SerializeField] private GameObject selectIndicator;
    [SerializeField] private Event eventDialog;

    void OnEnable() {
        eventDialog.OnEvent += DisableSelect;
    }

    void Update() {
        if(InputCatalyst.input.InputButtonDown(key)) {
            characterClick.ClickCharacter(GetComponent<CharacterAttributes>());
            if(CharacterClick.CharacterInteraction == new CharacterSelect()) {
                selectIndicator.SetActive(true);
            }
        }
    }

    private void DisableSelect() {
        selectIndicator.SetActive(false);
    }
} 
