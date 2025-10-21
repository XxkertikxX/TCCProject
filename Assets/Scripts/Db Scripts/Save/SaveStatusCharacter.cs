using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DontDestroyOnLoad))]
public class SaveStatusCharacter : MonoBehaviour 
{
    [SerializeField] private StatusCharacters[] statusnS;
    static private StatusCharacters[] statusS;

    [SerializeField] private ManaSO mananS;
    static private ManaSO manaS;

    void Awake() {
        statusS = statusnS;
    }

    static public void SaveStatus(SaveStats save) {
        for(int i = 0; i < statusS.Length; i++) {
            SaveCharacter(save.StatusCharacter[i], statusS[i]);
        }
        save.Mana = manaS.Mana;
    }

    static public void LoadStatus(SaveStats save) {
        for(int i = 0; i < statusS.Length; i++) {
            LoadCharacter(save.StatusCharacter[i], statusS[i]);
        }
        manaS.Mana = save.Mana;
    }

    static private void SaveCharacter(Status status, StatusCharacters statusSO) {
        status.Level = statusSO.Level;
        status.Life = statusSO.Life;
        status.Power = statusSO.Power;
    }

    static private void LoadCharacter(Status status, StatusCharacters statusSO) {
        statusSO.Level = status.Level;
        statusSO.Life = status.Life;
        statusSO.Power = status.Power;
    }
}
