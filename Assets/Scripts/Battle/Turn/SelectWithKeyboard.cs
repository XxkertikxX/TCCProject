using UnityEngine;

public class SelectWithKeyboard : MonoBehaviour
{
    [SerializeField] private CharacterClick characterClick;
    [SerializeField] private string key;
    [SerializeField] private GameObject selectIndicator;
    [SerializeField] private GameObject whoIsActingObject;
    private CharacterAttributes status;
    public static bool attacking = false;

    void Start() {
        status = GetComponent<CharacterAttributes>();
    }

    void Update() {
        if(InputCatalyst.input.InputButtonDown(key) && !PlayerCharactersSkills.OnBattle) {
            characterClick.ClickCharacter(status);
            if(CharacterClick.CharacterInteraction == new CharacterAttack()) {
                selectIndicator.SetActive(true); whoIsActingObject.SetActive(true);
            }
        }
        DisableAndEnableIndication();
        selectIndicator.SetActive(ActiveIndicator());
    }

    private bool ActiveIndicator() {
        return CharacterClick.CharacterAttr == status;
    }

    private void DisableAndEnableIndication()
    {
        if (attacking)
        {
            RemoveIndetification();
        }
        else
        {
            whoIsActingObject.SetActive(ActiveIndicator());
        }
    }

    private void RemoveIndetification()
    {
        whoIsActingObject.SetActive(!attacking);
    }
}