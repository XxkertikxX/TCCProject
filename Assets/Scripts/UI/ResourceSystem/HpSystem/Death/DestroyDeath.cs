using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DestroyDeath : MonoBehaviour, IDeath
{
    public void Death() {
        GetComponentInChildren<Animator>().Play("Morrendo");
        GetComponent<SelectWithKeyboard>().enabled = false;
        GetComponent<Button>().enabled = false;
        GameObject[] selectedObject = GetComponentsInChildren<GameObject>();
        for (int i = 0; i < selectedObject.Length; i++) 
        {
            if (selectedObject[i].name == "Selecionado")
            {
                Destroy(selectedObject[i]);
            }
        }
    }
}