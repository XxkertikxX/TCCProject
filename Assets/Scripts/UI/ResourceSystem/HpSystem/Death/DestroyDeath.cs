using UnityEngine;
using UnityEngine.UI;

public class DestroyDeath : MonoBehaviour, IDeath
{
    [SerializeField] Animator animator;
    public void Death() {
        animator.Play("Morrendo");
        GetComponent<SelectWithKeyboard>().enabled = false;
        GetComponent<Button>().enabled = false;
        Transform[] selectedObject = GetComponentsInChildren<Transform>();
        for (int i = 0; i < selectedObject.Length; i++) 
        {
            if (selectedObject[i].name == "Selecionado")
            {
                Destroy(selectedObject[i]);
            }
        }
    }
}