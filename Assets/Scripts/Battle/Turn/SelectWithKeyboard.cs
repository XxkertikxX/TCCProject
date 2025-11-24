using UnityEngine;
using System.Collections;

public class SelectWithKeyboard : MonoBehaviour
{
    [SerializeField] private CharacterClick characterClick;
    [SerializeField] private string key;
    [SerializeField] private GameObject selectIndicator;
    private CharacterAttributes status;
	private bool select = false;
	
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
		else{
			if(InputCatalyst.input.InputButtonDown(key) && CharacterClick.CharacterInteraction is CharacterSelect && !select) {
				characterClick.ClickCharacter(status);
				StartCoroutine(Select());
			}
		}
		if(!select) {
			selectIndicator.SetActive(ActiveIndicator());
		}
    }

	private IEnumerator Select() {
		select = true;
		selectIndicator.SetActive(true);
		yield return new WaitForSeconds(0.3f);
		selectIndicator.SetActive(false);
		yield return new WaitUntil(() => CharacterClick.CharactersSelect.Count == 1);
		select = false;
	}

    private bool ActiveIndicator() {
        return CharacterClick.CharacterAttr == status;
    }
}